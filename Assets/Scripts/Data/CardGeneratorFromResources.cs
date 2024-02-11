using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using BlackJack;
using BlackJack.Cards;
using UniRx;
using Cysharp.Threading.Tasks;
using UnityEditor.VersionControl;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Data
{
    public class CardGeneratorFromResources: ICardGenerator
    {
        private List<Card> m_Cards = new List<Card>();
        private Dictionary<Card, Material> m_MaterialDict = new Dictionary<Card, Material>();
        private CardView m_CardView = null;
        
        private const int CARD_MAX = 13;

        private ReactiveProperty<LoadStateType> m_LoadState = new ReactiveProperty<LoadStateType>(LoadStateType.NONE);

        private ReactiveProperty<float> m_LoadProgressRate = new ReactiveProperty<float>(0);
        public IReadOnlyDictionary<Card, Material> MaterialDict => m_MaterialDict;
        public IReadOnlyCollection<Card> Cards => m_Cards;

        public IObservable<LoadStateType> LoadStateEvent => m_LoadState.SkipLatestValueOnSubscribe();
        
        public CardView CardView => m_CardView;
        
        

        public async UniTask<bool> Load()
        {
            m_LoadState.Value = LoadStateType.LOADING;
            bool successLoad = false;
            int backColorKind = Random.Range(0, AssetConsts.CARD_COLORS.Length);
            
            successLoad = GenerateCardData();
            if (successLoad) successLoad = await LoadCardObjectAsync(backColorKind);
            if (successLoad) successLoad = await LoadCardMaterialsAsync(backColorKind);

            if (successLoad)
            {
                m_LoadState.Value = LoadStateType.LOADED;
            }
            else
            {
                m_LoadState.Value = LoadStateType.LOAD_ERROR;
            }
            
            return successLoad;
        }

        private async UniTask<bool> LoadCardMaterialsAsync(int _backColorKind)
        {
            string backColor = AssetConsts.CARD_COLORS[_backColorKind];
            
            string basePath = AssetConsts.CARD_BASE_MATERIAL_PATH
                .Replace("{0}",backColor);
            string baseName = AssetConsts.CARD_BASE_MATERIAL_NAME
                .Replace("{0}", backColor);
            
            for (int cardType = 0; cardType < Common.GetEnumCount<CardType>(); cardType++)
            {
                for (int i = 0; i < CARD_MAX; i++)
                {
                    string matName = baseName;
                    matName = matName.Replace("{1}", AssetConsts.CARD_KIND_NAMES[cardType] + (i + 1).ToString("00"));
                    var request = Resources.LoadAsync<Material>($"{basePath}{matName}");
                    await request;
                    Material material = request.asset as Material;
                    
                    if (material == null)
                    {
                        Debug.LogError("LoadCardMaterial: Material is Null");
                        return false;
                    }

                    Card targetCard = m_Cards[CARD_MAX * cardType + i];
                    
                    Debug.Log($"LoadCardMaterial: Key {targetCard.Type} {targetCard.Number} Value:{material.name}");
                    m_MaterialDict.Add(targetCard,material);
                }
            }
            Debug.Log("LoadCardMaterial: Loaded Success");
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
            m_CardView = obj.GetComponent<CardView>();
            
            if (m_CardView == null)
            {
                Debug.LogError("LoadCardObject: Object is Null");
                return false;
            }
            Debug.Log("LoadCardObject: Loaded Success " + m_CardView.name);
            return true;
        }

        private bool GenerateCardData()
        {
            for (int cardType = 0; cardType < Common.GetEnumCount<CardType>(); cardType++)
            {
                for (int i = 0; i < CARD_MAX; i++)
                {
                    Card card = new Card(i + 1, (CardType)cardType);
                    Debug.Log($"GeneratedCard:Num:{card.Number} Type:{card.Type}");
                    m_Cards.Add(card);
                }
            }
            Debug.Log("CardData: Generated Success");
            return true;
        }
    }
}