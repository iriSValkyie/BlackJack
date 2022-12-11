using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace BlackJack
{
    public class Card
    {
        private CardData m_data;

        private Text m_TypeText;

        private Text m_NumberText;


        public Card(string num, CardType type, CardColor color,Text typeText,Text numberText)
        {
            m_data = new CardData(num,type,color);
            m_TypeText = typeText;
            m_NumberText = numberText;
            m_NumberText.text = num;
            switch (type)
            {
                case CardType.Club:
                    typeText.text = "♣";
                    break;
                case CardType.Diamond:
                    typeText.text = "♦";
                    break;
                case CardType.Heart:
                    typeText.text = "♥";
                    break;
                case CardType.Spade:
                    typeText.text = "♠";
                    break;
            }

            switch (color)
            {
                case CardColor.Black:
                    typeText.color = Color.black;
                    numberText.color = Color.black;
                    break;
                case CardColor.Red:
                    typeText.color = Color.red;
                    numberText.color = Color.red;
                    break;
            }
           
        }
    }
}
