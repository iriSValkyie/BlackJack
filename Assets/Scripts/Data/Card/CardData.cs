using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BlackJack
{[System.Serializable]
    public class CardData
    {
        public string Number;
        public CardType Type;
        public CardColor Color;
        public CardData(string num,CardType type,CardColor color)
        {
            Number = num;
            Type = type;
            Color = color;
        }
    }
    public enum CardType
    {
        Spade,
        Heart,
        Diamond,
        Club
    }

    public enum CardColor
    {
        Red,
        Black,
    }
}