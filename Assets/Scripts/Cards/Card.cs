using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlackJack.Card
{
    public class Card
    {
        public CardType Type { get; private set; }

        public int Number { get; private set; }

        public Card(int _num,CardType _cardType)
        {
            Number = _num;
            Type = _cardType;
        }

        public override int GetHashCode() => HashCode.Combine(Number, Type);
        
        public override bool Equals(object obj)
        {
            var other = obj as Card;
            if (other == null) return false;
            
            return this.Type == other.Type &&
                   this.Number == other.Number;
        }
    }
}
