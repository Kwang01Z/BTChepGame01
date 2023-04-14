using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] SavePointManager m_SavePointManager;
    bool m_IsChecked;
    private void Reset()
    {
        m_SavePointManager = GetComponentInParent<SavePointManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!m_IsChecked)
        {
            m_SavePointManager.CheckPoint(this.transform.position);
            m_IsChecked = true;
        }
    }
}
