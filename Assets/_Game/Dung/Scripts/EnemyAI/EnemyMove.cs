using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    public float moveSpeed;
    Vector3 randomDirection;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        randomDirection = Vector3.forward;
    }

    // Update is called once per frame
    void Update()
    {
        float randomSpeed = Random.Range(3, 4);
        rb.velocity = randomDirection * randomSpeed * moveSpeed;
    }
}
