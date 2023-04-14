using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D m_Rigidbody2D;
    [SerializeField] CapsuleCollider2D m_Collider;
    [SerializeField] LayerMask m_GroundLayer;
    [SerializeField] LayerMask m_CeilingLayer;
    AnimatorCharacter m_AnimatorCharacter;
    public float m_Speed = 7f;
    public float m_JumpPow = 10f;
    public float m_ResetAttackTimer = 0.5f;
    public Transform m_ThrowPosition;
    public GameObject m_MyKunai;
    bool m_CanJumpable = true;
    bool m_IsGrounded;
    bool m_IsAttack;
    float horizontalDir;
    Ground m_CurrentGround = null;
    Vector3 feetPos;
    Transform m_CurrentGroundTrasform = null;
    private void Reset()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Collider = GetComponent<CapsuleCollider2D>();
        m_GroundLayer = 1 << 31;
        m_CeilingLayer = 1 << 30;
        m_KunaiSpawner = GetComponentInChildren<ObjectSpawner>();
    }
    private void Awake()
    {
        m_KunaiSpawner.
    }
    private void Update()
    {
        GroundCollionMachine();
        AttackUpdate();
        ThrowUpdate();
        JumpUpdate();
        RunUpdate();
        JumpCutUpdate();
    }
    void RunUpdate()
    {
        horizontalDir = Input.GetAxisRaw("Horizontal");
        m_AnimatorCharacter.GetAnimator().SetFloat("speed", Mathf.Abs(horizontalDir));
        if (Mathf.Abs(horizontalDir) != 0f)
        {
            m_Rigidbody2D.velocity = new Vector2(horizontalDir * m_Speed, m_Rigidbody2D.velocity.y);
            transform.localScale = new Vector3(horizontalDir, 1, 1);
        }
        else
        {
            m_Rigidbody2D.velocity = new Vector2(0f, m_Rigidbody2D.velocity.y);
        }
    }
    void JumpUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && m_CanJumpable)
        {
            m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, m_JumpPow);
            m_CanJumpable = false;
        }
    }
    void JumpCutUpdate()
    {
        if (!m_IsGrounded && m_Rigidbody2D.velocity.y < 0.5f)
        {
            m_AnimatorCharacter.ChangeState("fall");
        }
        if (m_IsGrounded)
        {
            m_CanJumpable = true;
        }
    }
    void AttackUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Attack();
    }
    void ThrowUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
            Throw();
    }
    bool CheckGround()
    {
        feetPos = transform.position + Vector3.down * m_Collider.size.y / 2f * 1.05f;
        Debug.DrawLine(transform.position, new Vector3(feetPos.x, feetPos.y));
        RaycastHit2D raycastHit2D = Physics2D.Raycast(feetPos, Vector3.down, 0.1f, m_GroundLayer);
        return raycastHit2D.collider != null;
    }
    public void SetAnimator(AnimatorCharacter animator)
    {
        m_AnimatorCharacter = animator;
    }
    void Attack()
    {
        if (!m_IsAttack)
        {
            m_AnimatorCharacter.ChangeState("attack");
            m_IsAttack = true;
            Invoke(nameof(ResetAttack), m_ResetAttackTimer);
        }
    }
    void Throw()
    {
        if (!m_IsAttack)
        {
            m_AnimatorCharacter.ChangeState("throw");
            m_IsAttack = true;
            Invoke(nameof(ResetAttack), m_ResetAttackTimer);
        }
    }
    public void ThrowKunai()
    {
        Debug.Log("Throw");
    }
    void ResetAttack()
    {
        m_IsAttack = false;
    }
    void GoingDown()
    {
        m_CurrentGround?.ChangeLayer(m_CeilingLayer);
    }
    void FindingGround()
    {
        Vector2 director = Vector2.down;
        RaycastHit2D raycastHit2D = Physics2D.Raycast(feetPos, director, 0.1f);
        if (raycastHit2D.transform == null) return;

        if (m_CurrentGroundTrasform == raycastHit2D.transform) return;

        m_CurrentGroundTrasform = raycastHit2D.transform;
        m_CurrentGround = m_CurrentGroundTrasform.gameObject.GetComponent<Ground>();
        m_CurrentGround?.ChangeLayer(m_GroundLayer);
    }
    void GroundCollionMachine()
    {
        m_IsGrounded = CheckGround();
        m_AnimatorCharacter.GetAnimator().SetBool("isGrounded", m_IsGrounded);
        FindingGround();
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            GoingDown();
        }
    }
}
