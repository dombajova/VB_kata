// See https://aka.ms/new-console-template for more information

namespace GameConsole;

public static class Program
{
    public static void Main(params string[] args)
    {
        Writer.SetWriter(Console.WriteLine);

        var strategy1 = new RandomStrategy();
        var strategy2 = new LizardStrategy();
        //var game = new RockPaperScissorsGame();
        // var game = new RockPaperScissorsV2Game();
        var game = new RockPaperScissorsLizardSpockGame();

        game.Play(strategy1, strategy2);
    }
}