

using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UniRx;

namespace BlackJack.Input
{
    public class KeyBoardInput:IBlackjackInput,IDisposable
    {
        public Action BetUp { get; set; }
        public Action BetDown { get; set; }
        public Action BetMax { get; set; }
        public Action Stand { get; set; }
        public Action Hit { get; set; }

        private InputAction m_BetUp;
        private InputAction m_BetDown;
        private InputAction m_BetMax;
        private InputAction m_Stand;
        private InputAction m_Hit;
        
        public KeyBoardInput(InputActionAsset _inputActionAsset)
        {
            m_BetUp = _inputActionAsset.actionMaps[0].FindAction("BetUp");
            if (m_BetUp == null) Debug.LogError("BetUp is Null");
            
            m_BetDown = _inputActionAsset.actionMaps[0].FindAction("BetDown");
            if (m_BetDown == null) Debug.LogError("BetDown is Null");
            
            m_BetMax = _inputActionAsset.actionMaps[0].FindAction("BetMax");
            if (m_BetMax == null) Debug.LogError("BetMax is Null");
            
            m_Stand = _inputActionAsset.actionMaps[0].FindAction("Stand");
            if (m_Stand == null) Debug.LogError("Stand is Null");
            
            m_Hit = _inputActionAsset.actionMaps[0].FindAction("Hit");
            if (m_Hit == null) Debug.LogError("Hit is Null");
            
            m_BetUp?.Enable();
            m_BetDown?.Enable();
            m_BetMax?.Enable();
            m_Stand?.Enable();
            m_Hit?.Enable();

            m_BetUp?.AsObservable().Subscribe(_ => BetUp?.Invoke());
            m_BetDown?.AsObservable().Subscribe(_ => BetDown?.Invoke());
            m_BetMax?.AsObservable().Subscribe(_ => BetMax?.Invoke());
            m_Stand?.AsObservable().Subscribe(_ => Stand?.Invoke());
            m_Hit?.AsObservable().Subscribe(_ => Hit?.Invoke());
        }


        public void Dispose()
        {
            m_BetUp?.Dispose();
            m_BetDown?.Dispose();
            m_BetMax?.Dispose();
            m_Stand?.Dispose();
            m_Hit?.Dispose();
        }
    }
}