using BlackJack.Cards;
using BlackJack.Input;
using BlackJack.Model;
using UnityEngine;

namespace BlackJack.Flows
{
    public class DealerHandCheckFlow :BaseFlow
    {
        public DealerHandCheckFlow(int typeNum) : base(typeNum)
        {
        }

        public override void InitFlow(ICardManager cardManager, IPerson player, IPerson dealer,IBlackjackInput _input)
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