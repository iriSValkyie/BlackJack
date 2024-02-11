using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlackJack
{
    public enum CardType
    {
        SPADES  = 0,
        DIAMONDS = 1,
        CLUBS = 2,
        HEARTS = 3,
    }

    public enum LoadStateType
    {
        NONE =0,
        LOADING =1,
        LOADED =2, 
        LOAD_ERROR = 3,
    }
    
    public enum FlowType
    {
        BET = 0,
        DEAL = 1,
        DEALER_HAND_CHECK = 2,
        ACTION = 3,
        DEALER_HAND_OPEN = 4,
        RESULT = 5, 
    }

    public enum PersonType
    {
        PLAYER =0,
        DEALER =1,
    }
    
    
}
