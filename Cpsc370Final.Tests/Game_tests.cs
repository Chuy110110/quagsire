namespace Cpsc370Final.Tests;

public class Game_tests
{
    [Fact]
    public void Game_DrawCard_IncreasesScore()
    {
        // Arrange
        var game = new Game();
        int initialScore = game.CalculateScore();

        // Act
        game.DrawCard();

        // Assert
        Assert.True(game.CalculateScore() > initialScore, "Player score should increase after drawing a card.");
    }

    [Fact]
    public void Game_HitOrStand_ValidatesUserInputAndHandlesCorrectly()
    {
        // Arrange
        var game = new Game();
        game.Player.ResetPlayerStateForGame();
        game.DrawCard(); 

        // Mock user input for "hit" followed by "stand"
        Console.SetIn(new System.IO.StringReader("hit\nstand\n"));

        // Act
        game.Play();

        // Assert
        Assert.True(game.GameOver, "Game should be over after the player stands.");
    }

    [Fact]
    public void Game_PromptContinue_ReturnsFalseWhenNo()
    {
        // Arrange
        var game = new Game();
        Console.SetIn(new System.IO.StringReader("no"));

        // Act
        var result = game.PromptContinue();

        // Assert
        Assert.False(result, "PromptContinue should return false when the player chooses not to continue.");
    }
}