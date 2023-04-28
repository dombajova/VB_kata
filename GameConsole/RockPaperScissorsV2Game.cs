namespace GameConsole;

public class RockPaperScissorsV2Game
{
    private readonly GameScenario _gameScenario;

    public RockPaperScissorsV2Game()
    {
        var comparer = new RockPaperScissorsComparator();

        var twoPlayerRound = new TwoPlayerRound(comparer);

        _gameScenario = new GameScenario(
            twoPlayerRound,
            new RockPaperScissorsChoices(),
            results => results
                .Where(scenario => scenario.Value >= 4
                    && results.Except(new []{ scenario}).All(otherScenarios => scenario.Value - otherScenarios.Value >= 2))
                .Select(result => result.Key)
                .ToArray());
    }

    public void Play(IStrategy strategy1, IStrategy strategy2)
    {
        _gameScenario.Start(strategy1, strategy2);
    }
}