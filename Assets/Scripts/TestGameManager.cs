using System.Collections;
using System.Collections.Generic;
using BlackJack;
using BlackJack.Cards;
using BlackJack.Model;
using Data;
using UnityEngine;
using UniRx;

public class TestGameManager : MonoBehaviour
{
    [SerializeField] private Transform m_CardInstanesParent;
    private FlowManager m_FlowManager;
    private CardManager m_CardManager;

    private IPerson m_Player;
    private IPerson m_Dealer;
    
    private CardGeneratorFromResources m_CardGeneratorFromResources;
    // Start is called before the first frame update
    void Start()
    {
        m_CardGeneratorFromResources = new CardGeneratorFromResources();
        m_CardManager = new CardManager(m_CardGeneratorFromResources,m_CardInstanesParent);
        m_CardManager.CardLoadStateEvent.Subscribe(OnChangedLoadState);
        
        m_Player = new Player(PersonType.PLAYER);
        m_Dealer = new Dealer(PersonType.DEALER);
        m_FlowManager = new FlowManager(m_CardManager,m_Player,m_Dealer);

    }

    private void OnChangedLoadState(LoadStateType type)
    {
        Debug.Log($"LoadingState:{type}");

        if (type == LoadStateType.LOADED)
        {
            m_FlowManager.StartFlow();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
