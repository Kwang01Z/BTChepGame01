using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointManager : MonoBehaviour
{
    [SerializeField] Transform m_PointOriginToSpawnPlayer;
    [SerializeField] PlayerController m_PlayerController;
    Vector3 m_CurrentCheckpoint;
    private void Awake()
    {
        m_CurrentCheckpoint = m_PointOriginToSpawnPlayer.position;
        SpawnAtCheckPoint();
    }
    public void CheckPoint(Vector3 a_point)
    {
        m_CurrentCheckpoint = a_point;
    }
    public void SpawnAtCheckPoint()
    {
        m_PlayerController.gameObject.transform.position = m_CurrentCheckpoint;
    }
}
