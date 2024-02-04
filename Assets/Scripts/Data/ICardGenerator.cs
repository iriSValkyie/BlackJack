using System.Collections;
using System.Collections.Generic;
using BlackJack.Card;
using Cysharp.Threading.Tasks;
using UnityEngine;

public interface ICardGenerator
{
    public IReadOnlyDictionary<Card, Material> MaterialDict { get; }
    
    public IReadOnlyCollection<Card> Cards { get; }

    public CardView CardView { get; }

    public UniTask<bool> Load();
    
}
