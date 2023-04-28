namespace GameConsole;

public class GameScenario
{
    private readonly IRound _round;
    private readonly IChoices _choices;
    private readonly Func<Dictionary<IStrategy, int>, ICollection<IStrategy>> _evaluateWinners;


    public GameScenario(IRound round, IChoices choices, Func<Dictionary<IStrategy, int>, ICollection<IStrategy>> evaluateWinners)
    {
        _evaluateWinners = evaluateWinners;
        _round = round;
        _choices = choices;
    }

    public void Start(params IStrategy[] strategies)
    {
        var roundsPlayed = 0;
        var result = strategies.ToDictionary(strategy => strategy, _ => 0);
        var draws = 0;
        ICollection<IStrategy> gameWinners = Array.Empty<IStrategy>();

        do
        {
            roundsPlayed++;
            Writer.Write("***** Round: " + roundsPlayed + " *********************\n");
            Writer.Write("Number of Draws: " + draws + "\n");

            for (var index = 0; index < strategies.Length; index++)
            {
                Writer.Write($"Player {index + 1} wins {result[strategies[index]]}");
            }

            var winners = _round.Play(_choices, strategies);

            foreach (var winner in winners)
            {
                result[winner]++;
            }

            if (!winners.Any())
            {
                draws++;
            }

            gameWinners = _evaluateWinners(result);
        } while (!gameWinners.Any());

        Writer.Write($"Game won by {string.Join(", ", gameWinners.Select(winner => $"player {Array.IndexOf(strategies, winner) + 1}"))}");
    }
}