using UnityEngine;
using System;
using System.Collections;
namespace BlackJack.Card
{
    [RequireComponent(typeof(MeshRenderer))]
    public class CardView : MonoBehaviour,ICardView
    {
        [SerializeField]
        private MeshRenderer m_MeshRenderer;
        private void Awake()
        {
            if (m_MeshRenderer == null)
            {
                m_MeshRenderer = GetComponent<MeshRenderer>();
            }            
        }
        public void ChangeCardMaterial(Material _material)
        {
            Material[] mats = m_MeshRenderer.materials;
            mats = Array.Empty<Material>();
            mats[0] = _material;
            m_MeshRenderer.materials = mats;
        }
    }
}