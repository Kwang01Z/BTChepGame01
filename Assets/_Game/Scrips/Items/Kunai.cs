using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kunai : MonoBehaviour
{
    [SerializeField] Rigidbody2D m_Rigidbody2D;
    [SerializeField] float m_AttackRange;
    [SerializeField] float m_AttackDamage;
    PlayerController m_PlayerController;
    public float m_Speed = 10f;
    Vector2 m_Direction;
    private void Reset()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }
    private void OnEnable()
    {
        if (m_PlayerController == null) return;
        
    }
    private void Update()
    {
        if (m_PlayerController == null) return;
        m_Direction = transform.position.x > m_PlayerController.transform.position.x ? Vector2.right : Vector2.left;
        bool isFacingRight = transform.position.x > m_PlayerController.transform.position.x;
        transform.localScale = new Vector3(isFacingRight ? 1 : -1, 1, 1);
        m_Rigidbody2D.velocity = m_Direction * m_Speed;
    }
    public void SetPlayerTransform(PlayerController a_controller)
    {
        if (m_PlayerController == null)
        {
            m_PlayerController = a_controller; 
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.GetComponent<EnemyHealth>())
            {
                collision.GetComponent<CharacterHealth>()?.TakeDamage(m_AttackDamage);
                m_PlayerController.FreeKunai(this.gameObject);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, m_AttackRange);
    }
}
