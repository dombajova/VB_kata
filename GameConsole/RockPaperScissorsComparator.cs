namespace GameConsole;

public class RockPaperScissorsComparator : IComparer<string>
{
    private static Dictionary<string, List<string>> Beats = new()
    {
        { RockPaperScissorsChoices.Paper, new List<string>() { RockPaperScissorsChoices.Rock } },
        { RockPaperScissorsChoices.Rock, new List<string>() { RockPaperScissorsChoices.Scissors } },
        { RockPaperScissorsChoices.Scissors, new List<string>() { RockPaperScissorsChoices.Paper } },
    };

    public int Compare(string? p1, string? p2)
    {
        if (p1 == p2)
            return 0;

        if (Beats[p1].Contains(p2))
            return 1;

        return -1;
    }
}

public class RockPaperScissorsLizardSpockComparator : IComparer<string>
{
    private static Dictionary<string, List<string>> Beats = new()
    {
        { RockPaperScissorsLizardSpockChoices.Paper, new List<string>() { RockPaperScissorsLizardSpockChoices.Rock, RockPaperScissorsLizardSpockChoices.Spock } },
        { RockPaperScissorsLizardSpockChoices.Rock, new List<string>() { RockPaperScissorsLizardSpockChoices.Scissors, RockPaperScissorsLizardSpockChoices.Lizard } },
        { RockPaperScissorsLizardSpockChoices.Scissors, new List<string>() { RockPaperScissorsLizardSpockChoices.Paper, RockPaperScissorsLizardSpockChoices.Lizard } },
        { RockPaperScissorsLizardSpockChoices.Lizard, new List<string>() { RockPaperScissorsLizardSpockChoices.Paper, RockPaperScissorsLizardSpockChoices.Spock } },
        { RockPaperScissorsLizardSpockChoices.Spock, new List<string>() { RockPaperScissorsLizardSpockChoices.Rock, RockPaperScissorsLizardSpockChoices.Scissors } },
    };

    public int Compare(string? p1, string? p2)
    {
        if (p1 == p2)
            return 0;

        if (Beats[p1].Contains(p2))
            return 1;

        return -1;
    }
}