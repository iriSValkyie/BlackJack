using System;
using System.Collections;
using System.Collections.Generic;
using BlackJack;
using BlackJack.Cards;
using Cysharp.Threading.Tasks;
using UnityEngine;

public interface ICardGenerator
{
    public IReadOnlyDictionary<Card, Material> MaterialDict { get; }
    
    public IReadOnlyCollection<Card> Cards { get; }

    public IObservable<LoadStateType> LoadStateEvent { get; }

    public CardView CardView { get; }

    public UniTask<bool> Load();
    
}
