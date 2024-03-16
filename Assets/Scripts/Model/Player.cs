using BlackJack.Cards;
using BlackJack.Input;
using BlackJack.UI;
using VContainer;

namespace BlackJack.Model
{
    /// <summary>
    /// プレイヤーのPresenter
    /// </summary>
    public class Player :IPerson
    {
        public PersonType Type { get; private set; }

        [Inject]
        private PersonHands m_PersonHands;//手札クラス(Modelのようなもの)

        private IScoreViewItem m_PlayerScore;


        public Player(PersonType type, PersonHands _personHands)
        {
            Type = type;
            m_PersonHands = _personHands;
        }
        [Inject] 
        public void Construct(IScoreViewItem _scoreView)
        {
            m_PlayerScore = _scoreView;
            m_PlayerScore.SetScore(PersonType.PLAYER);
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