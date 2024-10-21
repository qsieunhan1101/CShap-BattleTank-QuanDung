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


    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        //Destroy(gameObject, timeDestroy);
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
}
