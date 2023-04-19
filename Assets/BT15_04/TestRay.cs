using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CheckRayCast();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void CheckRayCast()
    {
        RaycastHit[] raylist = Physics.RaycastAll(transform.position,transform.right);
        if (raylist.Length > 0)
        {
            foreach (RaycastHit hit in raylist)
            {
                Debug.Log(hit.collider.name);
            }
        }
        
    }
}
