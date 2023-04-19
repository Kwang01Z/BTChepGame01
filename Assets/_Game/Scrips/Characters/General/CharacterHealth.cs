using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterHealth : MonoBehaviour
{
    [SerializeField] protected float m_MaxHp = 200f;
    [SerializeField] Slider m_HpBarSlider;
    [SerializeField] float m_SpeedSmoothHealthBar = 3f;
    [SerializeField] protected AnimatorCharacter m_AnimatorCharacter;
    float m_Hp;
    protected bool m_CanHurt;
    protected bool m_IsDead;
    private void Reset()
    {
        m_AnimatorCharacter = GetComponentInChildren<AnimatorCharacter>();
    }
    private void Start()
    {
        m_CanHurt = true;
        m_IsDead = false;
        OnInit();
    }
    public virtual void OnInit()
    {
        m_Hp = m_MaxHp;
        m_HpBarSlider.value = m_Hp / m_MaxHp;
    }
    public virtual void TakeDamage(float a_damage)
    {
        if (!m_CanHurt) return;
        m_Hp -= a_damage;
        OnDamagedEffect();
    }
    public virtual void OnDamagedEffect()
    { }
    private void Update()
    {
        SmoothHealthBar();
        ValidateHealth();
    }
    void ValidateHealth()
    {
        if (m_Hp > m_MaxHp)
        {
            m_Hp = m_MaxHp;
        }
        if (m_Hp <= 0 && !m_IsDead)
        {
            m_CanHurt = false;
            OnDeadEffect();
            m_IsDead = true;
        }
    }
    protected virtual void OnDeadEffect()
    { }
    void SmoothHealthBar()
    {
        m_HpBarSlider.value = Mathf.Lerp(m_HpBarSlider.value, m_Hp / m_MaxHp, Time.deltaTime * m_SpeedSmoothHealthBar);
    }
}
