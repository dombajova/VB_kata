namespace GameConsole;

public interface IChoices
{
    IEnumerable<string> GetAll();
}

public class RockPaperScissorsChoices : IChoices
{
    public const string Rock = "Rock";
    public const string Paper = "Paper";
    public const string Scissors = "Scissors";

    public IEnumerable<string> GetAll()
    {
        yield return Paper;
        yield return Rock;
        yield return Scissors;
    }
}

public class RockPaperScissorsLizardSpockChoices : IChoices
{
    public const string Rock = "Rock";
    public const string Paper = "Paper";
    public const string Scissors = "Scissors";
    public const string Lizard = "Lizard";
    public const string Spock = "Spock";

    public IEnumerable<string> GetAll()
    {
        yield return Paper;
        yield return Rock;
        yield return Scissors;
        yield return Lizard;
        yield return Spock;
    }
}