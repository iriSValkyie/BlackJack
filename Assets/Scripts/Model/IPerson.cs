using BlackJack.Cards;

namespace BlackJack.Model
{
    public interface IPerson
    {
        //MEMO:PresenterなのでViewもModelも制御できる関数にする
        public PersonType Type { get;}
        public int AddHand(Card _Card);

        public int RemoveHand(Card _Card);

        public int ResetHand();

    }
}