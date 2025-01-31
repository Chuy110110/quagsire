namespace Cpsc370Final.Tests;

public class MockConsoleLineRetriever : ConsoleLineRetriever
{
    public string[] lines;
    public int index = 0;

    public MockConsoleLineRetriever(string[] lines)
    {
        this.lines = lines;
    }

    public override string GetNextLine()
    {
        return lines[index++];
    }
}

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
        string[] lines = ["hit", "stand"];
        var mockConsoleLineRetriever = new MockConsoleLineRetriever(lines);
        
        var game = new Game(mockConsoleLineRetriever);
        game.Player.ResetPlayerStateForGame();
        game.DrawCard(); 

        // Mock user input for "hit" followed by "stand"
        // Console.SetIn(new System.IO.StringReader("hit\nstand\n"));

        
        // Act
        game.Play();

        // Assert
        Assert.True(game.RoundOver, "Game should be over after the player stands.");
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