using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : CharacterHealth
{
    [SerializeField] EnemyController m_EnemyController;
    private void Reset()
    {
        m_EnemyController = GetComponent<EnemyController>();
    }
    public override void OnDamagedEffect()
    {
        base.OnDamagedEffect();
        m_EnemyController.StopMoving();
        m_AnimatorCharacter.ChangeState("damaged");
    }
    protected override void OnDeadEffect()
    {
        base.OnDeadEffect();
        m_EnemyController.StopMoving();
        m_AnimatorCharacter.ChangeState("dead");
        Invoke(nameof(HideEnemy), 1);
    }
    void HideEnemy()
    {
        gameObject.SetActive(false);
    }
}
