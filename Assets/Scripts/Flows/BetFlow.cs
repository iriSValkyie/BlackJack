using BlackJack.Cards;
using BlackJack.Model;
using UnityEngine;

namespace BlackJack.Flows
{
    public class BetFlow :BaseFlow
    {
        public BetFlow(int typeNum) : base(typeNum)
        {
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