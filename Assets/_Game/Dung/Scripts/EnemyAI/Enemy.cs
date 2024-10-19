using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    IState currentState;
    [Header("Character_Enemy")]
    [SerializeField] private Rigidbody rb;
    public bool IsDead;

    [Header("Pool")]
    [SerializeField] private GameObject bulletBasePrefab;


    public Transform bodyTransform;

    private void OnEnable()
    {
        OnInit();
        ChangeState(new MoveState());
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
    }

    public virtual Quaternion GetRotation(Vector3 rotation)
    {
        return bodyTransform.rotation = Quaternion.LookRotation(rotation);
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

}
