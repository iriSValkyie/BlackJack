using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace BlackJack.Tests
{
    public class HitButton : MonoBehaviour, IHitButton
    {
        [SerializeField] private Button m_Button;
        
        public IObservable<Unit> OnClick => m_Button.OnClickAsObservable();
    }
}