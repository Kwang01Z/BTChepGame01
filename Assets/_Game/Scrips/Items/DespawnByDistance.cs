using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : MonoBehaviour
{
    public float m_Distance = 50f;
    Vector3 m_OriginPos;
    void Start()
    {
        m_OriginPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(m_OriginPos, transform.position) >= m_Distance)
        {
            //gameObject.SetActive(false);
        }
    }
}
