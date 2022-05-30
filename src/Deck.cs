namespace HighCard
{
    public class Deck
    {
        private readonly List<int> _cards;
        private static readonly int MAX_CARDS = 52;

        public Deck()
        {
            _cards = new List<int>();
        }

        public void Shuffle()
        {
            for (int i = 0; i < MAX_CARDS; i++)
            {
                _cards.Add(i);
            }
        }

        public int DrawCard()
        {
            if (CardsEmpty())
            {
                Shuffle();
            }

            Random r = new();
            int index = r.Next(_cards.Count);
            int selectedCard = _cards[index];
            _cards.RemoveAt(index);
            return selectedCard;
        }

        private bool CardsEmpty()
        {
            return !_cards.Any();
        }

        public static GameResult DetermineWinResult(int playerCard, int dealerCard)
        {
            if (playerCard % 13 > dealerCard % 13)
            {
                return GameResult.PlayerWon;
            }
            else if (playerCard % 13 < dealerCard % 13)
            {
                return GameResult.DealerWon;
            }
            else return GameResult.Tie;
        }
    }
}
