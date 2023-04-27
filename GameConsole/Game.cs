namespace GameConsole;

public static class Writer
{
    private static Action<string> _action;  
        
    public static void Write(string message)
    {
        _action(message);
    }

    public static void SetWriter(Action<string> action)
    {
        _action = action;
    }
}

public enum Choice
{
  Paper,
  Rock,
  Scissors
}

public static class ChoiceComparator
{
  private static Dictionary<Choice, List<Choice>> Beats = new()
  {
    { Choice.Paper, new List<Choice>() { Choice.Rock } },
    { Choice.Rock, new List<Choice>() { Choice.Scissors } },
    { Choice.Scissors, new List<Choice>() { Choice.Paper } },
  };
  
  internal static int CompareChoices(Choice p1, Choice p2)
  {
    if (p1 == p2)
      return 0;

    if (Beats[p1].Contains(p2))
      return 1;

    return -1;
  }
}


public class Game
{
  internal int roundsPlayed;    // Number of rounds played
  internal int draw;

  internal void GameRound(IPlayer p1, IPlayer p2)
  {
    Choice p1Choice;
    Choice p2Choice;
    
    Writer.Write("***** Round: " + roundsPlayed + " *********************\n");
    Writer.Write("Number of Draws: " + draw + "\n");
    p1Choice = p1.playerChoice();
    Writer.Write("Player 1: " + p1Choice + "\t Player 1 Total Wins: " + p1.getWins());
    p2Choice = p2.playerChoice();
    Writer.Write("Player 2: " + p2Choice + "\t Player 2 Total Wins: " + p2.getWins());


    switch (ChoiceComparator.CompareChoices(p1Choice, p2Choice))
    {
      case -1:
      {
        p2.setWins();
        Writer.Write("Player 2 Wins");
        break;
      }
      case 0:
      {
        draw++;
        Writer.Write("\n\t\t\t Draw \n");
        break;
      }
      case 1:
      {
        p1.setWins();
        Writer.Write("Player 1 Wins");
        break;
      }
    }
     
    roundsPlayed++;
  }
  
  public void Play(IPlayer p1, IPlayer p2) {
    bool gameWon = false;
    roundsPlayed = 0;
    draw = 0;
    
    // Game Loop
    do {
      GameRound(p1, p2);
      
      Writer.Write(p1.getWins().ToString());
      if ((p1.getWins() >= 3) || (p2.getWins() >= 3)) {
        gameWon = true;
        Writer.Write("GAME WON");
      }
      Writer.Write("");
    } while (gameWon != true);
  }
}

public interface IPlayer
{
    /**
   * Randomly choose rock, paper, or scissors
   */ 
    Choice playerChoice();
    int setWins();
    int getWins();
}

/**
 *
 */
public class Player : IPlayer
{ 
    public int wins;      // # of wins

    /**
   * Randomly choose rock, paper, or scissors
   */
  public virtual Choice playerChoice()
    => (Choice) new Random().Next(0, 2);
    
  public int setWins() {
    int winTotal = ++wins;
    return winTotal;
  }

  public int getWins() {
    return wins;
  }
}