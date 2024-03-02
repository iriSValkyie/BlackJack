using BlackJack.Cards;
using BlackJack.Model;
using BlackJack.UI;
using UnityEngine;
using VContainer;

namespace BlackJack.Flows
{
    public class DealFlow :BaseFlow
    {
        private ICardManager m_CardManager;
        private IPerson m_Player;
        private IPerson m_Dealer;

        
        
        public DealFlow(int typeNum) : base(typeNum)
        {
        }

        public override void InitFlow(ICardManager cardManager, IPerson player, IPerson dealer)
        {
            m_CardManager = cardManager;
            m_Player = player;
            m_Dealer = dealer;
            
            StartFlow();
        }

        public override void StartFlow()
        {
            Debug.Log($"FlowStarting:{Type}");
        }

        public override void EndFlow()
        {
            
        }
    }
}