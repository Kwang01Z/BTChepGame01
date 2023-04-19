using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IState
{
    float m_Timer;
    float m_TimeRandom;
    public void OnEnter(EnemyController enemy)
    {
        m_Timer = 0;
        m_TimeRandom = Random.Range(3f, 6f);
    }

    public void OnExecute(EnemyController enemy)
    {
        m_Timer += Time.deltaTime;
        if (m_Timer < m_TimeRandom)
        {
            enemy.Moving();
        }
        else
        {
            enemy.ChangeState(new IdleState());
        }  
    }

    public void OnExit(EnemyController enemy)
    {
    }
}
