using System;
using BlackJack.Cards;
using BlackJack.Input;
using BlackJack.Model;
using Unity.VisualScripting;
using UnityEngine;

namespace BlackJack.Flows
{
    public class ActionFlow :BaseFlow
    {
        public ActionFlow(int flowNum) : base(flowNum)
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