namespace HighCard
{
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
}
