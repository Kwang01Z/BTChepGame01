using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiSpawner : MonoBehaviour
{
    [SerializeField] PlayerController m_PlayerController;
    [SerializeField] GameObject m_MyKunai;
    ObjectSpawner m_ObjectSpawner;
    void Start()
    {
        m_PlayerController.SetWeaponSpawner(this);
        Init();
    }

    public void Init()
    {
        m_ObjectSpawner = new ObjectSpawner(transform, m_MyKunai, 5);
    }
    public GameObject Get(Vector3 a_ObjPos)
    {
        GameObject ret = m_ObjectSpawner.Get(transform, a_ObjPos, Quaternion.identity);
        ret.GetComponent<DespawnByDistance>().SetSpawner(this);
        ret.GetComponent<Kunai>().SetPlayerTransform(m_PlayerController);
        return ret;
    }
    public void Free(GameObject a_gameObject)
    {
        m_ObjectSpawner.Free(transform, a_gameObject);
    }
}
