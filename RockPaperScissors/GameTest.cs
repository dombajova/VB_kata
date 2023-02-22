namespace RockPaperScissors;
using Xunit;

public class GameTest
{
    [Fact]
    public void Game_AnyPlayerWins()
    {
        var game = new Game();
        var someoneHasOneWon = false;
        var task = Task.Run(() => game.Play());
        if (task.Wait(TimeSpan.FromSeconds(10)))
            someoneHasOneWon = true;
        
        Assert.False(someoneHasOneWon);
    }
}