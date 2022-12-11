using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlackJack;
public class CardGenerator : MonoBehaviour
{
    [SerializeField] GameObject m_CardPrefab;
    [SerializeField] CardDataManager m_cardDataManager;
    [SerializeField] List<GameObject> m_PoolCards = new List<GameObject>();
    [SerializeField] int m_poolMax;
    // Start is called before the first frame update
    void Awake()
    {
        Generate();
    }
    void Generate()
    {
        for (int i = 0; i < m_poolMax; i++)
        {
            GameObject prefab = Instantiate(m_CardPrefab, Vector3.zero, Quaternion.identity, transform);
            prefab.SetActive(false);
            m_PoolCards.Add(prefab);

        }
    }

    GameObject FindStandingObject()
    {
        foreach(GameObject card in m_PoolCards)
        {
            if(card.activeSelf == false)
            {
                return card;
            }
        }
        Debug.LogError("FindStandingObject:生成可能なオブジェクトがありません");
        return null;
    }


    public void GetCardSpecified(string num,CardType type,CardColor color,Transform parent)
    {
        GameObject card = FindStandingObject();
        if (card)
        {
            card.transform.SetParent(parent);
            card.SetActive(true);
            card.GetComponent<CardBehaviour>().GenerateCard(num, type, color);
        }
        
    }
    public void GetCard(Transform parent)
    {
        GameObject card = FindStandingObject();
        if (card)
        {
            CardData randomCardData = m_cardDataManager.GetCardDataRandom();
            card.transform.SetParent(parent);
            card.SetActive(true);
            card.GetComponent<CardBehaviour>().GenerateCard(randomCardData.Number, randomCardData.Type, randomCardData.Color);
        }
    }
}
