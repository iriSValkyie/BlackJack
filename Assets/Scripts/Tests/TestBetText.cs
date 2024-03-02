using System.Collections;
using System.Collections.Generic;
using BlackJack.Tests;
using TMPro;
using UnityEngine;

public class TestBetText : MonoBehaviour,IBetText
{
    [SerializeField] private TextMeshProUGUI m_Text;


    private const string HEADER = "ベット数:";
    public void SetText(string _text)
    {
        m_Text.text = HEADER +　_text;
    }
}
