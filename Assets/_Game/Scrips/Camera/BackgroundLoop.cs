using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public GameObject[] levels;
    private Camera mainCamera;
    private float screenBoundsWidth;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        screenBoundsWidth = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z)).x;
        foreach (GameObject obj in levels)
        {
            LoadChildObjects(obj);
        }
    }
    void LoadChildObjects(GameObject obj)
    {
        float objectWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x;
        int childNeeded = (int)Mathf.Ceil(screenBoundsWidth * 2 / objectWidth);
        GameObject clone = Instantiate(obj) as GameObject;
        for (int i = -1; i <= childNeeded; i++)
        {
            GameObject c = (GameObject)Instantiate(clone);
            c.transform.SetParent(obj.transform);
            c.transform.position = new Vector3(objectWidth * i, obj.transform.position.y, obj.transform.position.z);
        }
        Destroy(clone);
        Destroy(obj.GetComponent<SpriteRenderer>());
    }
    // Update is called once per frame
    void LateUpdate()
    {
        foreach (GameObject obj in levels)
        {
            repositionChildObject(obj);
        }
    }

    private void repositionChildObject(GameObject obj)
    {
        Transform[] children = obj.GetComponentsInChildren<Transform>();
        if (children.Length > 1)
        {
            GameObject firstChild = children[1].gameObject;
            GameObject lastChild = children[children.Length - 1].gameObject;
            float objectWidth = lastChild.GetComponent<SpriteRenderer>().bounds.size.x;
            if (transform.position.x + screenBoundsWidth > lastChild.transform.position.x)
            {
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector3(lastChild.transform.position.x + objectWidth, lastChild.transform.position.y, lastChild.transform.position.z);
            }
            else if (transform.position.x - screenBoundsWidth < firstChild.transform.position.x)
            {
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(firstChild.transform.position.x - objectWidth, firstChild.transform.position.y, firstChild.transform.position.z);
            }
        }

    }
}
