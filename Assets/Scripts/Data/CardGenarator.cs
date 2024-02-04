using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using BlackJack;
using BlackJack.Card;
using BlackJack.Consts;
using UniRx;
using Cysharp.Threading.Tasks;
using UnityEditor.VersionControl;
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
            int backColorKind = Random.Range(0, AssetConsts.CARD_COLORS.Length);
            
            successLoad = GenerateCardData();
            if (successLoad) successLoad = await LoadCardObjectAsync(backColorKind);
            if (successLoad) successLoad = await LoadCardMaterialsAsync(backColorKind);
            
            return successLoad;
        }

        private async UniTask<bool> LoadCardMaterialsAsync(int _backColorKind)
        {
            string backColor = AssetConsts.CARD_COLORS[_backColorKind];
            
            string basePath = AssetConsts.CARD_BASE_MATERIAL_PATH
                .Replace("{0}",backColor);
            string baseName = AssetConsts.CARD_BASE_MATERIAL_NAME
                .Replace("{0}", backColor);
            
            for (int cardType = 0; cardType < (int)CardType.MAX; cardType++)
            {
                for (int i = 0; i < CARD_MAX; i++)
                {
                    string matName = baseName;
                    matName = matName.Replace("{1}", AssetConsts.CARD_KIND_NAMES[cardType] + (i + 1).ToString("00"));
                    var request = Resources.LoadAsync<Material>($"{basePath}{matName}");
                    await request;
                    Material material = request.asset as Material;
                    m_MaterialDict.Add(m_Cards[CARD_MAX* cardType + i ],material);
                }
            }
            return true;
        }

        private async UniTask<bool> LoadCardObjectAsync(int _backColorKind)
        {
            string backColor = AssetConsts.CARD_COLORS[_backColorKind];
            string basePath = AssetConsts.CARD_BASE_PREFAB_PATH
                .Replace("{0}",backColor);
            
            string prefabName = AssetConsts.CARD_BASE_PREFAB_NAME.Replace("{0}",backColor);
            
            var request = Resources.LoadAsync<GameObject>($"{basePath}{prefabName}");
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