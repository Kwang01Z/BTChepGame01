using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUI : MonoBehaviour
{
    [SerializeField] EnemyController m_EnemyController;
    private void Reset()
    {
        m_EnemyController = GetComponentInParent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = m_EnemyController.IsFacingRight() ? Vector3.one : new Vector3(-1, 1, 1);
    }
}
