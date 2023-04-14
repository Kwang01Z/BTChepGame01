using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Rigidbody2D m_Rigidbody2D;
    [SerializeField] EnemyAnimator m_EnemyAnimator;
    [SerializeField] Vector2 m_PatrolPosLeft;
    [SerializeField] Vector2 m_PatrolPosRight;
    public float m_Speed = 7f;
    public float m_AttackRange = 10f;
    IState m_CurrentState;
    bool m_IsFacingRight;
    public Transform m_Target;
    private void Reset()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_EnemyAnimator = GetComponentInChildren<EnemyAnimator>();
    }
    private void Start()
    {
        m_IsFacingRight = true;
        OnInit();
    }
    public void OnInit()
    {
        ChangeState(new IdleState());
    }
    
    public void ChangeState(IState a_NewState)
    {
        m_CurrentState?.OnExit(this);
        m_CurrentState = a_NewState;
        m_CurrentState?.OnEnter(this);
    }
    private void Update()
    {
        if (!m_CurrentState.GetType().Equals(typeof(AttackState)) && IsTargetInRange())
        {
            ChangeState(new AttackState());
        }
        ChangeDirection();
        m_CurrentState?.OnExecute(this);
    }
    public void StopMoving()
    {
        m_Rigidbody2D.velocity = Vector2.zero;
        m_EnemyAnimator.GetAnimator().SetFloat("speed",0);
    }
    public void Moving()
    {
        m_Rigidbody2D.velocity = transform.right * m_Speed;
        m_EnemyAnimator.GetAnimator().SetFloat("speed", 1);
    }
    public void ChangeDirection()
    {
        if (transform.position.x >= m_PatrolPosRight.x)
        {
            m_IsFacingRight = false;
            ValidateDirection(m_IsFacingRight);
        }
        else if (transform.position.x <= m_PatrolPosLeft.x)
        {
            m_IsFacingRight = true;
            ValidateDirection(m_IsFacingRight);
        }
    }
    public void ValidateDirection(bool a_IsRight)
    {
        transform.rotation = a_IsRight ? Quaternion.Euler(Vector3.zero) : Quaternion.Euler(Vector3.up * 180);
    }
    public void SetTarget(Transform a_playerController)
    {
        m_Target = a_playerController;
        
    }
    public bool IsTargetInRange()
    {
        if (GetTarget() == null) return false;
        else
        {
            return Vector2.Distance(transform.position, m_Target.position) <= m_AttackRange;
        }
        
    }
    public void Attack()
    {
        m_EnemyAnimator.ChangeState("attack");
    }
    public Transform GetTarget()
    {
        return m_Target;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, m_AttackRange);
    }
}
