using System.Collections;
using System.Collections.Generic;
using BlackJack;
using BlackJack.Cards;
using BlackJack.Model;
using Data;
using UnityEngine;
using UniRx;
using VContainer;

public class TestGameManager : MonoBehaviour
{
    
    private FlowManager m_FlowManager;
    private CardManager m_CardManager;

    private Player m_Player;
    private Dealer m_Dealer;

    [Inject]
    public void Construct(FlowManager _flowManager,CardManager _cardManager,Player _player,Dealer _dealer)
    {
        m_FlowManager = _flowManager;
        m_CardManager = _cardManager;
        m_Player = _player;
        m_Dealer = _dealer;
        m_CardManager.CardLoadStateEvent.Subscribe(OnChangedLoadState);
    }
    
    private void OnChangedLoadState(LoadStateType type)
    {
        Debug.Log($"LoadingState:{type}");

        if (type == LoadStateType.LOADED)
        {
            m_FlowManager.StartFlow();
        }
    }
}
