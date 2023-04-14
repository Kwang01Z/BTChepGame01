using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] GameObject m_Target = null;
    [SerializeField] float m_StepDistance = 10.0f;
    [SerializeField] float m_ZDistance = 10.0f;
    [SerializeField] Vector2 m_MinPos;
    [SerializeField] Vector2 m_MaxPos;
    private void FixedUpdate()
    {
        Follow(Time.fixedDeltaTime);
    }
    void Follow(float a_DeltaTime)
    {
        if (m_Target == null)
        {
            return;
        }
        Vector3 diff = m_Target.transform.position + Vector3.back * m_ZDistance - transform.position;
        Vector3 newPos = transform.position + diff * m_StepDistance * a_DeltaTime;
        float xNew = Mathf.Clamp(newPos.x, m_MinPos.x, m_MaxPos.x);
        float yNew = Mathf.Clamp(newPos.y, m_MinPos.y, m_MaxPos.y);
        transform.position = new Vector3(xNew, yNew, newPos.z);
    }
   

    
}
