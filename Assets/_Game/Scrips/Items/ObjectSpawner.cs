using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner
{
    protected Stack<GameObject> m_FreeInstances = new Stack<GameObject>();
    protected GameObject m_Original;

    public ObjectSpawner(Transform a_parent, GameObject a_original, int a_initialSize)
    {
        m_Original = a_original;
        m_FreeInstances = new Stack<GameObject>(a_initialSize);

        for (int i = 0; i < a_initialSize; ++i)
        {
            GameObject obj = Object.Instantiate(a_original);
            Free(a_parent, obj);
        }
    }
    public GameObject Get(Transform parent, Vector3 pos, Quaternion quat)
    {
        GameObject ret = m_FreeInstances.Count > 0 ? m_FreeInstances.Pop() : Object.Instantiate(m_Original);
        ret.SetActive(true);
        ret.transform.parent = parent;
        ret.transform.position = pos;
        ret.transform.rotation = quat;

        return ret;
    }
    public void Free(Transform root, GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.parent = root;
        m_FreeInstances.Push(obj);
    }
}
