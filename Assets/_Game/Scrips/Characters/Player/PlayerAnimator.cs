using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : AnimatorCharacter
{
    [SerializeField] PlayerController m_PlayerController;
    protected override void Reset()
    {
        base.Reset();
        m_PlayerController = GetComponentInParent<PlayerController>();
    }
    private void Awake()
    {
        m_PlayerController.SetAnimator(this);
    }
    public void InstanceKunai()
    {
        m_PlayerController.ThrowKunai();
    }
    public void DamageObject()
    {
        Collider2D collider = Physics2D.OverlapCircle(m_PlayerController.transform.position, m_PlayerController.m_AttackRange,LayerMask.GetMask("Enemy"));
        if (collider != null)
        {
            if(collider.GetComponent<CharacterHealth>())
            collider.GetComponent<CharacterHealth>()?.TakeDamage(m_PlayerController.m_AttackDamage);
        }
    }
}
