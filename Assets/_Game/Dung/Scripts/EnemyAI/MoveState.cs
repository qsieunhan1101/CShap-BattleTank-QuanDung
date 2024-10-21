using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : IState
{
    float time;
    float randomTime;
    int dirRandom;
    public void OnEnter(Enemy enemy)
    {
        time = 0f;
        randomTime = Random.Range(2,3);
        dirRandom = Random.Range(0, enemy.directions.Length);
        enemy.RotatePosition(dirRandom);
       // Debug.Log(dirRandom);
    }

    public void OnExecute(Enemy enemy)
    {
        time += Time.deltaTime;
        enemy.MovePosition(dirRandom);
        if (enemy.isBoxFront() == true)
        {
          
            enemy.ChangeState(new MoveState());
           
        }
        if (time >= randomTime)
        {
            enemy.ChangeState(new AttackState());
        }

    }



    public void OnExit(Enemy enemy)
    {

    }
}
