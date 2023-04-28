namespace GameConsole;

public class RockPaperScissorsGame
{
    private readonly GameScenario _gameScenario;

    public RockPaperScissorsGame()
    {
        var comparer = new RockPaperScissorsComparator();

        var twoPlayerRound = new TwoPlayerRound(comparer);

        _gameScenario = new GameScenario(
            twoPlayerRound,
            new RockPaperScissorsChoices(),
            results => results.Where(scenario => scenario.Value >= 3).Select(result => result.Key).ToArray());
    }

    public void Play(IStrategy strategy1, IStrategy strategy2)
    {
        _gameScenario.Start(strategy1, strategy2);
    }
}