using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRay2 : MonoBehaviour
{
    [SerializeField] GameObject GameObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 checkPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
        }
        
    }
}
