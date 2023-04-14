using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] float m_MaxHp;
    float m_Hp;
    public bool IsDead => m_Hp >= 0;
    public virtual void OnInit()
    {
        m_Hp = m_MaxHp;
    }
    public virtual void OnDespawn()
    { }
    public void OnHid(float a_damage)
    {
        if (!IsDead)
        {
            m_Hp -= a_damage;
            if (m_Hp <= 0)
            {
                OnDead();
            }
        }
    }
    void OnDead()
    {

    }
}
