using System;
using UniRx;

namespace BlackJack.Tests
{
    public interface IStandButton
    {
        public IObservable<Unit> OnClick { get; }
    }
}