namespace GameConsole;

public interface IStrategy
{
    string MakeChoice(IChoices choices);
}


public class RandomStrategy : IStrategy
{
    public string MakeChoice(IChoices choices)
    {
        var availableChoices = choices.GetAll().ToArray();
        return availableChoices[new Random().Next(0, availableChoices.Length)];
    }
}

public class LizardStrategy : IStrategy
{
    public string MakeChoice(IChoices choices)
    {
        var availableChoices = choices.GetAll().ToList();

        if (availableChoices.Any(choice => choice == RockPaperScissorsLizardSpockChoices.Lizard))
        {
            availableChoices.Add(RockPaperScissorsLizardSpockChoices.Lizard);
            availableChoices.Add(RockPaperScissorsLizardSpockChoices.Lizard);
            availableChoices.Add(RockPaperScissorsLizardSpockChoices.Lizard);
            availableChoices.Add(RockPaperScissorsLizardSpockChoices.Lizard);
            availableChoices.Add(RockPaperScissorsLizardSpockChoices.Lizard);
            availableChoices.Add(RockPaperScissorsLizardSpockChoices.Lizard);
            availableChoices.Add(RockPaperScissorsLizardSpockChoices.Lizard);
            availableChoices.Add(RockPaperScissorsLizardSpockChoices.Lizard);
        }

        return availableChoices[new Random().Next(0, availableChoices.Count)];
    }
}