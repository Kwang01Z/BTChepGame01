using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : MonoBehaviour
{
    public float m_Distance = 50f;
    Vector3 m_OriginPos;
    KunaiSpawner m_KunaiSpawner;
    void Start()
    {
        m_OriginPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(m_OriginPos, transform.position) >= m_Distance)
        {
            m_KunaiSpawner?.Free(gameObject);
        }
    }
    public void SetSpawner(KunaiSpawner spawner)
    { 
        if(m_KunaiSpawner == null)
        m_KunaiSpawner = spawner;
    }
}
