namespace TechnicalAssesment
{
    public enum GameResult
    {
        DealerWon,
        PlayerWon,
        Tie,
    }

    public class ScoreBoard
    {
        public byte PlayerWins { get; set; }
        public int DealerWins { get; set; }
        public byte Ties { get; set; }
    }

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

    public class Game
    {
        private readonly ScoreBoard _scoreBoard;
        private Deck _deck = default!;

        private int _dealerCard;
        private int _playerCard;

        public Game()
        {
            _scoreBoard = new ScoreBoard();
        }

        public void Play(int numGames)
        {
            _deck = new Deck();

            ShuffleDeck();

            while (--numGames >= 0)
            {
                DealCards();
                GameResult result = DetermineResult();
                switch (result)
                {
                    case GameResult.DealerWon:
                        _scoreBoard.DealerWins++;
                        Console.WriteLine($"{numGames}: Dealer");

                        break;

                    case GameResult.PlayerWon:
                        _scoreBoard.PlayerWins++;
                        Console.WriteLine($"{numGames}: Player");
                        break;

                    case GameResult.Tie:
                        _scoreBoard.Ties++;
                        Console.WriteLine($"{numGames}: Tie");
                        break;
                }

            }

            Console.WriteLine($"RESULTS\n\tDealerWins: {_scoreBoard.DealerWins}\n\tPlayerWins: {_scoreBoard.PlayerWins}\n\tTies: {_scoreBoard.Ties}\n");
        }

        private void ShuffleDeck()
        {
            _deck.Shuffle();
        }

        private void DealCards()
        {
            _playerCard = _deck.DrawCard();
            _dealerCard = _deck.DrawCard();           
        }

        private GameResult DetermineResult()
        {
            return Deck.DetermineWinResult(_playerCard, _dealerCard);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.Play(1000);
        }
    }
}
