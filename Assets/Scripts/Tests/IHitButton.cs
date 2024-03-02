using System;
using UniRx;

namespace BlackJack.Tests
{
    public interface IHitButton
    {
        public IObservable<Unit> OnClick { get; }
    }
}