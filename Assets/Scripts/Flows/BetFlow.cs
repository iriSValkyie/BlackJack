using BlackJack.Cards;
using BlackJack.Input;
using BlackJack.Model;
using BlackJack.Tests;
using UnityEngine;
using VContainer;
using UniRx;

namespace BlackJack.Flows
{
    public class BetFlow :BaseFlow
    {

         private IBetText m_BetText;
         private IBlackjackInput m_input;
         private CompositeDisposable m_ConpositeDisposable;
        public BetFlow(int typeNum) : base(typeNum)
        {
        }
        [Inject]
        public void Construct(IBetText _betText)
        {
            m_BetText = _betText;
            m_BetText.SetText("0");
        }

        public override void InitFlow(ICardManager cardManager, IPerson player, IPerson dealer,IBlackjackInput _input)
        {
            m_input = _input;
            StartFlow();
        }

        public override void StartFlow()
        {
            Debug.Log($"FlowStarting:{Type}");
            m_ConpositeDisposable = new CompositeDisposable();
            m_input.BetUp += () => Debug.Log("OnClickedBetUp");
            m_input.BetDown += () => Debug.Log("OnClickBetDown");
            m_input.BetMax += () => Debug.Log("OnClickBetMax");
        }

        public override void EndFlow()
        {
            m_ConpositeDisposable.Dispose();
        }
    }
}