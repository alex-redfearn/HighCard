using System.Collections.ObjectModel;

namespace HighCard
{
    public class Deck
    {
        private readonly List<int> _cards;
        private static readonly int MAX_CARDS = 52;
        private static readonly ReadOnlyCollection<int> s_wildCards = new List<int> { 2, 8 }.AsReadOnly();

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

        /// <summary>
        /// Fisher-Yates Shuffle
        /// </summary>
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

            return FaceValue(selectedCard);
        }

        private bool CardsEmpty()
        {
            return !_cards.Any();
        }

        private static int FaceValue(int cardIndex)
        {
            return cardIndex % 13;
        }

        /// <summary>
        /// Highest face value wins unless one player has drawn a wild card.
        /// If both are wild cards the highest face value wins.
        /// </summary>
        /// <param name="playerCardFaceValue"></param>
        /// <param name="dealerCardFaceValue"></param>
        /// <returns>Result of the game as defined in summary</returns>
        public static GameResult DetermineWinResult(int playerCardFaceValue, int dealerCardFaceValue)
        {
            if (s_wildCards.Contains(playerCardFaceValue) && !s_wildCards.Contains(dealerCardFaceValue))
            {
                return GameResult.PlayerWon;
            }
            else if (s_wildCards.Contains(dealerCardFaceValue) && !s_wildCards.Contains(playerCardFaceValue))
            {
                return GameResult.DealerWon;
            }
            else if (playerCardFaceValue > dealerCardFaceValue)
            {
                return GameResult.PlayerWon;
            }
            else if (playerCardFaceValue < dealerCardFaceValue)
            {
                return GameResult.DealerWon;
            }
            else return GameResult.Tie;
        }
    }
}
