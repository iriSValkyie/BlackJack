using System;
using System.Collections;
using System.Collections.Generic;
using BlackJack.Cards;
using BlackJack.Model;
using UniRx;

namespace  BlackJack.Flows
{
    public abstract class BaseFlow
    {
        protected BaseFlow(int typeNum)
        {
            Type = (FlowType)typeNum;
        }

        private Subject<BaseFlow> onRequestEndFlow = new Subject<BaseFlow>();
        
        public IObservable<BaseFlow> OnRequestEndFlow => onRequestEndFlow;
        
        public FlowType Type { get; set; }

        public abstract void InitFlow(ICardManager _cardManager,IPerson _player,IPerson _dealer);

        public abstract void StartFlow();
        
        public abstract void EndFlow();//INFO:同期なので次のInitFlowと同時に発火するのでフローのリセットとして使うのがいいかも
    }
}

