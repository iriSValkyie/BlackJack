using System;
using System.Collections;
using System.Collections.Generic;

namespace BlackJack
{
    public static class Common
    {
        public static int GetEnumCount<T>()
        {
            return Enum.GetValues(typeof(T)).Length;
        }
    }
}