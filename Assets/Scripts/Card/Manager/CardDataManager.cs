using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlackJack;
public class CardDataManager : MonoBehaviour
{
    [SerializeField] CardDataListObject m_CardsData;

    [SerializeField] List<CardData> cardDecks = new List<CardData>();

    private void Start()
    {
        DebugDeckNum();
        InitCardDecks();
    }
    void DebugDeckNum()
    {
        int spadeNum = 0;
        int heartNum = 0;
        int diaNum = 0;
        int clubNum = 0;
        foreach (CardData data in m_CardsData.m_Datas)
        {
            switch (data.Type)
            {
                case CardType.Spade:
                    if (data.Color == CardColor.Black)
                    {
                        spadeNum += 1;
                    }
                    break;
                case CardType.Heart:
                    if (data.Color == CardColor.Red)
                    {
                        heartNum += 1;
                    }
                    break;
                case CardType.Diamond:
                    if (data.Color == CardColor.Red)
                    {
                        diaNum += 1;
                    }
                    break;
                case CardType.Club:
                    if (data.Color == CardColor.Black)
                    {
                        clubNum += 1;
                    }
                    break;
            }

           
        }
        Debug.Log($"♠:{spadeNum},♥:{heartNum},♦:{diaNum},♣:{clubNum}");

    }
    void InitCardDecks()
    {
        foreach (CardData data in m_CardsData.m_Datas)
        {
            cardDecks.Add(data);
        }
    }

    public CardData GetCardDataRandom()
    {
        int random = Random.Range(0, 52);
        CardData data = cardDecks[random];
        cardDecks.RemoveAt(random);
        Debug.Log($"デッキ枚数:{cardDecks.Count}枚");
        return data;
    }
}
