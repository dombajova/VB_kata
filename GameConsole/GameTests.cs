using FluentAssertions;
using NSubstitute;
using NSubstitute.Extensions;
using Xunit;

namespace GameConsole;

public class GameTest
{
    [Fact]
    public void Game_AnyPlayerWins()
    {
        Writer.SetWriter(Console.WriteLine);

        var game = new Game();
        var someoneHasOneWon = false;
        Player p1 = new Player();
        Player p2 = new Player();
        var task = Task.Run(() => game.Play(p1, p2));
        if (task.Wait(TimeSpan.FromMilliseconds(10)))
            someoneHasOneWon = true;

        Assert.True(someoneHasOneWon);
    }


    [Fact]
    public void Game_CheckWriterReturns()
    {
        List<string> outputs = new List<string>();

        Writer.SetWriter(message => outputs.Add(message));

        var game = new Game();
        Player p1 = new Player();
        Player p2 = new Player();
        game.Play(p1, p2);

        outputs.Should().NotBeEmpty();
        outputs.Should().Contain("GAME WON");
    }

    [Fact]
    public void Game_Player2Wins()
    {
        List<string> outputs = new List<string>();

        Writer.SetWriter(message => outputs.Add(message));

        var game = new Game();
        Player p1 = Substitute.ForPartsOf<Player>();
        p1.Configure().playerChoice().Returns(Choice.Rock);

        Player p2 = Substitute.ForPartsOf<Player>();
        p2.Configure().playerChoice().Returns(Choice.Paper);
        game.Play(p1, p2);

        outputs.Should().Contain("Player 2 Wins");
    }

    [Theory]
    [InlineData(Choice.Paper, Choice.Paper, 0)]
    [InlineData(Choice.Paper, Choice.Rock, 1)]
    [InlineData(Choice.Paper, Choice.Scissors, -1)]
    [InlineData(Choice.Rock, Choice.Paper, -1)]
    [InlineData(Choice.Rock, Choice.Rock, 0)]
    [InlineData(Choice.Rock, Choice.Scissors, 1)]
    [InlineData(Choice.Scissors, Choice.Paper, 1)]
    [InlineData(Choice.Scissors, Choice.Rock, -1)]
    [InlineData(Choice.Scissors, Choice.Scissors, 0)]
    public void ComparePlayersChoices(
        Choice p1Choice,
        Choice p2Choice,
        int expectedResult)
    {
        var roundResult = ChoiceComparator.CompareChoices(p1Choice, p2Choice);

        roundResult.Should().Be(expectedResult);
    }
    
    [Fact]
    public void GameRound_Player2Wins()
    {
        List<string> outputs = new List<string>();
        Writer.SetWriter(message => outputs.Add(message));
        var game = new Game();
        game.roundsPlayed = 0;
        game.draw = 0;

        Player p1 = Substitute.ForPartsOf<Player>();
        p1.Configure().playerChoice().Returns(Choice.Rock);

        Player p2 = Substitute.ForPartsOf<Player>();
        p2.Configure().playerChoice().Returns(Choice.Paper);
        game.GameRound(p1, p2);

        game.roundsPlayed.Should().Be(1);
        game.draw.Should().Be(0);
        p1.getWins().Should().Be(0);
        p2.getWins().Should().Be(1);
    }
    
    [Fact]
    public void GameRound_Player1Wins()
    {
        List<string> outputs = new List<string>();
        Writer.SetWriter(message => outputs.Add(message));
        var game = new Game();
        game.roundsPlayed = 0;
        game.draw = 0;

        Player p1 = Substitute.ForPartsOf<Player>();
        p1.Configure().playerChoice().Returns(Choice.Scissors);

        Player p2 = Substitute.ForPartsOf<Player>();
        p2.Configure().playerChoice().Returns(Choice.Paper);
        game.GameRound(p1, p2);

        game.roundsPlayed.Should().Be(1);
        game.draw.Should().Be(0);
        p1.getWins().Should().Be(1);
        p2.getWins().Should().Be(0);
    }
    
    [Fact]
    public void GameRound_Draw()
    {
        List<string> outputs = new List<string>();
        Writer.SetWriter(message => outputs.Add(message));
        var game = new Game();
        game.roundsPlayed = 0;
        game.draw = 0;

        Player p1 = Substitute.ForPartsOf<Player>();
        p1.Configure().playerChoice().Returns(Choice.Rock);

        Player p2 = Substitute.ForPartsOf<Player>();
        p2.Configure().playerChoice().Returns(Choice.Rock);
        game.GameRound(p1, p2);

        game.roundsPlayed.Should().Be(1);
        game.draw.Should().Be(1);
        p1.getWins().Should().Be(0);
        p2.getWins().Should().Be(0);
    }
}