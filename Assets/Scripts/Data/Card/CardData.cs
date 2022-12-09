using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BlackJack
{
    public struct CardData
    {
        public int Number { get; }
        public CardType Type { get; }
        public CardColor Color { get; }
        public CardData(int num,CardType type,CardColor color)
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