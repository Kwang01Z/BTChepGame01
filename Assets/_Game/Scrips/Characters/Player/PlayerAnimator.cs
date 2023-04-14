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
}
