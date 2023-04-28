namespace GameConsole;

public class RockPaperScissorsLizardSpockGame
{
    private readonly GameScenario _gameScenario;

    public RockPaperScissorsLizardSpockGame()
    {
        var comparer = new RockPaperScissorsLizardSpockComparator();

        var twoPlayerRound = new TwoPlayerRound(comparer);

        _gameScenario = new GameScenario(
            twoPlayerRound,
            new RockPaperScissorsLizardSpockChoices(),
            results => results.Where(scenario => scenario.Value >= 3).Select(result => result.Key).ToArray());
    }

    public void Play(IStrategy strategy1, IStrategy strategy2)
    {
        _gameScenario.Start(strategy1, strategy2);
    }
}