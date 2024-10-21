using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    IState currentState;
    [Header("Character_Enemy")]
    [SerializeField] private Rigidbody rb;
    public bool IsDead;

    [Header("Pool")]
    [SerializeField] private GameObject bulletBasePrefab;


    public Transform bodyTransform;
    public float fireDelayTime;
    public float enemySpeed;
    public Vector3[] directions = new Vector3[] { Vector3.forward, Vector3.back,  Vector3.left, Vector3.right };
    public float delta;
    Ray ray;
    RaycastHit hit;

    private void OnEnable()
    {
        OnInit();
    }
    protected virtual void OnInit()
    {
        ChangeState(new MoveState());
    }

    void Update()
    {
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }

        Debug.DrawRay(transform.position + transform.forward / delta + transform.up , Vector3.down * 10, Color.yellow);

    }

    public virtual void MovePosition(int dirIndex)
    {
        rb.MovePosition(transform.position + directions[dirIndex] * enemySpeed * Time.deltaTime);
    }
    
    public virtual void RotatePosition(int rotIndex)
    {
            // forward , back , left ,right 

        float angle = 0f;
        Vector3 dirRotation = Vector3.zero;
        switch(rotIndex)
        {
            case 0:
                angle = 0f;
                dirRotation = transform.position + directions[rotIndex] - transform.position;
                   break;
            case 1:
                angle = -180f;
                dirRotation = transform.position + directions[rotIndex] - transform.position;

                break;
            case 2:
                angle = -90f;
                dirRotation = transform.position + directions[rotIndex] - transform.position;

                break;
            case 3:
                angle = 90;
                dirRotation = transform.position + directions[rotIndex] - transform.position;

                break;

        }
        float smooth = 5.0f; 
        
        //transform.rotation = Quaternion.Euler(transform.rotation.x, angle, transform.rotation.z);
        transform.rotation = Quaternion.LookRotation(dirRotation);

    }

    public bool isBoxFront()
    {
        return Physics.Raycast(transform.position + transform.forward + transform.up, Vector3.down * 10, out RaycastHit hit, Mathf.Infinity)
            && hit.collider.CompareTag("Border");
    }

    public virtual Quaternion GetRotation(Vector3 rotation)
    {
        return bodyTransform.rotation = Quaternion.LookRotation(rotation);
    }


    public virtual void Fire()
    {
        Debug.Log("Fire");
    }
    public virtual void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }
        currentState = newState;
        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }

    private void OnDrawGizmos()
    {
        
    }

}
