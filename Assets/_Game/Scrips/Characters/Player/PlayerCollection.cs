using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerCollection : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_CoinCountText;
    int m_CoinCount;
    private void Start()
    {
        m_CoinCountText.SetText(GetCoinCountText());
    }
    public void AddCoint()
    {
        m_CoinCount++;
        m_CoinCountText.SetText(GetCoinCountText());
    }
    string GetCoinCountText()
    {
        return "x" + m_CoinCount;
    }
}
