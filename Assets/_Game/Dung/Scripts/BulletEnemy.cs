using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    [Header("Bullet settings")]
    [Tooltip("Life time of the bullet. (Sec)")] public float lifeTime = 2.0f;
    [Tooltip("Prefab for the broken effects.")] public GameObject brokenObject;
    [Tooltip("Set this Rigidbody.")] public Rigidbody thisRigidbody;
    [field: SerializeField] public float Speed { get; set; }
    [field: SerializeField]
    private GameObject burnEffect;
    [field: SerializeField]
    private GameObject bulletBody;

    Transform thisTransform;
    bool isLiving = true;
    //Ray ray = new Ray();
    Transform hitTransform;
   
    //float damage = 10f;
    private void Start()
    {
        bulletBody.SetActive(true);
        thisTransform = transform;
        if (thisRigidbody == null)
        {
            thisRigidbody = GetComponent<Rigidbody>();
        }
        burnEffect.SetActive(false);
        thisRigidbody.useGravity = false;
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ConstProperty.obstacleTag))
        {
            //Debug.Log(other.gameObject.name);
            other.gameObject.SetActive(false);
            thisRigidbody.isKinematic = true;
            bulletBody.SetActive(false);
            burnEffect.SetActive(true);
            
            Destroy(this.gameObject, 0.5f);
        }
       // Hit();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isLiving == false)
        {
            return;
        }
        
        //hitTransform = collision.collider.transform;
        //Hit();
        //Destroy(this.gameObject);
    }
    void Hit()
    {
       // Debug.Log(hitTransform.gameObject.name);
        isLiving = false;

        if (brokenObject)
        {
            Instantiate(brokenObject, thisTransform.position, Quaternion.identity);
        }

        if (hitTransform == null)
        {
            return;
        }
        Destroy(this.gameObject);
    }
}
