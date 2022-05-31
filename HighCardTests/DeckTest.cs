using HighCard;

namespace HighCardTests;

public class DeckTest
{
    [Fact]
    public void ShuffleDeck_WhenDeckIsNotEmpty_ShouldReturnShuffledDeck()
    {
        // Arrange
        Deck deckOne = new();
        Deck dedkTwo = new();

        // ACT
        dedkTwo.Shuffle();

        // Assert
        Assert.NotEqual(deckOne.DrawCard(), dedkTwo.DrawCard());
    }

    [Fact]
    public void DrawCard_WhenDeckIsNotEmpty_ShouldReturnValidFaceValue()
    {
        // Arrange
        Deck deck = new();

        // ACT
        deck.Shuffle();
        int faceValue = deck.DrawCard();

        // Assert
        Assert.InRange(faceValue, 0, 13);
    }

    [Fact]
    public void DetermineResult_WhenPlayerDrawsCardWithGreaterFaceValueThanDealers_ReturnsPlayerWon()
    {
        // Arrange
        int playerCardFaceValue = 10;
        int dealerCardFaceValue = 5;

        // Act
        GameResult result = Deck.DetermineWinResult(playerCardFaceValue, dealerCardFaceValue);

        // Assert
        Assert.Equal(GameResult.PlayerWon, result);
    }

    [Fact]
    public void DetermineResult_WhenDealerDrawsCardWithGreaterFaceValueThanPlayers_ReturnsDealerWon()
    {
        // Arrange
        int playerCardFaceValue = 5;
        int dealerCardFaceValue = 10;

        // Act
        GameResult result = Deck.DetermineWinResult(playerCardFaceValue, dealerCardFaceValue);

        // Assert
        Assert.Equal(GameResult.DealerWon, result);
    }

    [Fact]
    public void DetermineResult_WhenPlayerAndDealerDrawCardsWithTheSameFaceValue_ReturnsTie()
    {
        // Arrange
        int playerCardFaceValue = 5;
        int dealerCardFaceValue = 5;

        // Act
        GameResult result = Deck.DetermineWinResult(playerCardFaceValue, dealerCardFaceValue);

        // Assert
        Assert.Equal(GameResult.Tie, result);
    }


    [Fact]
    public void DetermineResult_WhenPlayerDrawsWildCardAndDealerDoesNot_ReturnsPlayerWon()
    {
        // Arrange
        int playerCardFaceValue = 2;
        int dealerCardFaceValue = 10;

        // Act
        GameResult result = Deck.DetermineWinResult(playerCardFaceValue, dealerCardFaceValue);

        // Assert
        Assert.Equal(GameResult.PlayerWon, result);
    }

    [Fact]
    public void DetermineResult_WhenDealerDrawsWildCardAndPlayerDoesNot_ReturnsDealerWon()
    {
        // Arrange
        int playerCardFaceValue = 10;
        int dealerCardFaceValue = 2;

        // Act
        GameResult result = Deck.DetermineWinResult(playerCardFaceValue, dealerCardFaceValue);

        // Assert
        Assert.Equal(GameResult.DealerWon, result);
    }

    [Fact]
    public void DetermineResult_WhenBothDealerAndPlayerDrawTheSameWildCard_ReturnsTie()
    {
        // Arrange
        int playerCardFaceValue = 2;
        int dealerCardFaceValue = 2;

        // Act
        GameResult result = Deck.DetermineWinResult(playerCardFaceValue, dealerCardFaceValue);

        // Assert
        Assert.Equal(GameResult.Tie, result);
    }

    [Fact]
    public void DetermineResult_WhenBothPlayerAndDealerDrawWildCardButPlayersIsGreaterFaceValue_ReturnsPlayerWon()
    {
        // Arrange
        int playerCardFaceValue = 8;
        int dealerCardFaceValue = 2;

        // Act
        GameResult result = Deck.DetermineWinResult(playerCardFaceValue, dealerCardFaceValue);

        // Assert
        Assert.Equal(GameResult.PlayerWon, result);
    }

    [Fact]
    public void DetermineResult_WhenBothPlayerAndDealerDrawWildCardButDealersIsGreaterFaceValue_ReturnsDealerWon()
    {
        // Arrange
        int playerCardFaceValue = 2;
        int dealerCardFaceValue = 8;

        // Act
        GameResult result = Deck.DetermineWinResult(playerCardFaceValue, dealerCardFaceValue);

        // Assert
        Assert.Equal(GameResult.DealerWon, result);
    }
}
