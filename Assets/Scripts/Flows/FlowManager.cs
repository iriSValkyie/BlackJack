using System;
using System.Collections;
using System.Collections.Generic;
using BlackJack;
using UnityEngine;
using BlackJack.Flows;
using BlackJack.Cards;
using BlackJack.Model;
using Unity.VisualScripting;
using UniRx;
public class FlowManager
{
    private List<BaseFlow> m_Flows = new List<BaseFlow>();
    
    private ReactiveProperty<BaseFlow> m_NowFlow = new ReactiveProperty<BaseFlow>();

    private ICardManager m_CardManager;

    private IPerson m_Player;

    private IPerson m_Dealer;
    public FlowManager(ICardManager _cardManager ,IPerson _player,IPerson _dealer)
    {
        m_CardManager = _cardManager;
        m_NowFlow.SkipLatestValueOnSubscribe().Subscribe(OnChangedFlow);
        CreateFlowInstances();
        
    }

    public void StartFlow()
    {
        m_NowFlow.Value = m_Flows[0];
    }

    private void CreateFlowInstances()
    {
        for (int i = 0; i < Common.GetEnumCount<FlowType>(); i++)
        {
            FlowType type = (FlowType)i;
            BaseFlow baseFlow = null;
            switch (type)
            {
                case FlowType.BET:
                {
                    baseFlow = new BetFlow(i);
                    break;
                }
                case FlowType.DEAL:
                {
                    baseFlow = new DealFlow(i);
                    break;
                }
                case FlowType.DEALER_HAND_CHECK:
                {
                    baseFlow = new DealerHandCheckFlow(i);
                    break;
                }
                case FlowType.ACTION:
                {
                    baseFlow = new ActionFlow(i);
                    break;
                }
                case FlowType.DEALER_HAND_OPEN:
                {
                    baseFlow = new DealerHandOpenFlow(i);;
                    break;
                }
                case FlowType.RESULT:
                {
                    baseFlow = new ResultFlow(i);
                    break;
                }
            }
            baseFlow.OnRequestEndFlow.Subscribe(OnEndedFlow);
            m_Flows.Add(baseFlow);
        }
    }
    
    
    private void OnEndedFlow(BaseFlow nowFlow)
    {
        int nextFlowNum = 0;
        int nowFlowNum = (int)nowFlow.Type;
        nowFlow.EndFlow();

        nextFlowNum = nowFlowNum++;
        if (nextFlowNum >= Common.GetEnumCount<FlowType>()) nextFlowNum = 0;
        m_NowFlow.Value = m_Flows[nextFlowNum];
    }

    private void OnChangedFlow(BaseFlow nowFlow)
    {
        nowFlow.InitFlow(m_CardManager,m_Player,m_Dealer);
    }
    
}
