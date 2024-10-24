using UnityEngine;

public class AttackState : IState
{
    float time;
    public void OnEnter(Enemy enemy)
    {
        time = 0f;
       // Debug.Log("Enter Attack State");
    }

    public void OnExecute(Enemy enemy)
    {

        time += Time.deltaTime;
        if (time > 0f && time < enemy.fireDelayTime)
        {
            enemy.Fire();
        }

        if (time >= enemy.fireDelayTime)
        {
            enemy.ChangeState(new MoveState());
        }

    }

    public void OnExit(Enemy enemy)
    {
      //  Debug.Log("Quit Attack State");
    }


}
