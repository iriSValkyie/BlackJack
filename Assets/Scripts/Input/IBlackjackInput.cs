using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BlackJack.Input
{
    public interface IBlackjackInput
    {
        public Action BetUp { get; set; }
        
        public Action BetDown { get; set; }
        
        public Action BetMax { get; set; }
        
        public Action Stand { get; set; }
        
        public Action Hit { get; set; }
    }
}