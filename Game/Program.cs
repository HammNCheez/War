// See https://aka.ms/new-console-template for more information
using War.Game;

#region Read In Player Cards
var p1Cards = CardUtil.ReadInCards("p1.dat");

var p2Cards = CardUtil.ReadInCards("p2.dat");
#endregion

//verify both players are starting with 26 cards

var game = new Game(p1Cards, p2Cards);

do
{
  game.Play(new List<Card>(), new List<Card>());
} while (game.InProgress);

if (game.p1Cards.Any())
{
  Console.WriteLine("Player 1 Wins!!!");
}
else
{
  Console.WriteLine("Player 2 Wins!!!");
}