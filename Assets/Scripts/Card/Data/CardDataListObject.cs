using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlackJack;
[CreateAssetMenu]
public class CardDataListObject : ScriptableObject
{
    public List<CardData> m_Datas = new List<CardData>();
}
