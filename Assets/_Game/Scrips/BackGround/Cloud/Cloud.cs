using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField] Transform m_OriginTransForm;
    [SerializeField] Transform m_EndTransForm;
    [SerializeField] float m_FlySpeed;
    Vector3 m_OriginPosition;
    Vector3 m_EndPosition;
    // Start is called before the first frame update
    void Start()
    {
        m_OriginPosition = m_OriginTransForm.position;
        m_EndPosition = m_EndTransForm.position;
        transform.position = m_OriginPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, m_EndPosition, Time.deltaTime * m_FlySpeed);
        if (Vector3.Distance(transform.position, m_EndPosition) <= 0.5f)
        {
            transform.position = m_OriginPosition;
        }
    }
}
