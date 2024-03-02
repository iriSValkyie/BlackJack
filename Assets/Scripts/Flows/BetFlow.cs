using BlackJack.Cards;
using BlackJack.Model;
using BlackJack.Tests;
using UnityEngine;
using VContainer;

namespace BlackJack.Flows
{
    public class BetFlow :BaseFlow
    {

         private IBetText m_BetText;
        public BetFlow(int typeNum) : base(typeNum)
        {
        }
        [Inject]
        public void Construct(IBetText _betText)
        {
            m_BetText = _betText;
            m_BetText.SetText("0");
        }

        public override void InitFlow(ICardManager cardManager, IPerson player, IPerson dealer)
        {
           
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