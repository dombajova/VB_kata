namespace RockPaperScissors;

public class Game {
  public void Play() {
    Player p1 = new Player();
    Player p2 = new Player();
    bool gameWon = false;
    int roundsPlayed = 0;    // Number of rounds played
    int p1Wins = p1.wins;
    int p2Wins = p2.wins;
    int draw = 0;
    String p1Choice;
    String p2Choice;
    // Game Loop
    do {
     Console.WriteLine("***** Round: " +
          roundsPlayed + " *********************\n");
     Console.WriteLine("Number of Draws: " +
          draw + "\n");
     p1Choice = p1.playerChoice();
     Console.WriteLine("Player 1: " + p1Choice +
          "\t Player 1 Total Wins: " + p1Wins);
     p2Choice = p2.playerChoice();
     Console.WriteLine("Player 2: " + p2Choice +
          "\t Player 2 Total Wins: " + p2Wins);
      if ((p1Choice.Equals("rock")) && (p2Choice.Equals("paper"))) {
       Console.WriteLine("Player 2 Wins");
        p2Wins++;  // trying a couple different ways to get count to work
      } else if ((p1Choice.Equals("paper")) && (p2Choice.Equals("rock"))) {
        p1Wins++;
       Console.WriteLine("Player 1 Wins");
      } else if ((p1Choice.Equals("rock")) && (p2Choice.Equals("scissors"))) {
        p1Wins = p1.setWins();
       Console.WriteLine("Player 1 Wins");
      } else if ((p1Choice.Equals("scissors")) && (p2Choice.Equals("rock"))) {
        p2Wins = p2.setWins();
       Console.WriteLine("Player 2 Wins");
      } else if ((p1Choice.Equals("scissors")) && (p2Choice.Equals("paper"))) {
        p1Wins = p1.setWins();
       Console.WriteLine("Player 1 Wins");
      } else if ((p1Choice.Equals("paper")) && (p2Choice.Equals("scissors"))) {
        p2Wins = p2.setWins();
       Console.WriteLine("Player 2 Wins");
      }
      if (p1Choice == p2Choice) {
        draw++;
       Console.WriteLine("\n\t\t\t Draw \n");
      }
      roundsPlayed++;
      Console.WriteLine(p1.getWins());
      if ((p1.getWins() >= 3) || (p2.getWins() >= 3)) {
        gameWon = true;
       Console.WriteLine("GAME WON");
      }
      Console.WriteLine();
    } while (gameWon != true);
  }
}

/**
 *
 */
class Player { 
    public int wins;      // # of wins
    public int winTotal;

  /**
   * Randomly choose rock, paper, or scissors
   */
  public String playerChoice() {
    String choice = "";
    int c = (int) (new Random().Next(0, 2));
    switch (c) {
      case 0:
        choice = ("rock");
        break;
      case 1:
        choice = ("paper");
        break;
      case 2:
        choice = ("scissors");
        break;
    }
    return choice;
  }

  public int setWins() {
    int winTotal = wins++;
    return winTotal;
  }

  public int getWins() {
    return (wins);
  }
}