using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BlackJack;
public class CardBehaviour : MonoBehaviour
{
    private Card m_card;

    [SerializeField] Text m_Type;
    [SerializeField] Text m_Num;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void GenerateCard(string num,CardType type,CardColor color)
    {
        m_card = new Card(num,type,color,m_Type,m_Num);
    }


    public void InitCard()
    {
        m_card = null;
        m_Num.text = "";
        m_Type.text = "";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
