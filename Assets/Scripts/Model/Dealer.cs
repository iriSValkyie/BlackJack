using BlackJack.Cards;
using BlackJack.UI;
using VContainer;

namespace BlackJack.Model
{
    /// <summary>
    /// ディーラーのPresenter
    /// </summary>
    public class Dealer :IPerson
    {
        public PersonType Type { get; private set; }
        
        private PersonHands m_PersonHands;//手札クラス(Modelのようなもの)
        
        private IScoreViewItem m_DealerScore;
        public Dealer(PersonType type)
        {
            Type = type;
            m_PersonHands = new PersonHands();//TODO:引数として渡すようにする
            
        }

        [Inject]
        public void Construct(IScoreViewItem _scoreView)
        {
            m_DealerScore = _scoreView;
            m_DealerScore.SetScore(PersonType.DEALER);
        }
        

        public int AddHand(Card _Card)
        {
            throw new System.NotImplementedException();
        }

        public int RemoveHand(Card _Card)
        {
            throw new System.NotImplementedException();
        }

        public int ResetHand()
        {
            throw new System.NotImplementedException();
        }
    }
}