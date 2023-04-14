using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kunai : MonoBehaviour
{
    [SerializeField] Rigidbody2D m_Rigidbody2D;
    public float m_Speed = 10f;
    private void Reset()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        m_Rigidbody2D.velocity = Vector2.right * m_Speed; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
