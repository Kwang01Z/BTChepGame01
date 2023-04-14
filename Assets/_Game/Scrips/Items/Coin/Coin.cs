using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerCollection>())
        {
            collision.GetComponent<PlayerCollection>().AddCoint();
            gameObject.SetActive(false);
        }
    }
}
