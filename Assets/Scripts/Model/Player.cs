using BlackJack.Cards;

namespace BlackJack.Model
{
    /// <summary>
    /// プレイヤーのPresenter
    /// </summary>
    public class Player :IPerson
    {
        public PersonType Type { get; private set; }

        private PersonHands m_PersonHands;//手札クラス(Modelのようなもの)
        
        
        public Player(PersonType type)
        {
            Type = type;
            m_PersonHands = new PersonHands();//TODO:引数として渡すようにする
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