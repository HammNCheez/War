namespace War.Game
{
  public class Game
  {
    public List<Card> p1Cards { get; private set; }
    public List<Card> p2Cards { get; private set; }
    public bool InProgress { get; private set; }
    public int Round { get; private set; }


    public Game(List<Card> p1, List<Card> p2)
    {
      Validate.IsNotNullOrEmpty(p1);
      Validate.IsNotNullOrEmpty(p2);

      p1Cards = p1;
      p2Cards = p2;

      Console.WriteLine($"Cards Loaded!");
      Console.WriteLine($"Player 1 has {p1Cards.Count} cards.");
      Console.WriteLine($"Player 2 has {p2Cards.Count} cards.");

      InProgress = true;
      Round = 1;
    }

    public void Play(List<Card> cardsInPlay1, List<Card> cardsInPlay2)
    {
      if (Round % 100 == 0)
      {
        Round = Round;
      }
      var card1 = p1Cards.First();
      var card2 = p2Cards.First();

      p1Cards.RemoveAt(0);
      p2Cards.RemoveAt(0);

      cardsInPlay1.Add(card1);
      cardsInPlay2.Add(card2);

      Console.WriteLine($"Round {Round} - {cardsInPlay1.Count + cardsInPlay2.Count} cards in play.");
      Console.WriteLine($"P1({p1Cards.Count + 1}):{card1} | P2:({p2Cards.Count + 1}):{card2}");


      #region Check For Winner
      if (card1.value > card2.value)
      {
        Console.WriteLine($"Player 1 wins {cardsInPlay2.Count} card(s).");
        cardsInPlay1.AddRange(cardsInPlay2);
        cardsInPlay1.Shuffle();
        p1Cards.AddRange(cardsInPlay1);
        if (cardsInPlay1.Count > 2)
          CardUtil.PrintDeck(cardsInPlay1);
      }
      else if (card2.value > card1.value)
      {
        Console.WriteLine($"Player 2 wins {cardsInPlay1.Count} card(s).");
        cardsInPlay2.AddRange(cardsInPlay1);
        cardsInPlay2.Shuffle();
        if (cardsInPlay2.Count > 2)
          CardUtil.PrintDeck(cardsInPlay2);
        p2Cards.AddRange(cardsInPlay2);
      }
      else
      {
        Console.WriteLine("Cards are Equal...This means WAR!!!");
        if (!p1Cards.Any() || !p2Cards.Any())
        {
          Console.WriteLine("Player has no more cards for war. Everyone gets their cards back");
          p1Cards.AddRange(cardsInPlay1);
          p2Cards.AddRange(cardsInPlay2);
        }
        else
        {
          Play(cardsInPlay1, cardsInPlay2);
        }
      }
      #endregion

      #region Check if game is over
      if (!p1Cards.Any() || !p2Cards.Any())
      {
        InProgress = false;
      }
      else
      {
        Round++;
      }
      #endregion
    }

  }
}