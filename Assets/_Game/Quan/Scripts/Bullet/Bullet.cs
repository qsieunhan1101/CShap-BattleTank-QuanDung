using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timeDestroy;
    [SerializeField] private Transform bulletBody;
    private Rigidbody rb;
    public Vector3 direction;

    [Header("Effect")]
    [SerializeField] private ParticleSystem bulletParticle;
    [SerializeField] private Transform bulletVfx;

    public float dame;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        Destroy(gameObject, timeDestroy);
    }
    private void Update()
    {
        Move();
        Rotation();
    }

    private void Move()
    {
        rb.velocity = new Vector3(direction.x * speed, rb.velocity.y, direction.z * speed);

    }
    private void Rotation()
    {
        if (rb.velocity != Vector3.zero)
        {
            Quaternion rota = Quaternion.LookRotation(rb.velocity);
            bulletBody.rotation = rota;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ConstProperty.obstacleTag))
        {
            other.gameObject.SetActive(false);
            rb.isKinematic = true;
            bulletVfx.gameObject.SetActive(false);
            bulletParticle.gameObject.SetActive(true);


            Destroy(gameObject, 0.5f);
        }
        if (other.CompareTag(ConstProperty.enemyTag))
        {
            other.transform.GetComponent<Enemy>().TankDame(dame);
            Destroy(gameObject);
        }
    }
}
