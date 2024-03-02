using System.Collections;
using System.Collections.Generic;
using BlackJack;
using BlackJack.Cards;
using BlackJack.Model;
using BlackJack.Tests;
using BlackJack.UI;
using Data;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private TestBetText m_BetText;
    [SerializeField] private TestChipText m_ChipText;
    
    [SerializeField] private StandButton m_StandButton;
    [SerializeField] private HitButton m_HitButton;

    [SerializeField] private ScoreViewItem m_ScoreViewPrefab;
    [SerializeField] private RectTransform m_ScoreParent;
    
    [SerializeField] private Transform m_CardInstanesParent;
    protected override void Configure(IContainerBuilder _builder)
    {
        //GameManager
        _builder.Register<ICardGenerator,CardGeneratorFromResources>(Lifetime.Singleton);
        _builder.RegisterComponent(m_CardInstanesParent);
        _builder.Register<CardManager>(Lifetime.Singleton);
        _builder.Register<FlowManager>(Lifetime.Singleton);
        _builder.Register<Player>(Lifetime.Singleton).WithParameter(typeof(PersonType),PersonType.PLAYER);
        _builder.Register<Dealer>(Lifetime.Singleton).WithParameter(typeof(PersonType),PersonType.DEALER);
        
        //UI
        _builder.RegisterComponent(m_BetText);
        _builder.RegisterComponent(m_ChipText);
        _builder.RegisterComponent(m_StandButton);
        _builder.RegisterComponent(m_HitButton);
        _builder.RegisterComponentInNewPrefab<ScoreViewItem>(m_ScoreViewPrefab,Lifetime.Transient)
            .UnderTransform(m_ScoreParent).As<IScoreViewItem>();
        
        _builder.RegisterComponentInHierarchy<TestGameManager>();
        
    }
}