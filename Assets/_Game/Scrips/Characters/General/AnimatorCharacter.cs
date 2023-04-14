using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorCharacter : MonoBehaviour
{
    [SerializeField] protected Animator m_Animator;
    protected string m_currentState = "";
    protected virtual void Reset()
    {
        m_Animator = GetComponent<Animator>();
    }
    public void ChangeState(string a_state)
    {
        m_Animator.ResetTrigger(m_currentState);
        m_currentState = a_state;
        m_Animator.SetTrigger(m_currentState);
    }
    public string GetCurrentState()
    {
        return m_currentState;
    }
    public Animator GetAnimator()
    {
        return m_Animator;
    }
}
