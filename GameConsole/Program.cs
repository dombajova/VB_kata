// See https://aka.ms/new-console-template for more information
using GameConsole;

var game = new Game();
Writer.SetWriter(Console.WriteLine);
Player p1 = new Player();
Player p2 = new Player();
game.Play(p1, p2);