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
        m_CoinCount = PlayerPrefs.GetInt("_CoinCount", 0);
        m_CoinCountText.SetText(GetCoinCountText());
    }
    public void AddCoint()
    {
        m_CoinCount++;
        m_CoinCountText.SetText(GetCoinCountText());
        PlayerPrefs.SetInt("_CoinCount",m_CoinCount);
    }
    string GetCoinCountText()
    {
        return "x" + m_CoinCount;
    }
}
