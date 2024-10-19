using UnityEditor;
using UnityEngine;

public class IdleState : IState
{
    float time;
    float timeIdle;
    public void OnEnter(Enemy enemy)
    {
        time = 0;
        timeIdle = 2.5f;
    }

    public void OnExecute(Enemy enemy)
    {
        time += Time.deltaTime;
        if (time >= timeIdle && enemy.IsDead == false
            )
        {
            enemy.ChangeState(new MoveState());
        }
    }

    public void OnExit(Enemy enemy)
    {

    }
}
