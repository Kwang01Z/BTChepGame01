using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{
    float m_Timer;
    float m_TimeToAttack;
    public void OnEnter(EnemyController enemy)
    {
        m_TimeToAttack = 1f;
        m_Timer = 0.5f;
        Debug.Log("Start Attack");
    }

    public void OnExecute(EnemyController enemy)
    {
        if (!enemy.IsTargetInRange())
        {
            Random.InitState(2);
            enemy.ChangeState(new IdleState());
        }
        m_Timer += Time.deltaTime;
        if (m_Timer >= m_TimeToAttack)
        {
            enemy.Attack();
            m_Timer = 0f;
        } 
    }

    public void OnExit(EnemyController enemy)
    {
        m_Timer = 0f;
    }

}
