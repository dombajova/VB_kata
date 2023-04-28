using NSubstitute.Extensions;

namespace GameConsole;

public class GameTest
{
    [Fact]
    public void Game_AnyPlayerWins()
    {
        Writer.SetWriter(Console.WriteLine);

        var game = new RockPaperScissorsGame();
        var someoneHasOneWon = false;
        var p1 = new RandomStrategy();
        var p2 = new RandomStrategy();
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

        var game = new RockPaperScissorsGame();
        var p1 = new RandomStrategy();
        var p2 = new RandomStrategy();
        game.Play(p1, p2);

        outputs.Should().NotBeEmpty();
        outputs.Last().Should().Contain("Game won by player");
    }

    [Fact]
    public void Game_Player2Wins()
    {
        List<string> outputs = new List<string>();

        Writer.SetWriter(message => outputs.Add(message));

        var game = new RockPaperScissorsGame();
        var p1 = Substitute.For<IStrategy>();
        p1.MakeChoice(Arg.Any<IChoices>()).Returns(RockPaperScissorsChoices.Rock);

        var p2 = Substitute.For<IStrategy>();
        p2.MakeChoice(Arg.Any<IChoices>()).Returns(RockPaperScissorsChoices.Paper);
        game.Play(p1, p2);

        outputs.Should().Contain("Player 2 wins the round");
    }

    [Theory]
    [InlineData(RockPaperScissorsChoices.Paper, RockPaperScissorsChoices.Paper, 0)]
    [InlineData(RockPaperScissorsChoices.Paper, RockPaperScissorsChoices.Rock, 1)]
    [InlineData(RockPaperScissorsChoices.Paper, RockPaperScissorsChoices.Scissors, -1)]
    [InlineData(RockPaperScissorsChoices.Rock, RockPaperScissorsChoices.Paper, -1)]
    [InlineData(RockPaperScissorsChoices.Rock, RockPaperScissorsChoices.Rock, 0)]
    [InlineData(RockPaperScissorsChoices.Rock, RockPaperScissorsChoices.Scissors, 1)]
    [InlineData(RockPaperScissorsChoices.Scissors, RockPaperScissorsChoices.Paper, 1)]
    [InlineData(RockPaperScissorsChoices.Scissors, RockPaperScissorsChoices.Rock, -1)]
    [InlineData(RockPaperScissorsChoices.Scissors, RockPaperScissorsChoices.Scissors, 0)]
    public void ComparePlayersChoices(
        string p1Choice,
        string p2Choice,
        int expectedResult)
    {
        var comparator = new RockPaperScissorsComparator();
        var roundResult = comparator.Compare(p1Choice, p2Choice);

        roundResult.Should().Be(expectedResult);
    }
    
    [Fact]
    public void GameRound_Player2Wins()
    {
        List<string> outputs = new List<string>();

        Writer.SetWriter(message => outputs.Add(message));

        var comparator = new RockPaperScissorsComparator();
        var round = new TwoPlayerRound(comparator);

        var p1 = Substitute.For<IStrategy>();
        p1.MakeChoice(Arg.Any<IChoices>()).Returns(RockPaperScissorsChoices.Rock);

        var p2 = Substitute.For<IStrategy>();
        p2.MakeChoice(Arg.Any<IChoices>()).Returns(RockPaperScissorsChoices.Paper);

        var result = round.Play(new RockPaperScissorsChoices(), p1, p2);

        result.Should().Contain(p2);
        result.Should().NotContain(p1);
    }
    
    [Fact]
    public void GameRound_Player1Wins()
    {
        List<string> outputs = new List<string>();

        Writer.SetWriter(message => outputs.Add(message));

        var comparator = new RockPaperScissorsComparator();
        var round = new TwoPlayerRound(comparator);

        var p1 = Substitute.For<IStrategy>();
        p1.MakeChoice(Arg.Any<IChoices>()).Returns(RockPaperScissorsChoices.Scissors);

        var p2 = Substitute.For<IStrategy>();
        p2.MakeChoice(Arg.Any<IChoices>()).Returns(RockPaperScissorsChoices.Paper);

        var result = round.Play(new RockPaperScissorsChoices(), p1, p2);

        result.Should().Contain(p1);
        result.Should().NotContain(p2);
    }
    
    [Fact]
    public void GameRound_Draw()
    {
        List<string> outputs = new List<string>();

        Writer.SetWriter(message => outputs.Add(message));

        var comparator = new RockPaperScissorsComparator();
        var round = new TwoPlayerRound(comparator);

        var p1 = Substitute.For<IStrategy>();
        p1.MakeChoice(Arg.Any<IChoices>()).Returns(RockPaperScissorsChoices.Scissors);

        var p2 = Substitute.For<IStrategy>();
        p2.MakeChoice(Arg.Any<IChoices>()).Returns(RockPaperScissorsChoices.Scissors);

        var result = round.Play(new RockPaperScissorsChoices(), p1, p2);

        result.Should().BeEmpty();
    }
}