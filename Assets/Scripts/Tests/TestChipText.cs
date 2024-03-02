using System.Collections;
using System.Collections.Generic;
using BlackJack.Tests;
using TMPro;
using UnityEngine;

public class TestChipText : MonoBehaviour,IChipText
{
    [SerializeField] private TextMeshProUGUI m_Text;
    
    private const string HEADER = "チップ数:";
    
    public void SetText(string _text)
    {
        m_Text.text = HEADER　+　_text;
    }
}
