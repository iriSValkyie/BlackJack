using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using BlackJack;
using BlackJack.Card;
using BlackJack.Consts;
using UniRx;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Data
{
    public class CardGeneratorFromResources
    {
        private List<Card> m_Cards = new List<Card>();
        private Dictionary<Card, Material> m_MaterialDict = new Dictionary<Card, Material>();
        private GameObject m_BaseCardObject = null;
        
        private const int CARD_MAX = 13;

        public IReadOnlyDictionary<Card, Material> MaterialDict => m_MaterialDict;
        public IReadOnlyCollection<Card> Cards => m_Cards;
        public async UniTask<bool> Load()
        {
            bool successLoad = false;
            
            successLoad = GenerateCardData();

            if (successLoad) successLoad = await LoadCardObjectAsync();
            
            if (successLoad) successLoad = await LoadCardMaterialsAsync();
            
            return successLoad;
        }

        private async UniTask<bool> LoadCardMaterialsAsync()
        {
            for (int cardType = 0; cardType < (int)CardType.MAX; cardType++)
            {
                for (int i = 0; i < CARD_MAX; i++)
                {
                    var request = Resources.LoadAsync<Material>("");
                    await request;
                    Material material = request.asset as Material;
                    m_MaterialDict.Add(m_Cards[CARD_MAX* cardType + i ],material);
                }
            }
            return true;
        }

        private async UniTask<bool> LoadCardObjectAsync()
        {
            var request = Resources.LoadAsync<GameObject>("");
            await request;
            GameObject obj = request.asset as GameObject;
            //obj.GetComponent<>();
            return true;
        }

        private bool GenerateCardData()
        {
            for (int cardType = 0; cardType < (int)CardType.MAX ; cardType++)
            {
                for (int i = 0; i < CARD_MAX; i++)
                {
                    Card card = new Card(i + 1, (CardType)cardType);
                    Debug.Log($"GeneratedCard:Num:{card.Number} Type:{card.Type}");
                    m_Cards.Add(card);
                }
            }
            return true;
        }
    }
}