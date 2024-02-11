using System.Collections.Generic;
using BlackJack.Cards;
using System.Linq;
namespace BlackJack.Model
{
    /// <summary>
    /// 手札データを制御するクラス
    /// </summary>
    /// 
    /// MEMO:Presenterが依存しているクラス　ViewのカードではなくModelのカードを制御
    public class PersonHands
    {
        private List<Card> m_Hands = new List<Card>();

        public PersonHands()
        {
            
        }
        
        /// <summary>
        /// カードの合計を取得
        /// </summary>
        /// <returns></returns>
        public int GetTotalPoint()
        {
            int total = 0;
            foreach (var card in m_Hands)
            {
                int num = card.Number;
                
                if (num == 1)
                {
                    num = CheckAce(total);
                }else if (num >= 10)
                {
                    num = 10;
                }
                
                total += num;
            }

            return total;
        }

        private int CheckAce(int nowTotal)
        {
            int result = 1;
            if ((nowTotal + 11) <= Consts.TOTAL_MAX)//11足しても21を超えないなら11になる
            {
                result = 11;
            }
            return result;
        }
        
        
        /// <summary>
        /// 手札を全て取得(読み取り専用)
        /// </summary>
        /// <returns></returns>
        public IReadOnlyCollection<Card> GetHandCards()
        {
            return m_Hands;
        }
        /// <summary>
        /// 手札にカードを加える
        /// </summary>
        /// <param name="_Card"></param>
        public int AddHandCard(Card _Card)
        {
            m_Hands.Add(_Card);
            return GetTotalPoint();
        }
        /// <summary>
        /// 手札からカードを削除する 指定したカードがない場合は-1が返される
        /// </summary>
        /// <param name="_Card"></param>
        public int RemoveHandCard(Card _Card)
        {
            int index = FindHandCardIndex(_Card);
            
            if (index == -1)
            {
                return -1;
            }
            m_Hands.RemoveAt(index);
            return GetTotalPoint();
        }
        /// <summary>
        /// 手札をリセットする
        /// </summary>
        public int ResetHand()
        {
            m_Hands.Clear();
            return 0;
        }

        /// <summary>
        /// 指定したカードの手札の配列番号を返す ない場合は-1を返す
        /// </summary>
        /// <param name="_Card"></param>
        /// <returns></returns>
        private int FindHandCardIndex(Card _Card)
        {
            for (int i = 0; i < m_Hands.Count; i++)
            {
                if (_Card == m_Hands[i])
                {
                    return i;
                }                
            }
            return -1;
        }
        
    }
}