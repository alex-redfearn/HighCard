namespace HighCard
{
    public class Deck
    {
        private readonly List<int> _cards;
        private static readonly int MAX_CARDS = 52;

        public Deck()
        {
            _cards = new List<int>();

            AddCards();
        }

        private void AddCards()
        {
            for (int i = 0; i < MAX_CARDS; i++)
            {
                _cards.Add(i);
            }
        }

        // Fisher-Yates Shuffle
        public void Shuffle()
        {
            Random r = new();

            int n = _cards.Count;
            while (n > 1)
            {
                n--;
                int k = r.Next(n + 1);
                int value = _cards[k];
                _cards[k] = _cards[n];
                _cards[n] = value;
            }
        }

        public int DrawCard()
        {
            if (CardsEmpty())
            {
                AddCards();
                Shuffle();
            }

            int index = _cards.Count - 1;
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
