using System.Collections;
using System.Collections.Generic;
using BlackJack;
using BlackJack.UI;
using TMPro;
using UnityEngine;

public class ScoreViewItem : MonoBehaviour,IScoreViewItem
{
    [SerializeField] private TextMeshProUGUI m_header;
    [SerializeField] private TextMeshProUGUI m_text;
    public void SetScore(PersonType _type, string _text ="0")
    {
        if (_type == PersonType.DEALER)
        {
            m_header.text = "ディーラーの得点:";
        }
        else
        {
            m_header.text = "プレイヤーの得点:";
        }
        
        m_text.text = _text;
    }
}
