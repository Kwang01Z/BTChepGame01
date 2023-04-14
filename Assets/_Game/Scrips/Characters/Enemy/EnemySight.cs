using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    [SerializeField] EnemyController m_EnemyController;
    private void Reset()
    {
        m_EnemyController = GetComponentInParent<EnemyController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            m_EnemyController.SetTarget(collision.transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            m_EnemyController.SetTarget(null);
        }
    }
}
