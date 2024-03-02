using System;
using System.Collections.Generic;
using BlackJack;
using BlackJack.Cards;
using UniRx;    
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using VContainer;

namespace BlackJack.Cards
{
    public class CardManager : ICardManager

    {
    private ICardGenerator m_CardGenerator;

    private Dictionary<Card, Material> m_MaterialDict;

    private List<Card> m_Deck;

    private ObjectPool<CardView> m_CardViewPool = null;

    private Transform m_InstantiateParent;

    public IObservable<LoadStateType> CardLoadStateEvent => m_CardGenerator.LoadStateEvent;
        

    [Inject]
    public void Construct(ICardGenerator _cardGenerator, Transform _instanceParent)
    {
        m_CardGenerator = _cardGenerator;
        //m_CardGenerator.LoadStateEvent.Subscribe(OnChangedLoadState);
        Init(_instanceParent);
    }

    private async void InitGenerator()
    {
        await m_CardGenerator.Load();
    }

    private void Init(Transform _parent)
    {
        InitGenerator();
        m_InstantiateParent = _parent;

        m_CardViewPool = new ObjectPool<CardView>(
            OnCreatePoolObject,
            OnTakeFromPool,
            OnReturnedToPool,
            OnDestroyPoolObject,
            true,
            Consts.CARD_POOL_DEFAULT,
            Consts.CARD_POOL_MAX
        );
    }

    private CardView OnCreatePoolObject()
    {
        CardView cardView = GameObject.Instantiate(m_CardGenerator.CardView, Vector3.zero, Quaternion.identity,
            m_InstantiateParent);
        return cardView;
    }

    private void OnTakeFromPool(CardView _cardView)
    {
        _cardView.gameObject.SetActive(true);
    }

    private void OnReturnedToPool(CardView _cardView)
    {
        _cardView.gameObject.SetActive(false);
    }

    private void OnDestroyPoolObject(CardView _cardView)
    {
        GameObject.Destroy(_cardView);
    }

    /// <summary>
    /// デッキをリセットする(枚数リセットやシャッフルを行う)
    /// </summary>
    public void ResetDeck()
    {
        m_Deck.AddRange(m_CardGenerator.Cards);
        System.Random rand = new System.Random();
        int n = m_Deck.Count;

        while (n > 1)
        {
            n--;
            int k = rand.Next(n + 1);
            (m_Deck[k], m_Deck[n]) = (m_Deck[n], m_Deck[k]);
        }
    }


    /// <summary>
    /// シーン上にあるカードを削除
    /// </summary>
    /// <param name="_cardView"></param>
    public void DeleteCard(CardView _cardView)
    {
        m_CardViewPool.Release(_cardView);
    }

    /// <summary>
    /// カードを引く
    /// </summary>
    /// <returns></returns>
    public Card GetCardData()
    {
        Card target = m_Deck[0];
        m_Deck.RemoveAt(0);
        return target;
    }

    /// <summary>
    /// カードデータからマテリアルを取得
    /// </summary>
    /// <param name="_card"></param>
    /// <returns></returns>
    public Material GetCardMaterial(Card _card)
    {
        if (!m_MaterialDict.ContainsKey(_card)) return null;
        return m_MaterialDict[_card];
    }

    /// <summary>
    /// カードオブジェクトを取得する
    /// </summary>
    /// <param name="_card"></param>
    /// <returns></returns>
    public CardView GetCardView(Card _card)
    {
        return m_CardViewPool.Get();
    }

    }
}