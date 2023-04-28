namespace GameConsole;

public interface IRound
{
    IEnumerable<IStrategy> Play(IChoices choices, params IStrategy[] strategies);
}

public class TwoPlayerRound : IRound
{
    private readonly IComparer<string> _comparer;

    public TwoPlayerRound(IComparer<string> comparer)
    {
        _comparer = comparer;
    }

    public IEnumerable<IStrategy> Play(IChoices choices, params IStrategy[] strategies)
    {
        if (strategies.Length != 2)
            throw new Exception("Generic exception: An error occured.");

        var strategiesChoices = strategies.Select(strategy => strategy.MakeChoice(choices)).ToArray();

        for (var index = 0; index < strategiesChoices.Length; index++)
        {
            Writer.Write($"Player {index + 1}: {strategiesChoices[index]}");
        }

        var result = _comparer.Compare(strategiesChoices[0], strategiesChoices[1]);

        if (result == 1)
        {
            Writer.Write("Player 1 wins the round");
            return new[] { strategies[0] };
        }

        if (result == -1)
        {
            Writer.Write("Player 2 wins the round");
            return new[] { strategies[1] };
        }


        Writer.Write("Nobody wins the round");
        return Array.Empty<IStrategy>();
    }
}