using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : AnimatorCharacter
{
    [SerializeField] EnemyController m_EnemyController;

    protected override void Reset()
    {
        base.Reset();
        m_EnemyController = GetComponentInParent<EnemyController>();
    }
    public void DamageObject()
    {
        Collider2D collider = Physics2D.OverlapCircle(m_EnemyController.transform.position, m_EnemyController.m_AttackRange, LayerMask.GetMask("Player"));
        if (collider != null)
        {
            if (collider.GetComponent<CharacterHealth>())
                collider.GetComponent<CharacterHealth>()?.TakeDamage(m_EnemyController.m_AttackDamage);
        }
    }
    public void Dead()
    {
        Destroy(transform.parent.gameObject);
    }
}
