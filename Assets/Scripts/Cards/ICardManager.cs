using BlackJack.Cards;
using UnityEngine;

namespace BlackJack.Cards
{
    public interface ICardManager
    {
        public void ResetDeck();

        public void DeleteCard(CardView _cardView);
        
        public Card GetCardData();
        
        public CardView GetCardView(Card _card);
        
        public Material GetCardMaterial(Card _card);
    }
}