using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    float m_Timer;
    float m_TimeRandom;
    public void OnEnter(EnemyController enemy)
    {
        enemy.StopMoving();
        m_Timer = 0;
        m_TimeRandom = Random.Range(2f, 3f);
    }

    public void OnExecute(EnemyController enemy)
    {
        m_Timer += Time.deltaTime;
        if (m_Timer >= m_TimeRandom)
        {
            enemy.ChangeState(new PatrolState());
        }
    }

    public void OnExit(EnemyController enemy)
    {
        
    }
}
