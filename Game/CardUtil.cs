
namespace War.Game
{

  public static class CardUtil
  {
    private static Random rng = new Random();

    public static List<Card> ReadInCards(string fileName)
    {
      var rawCards = File.ReadAllLines(fileName).ToList();

      //Check for empty
      Validate.IsNotEmpty(rawCards);

      //Convert Cards
      var cards = new List<Card>();
      foreach (var cardString in rawCards)
      {
        cards.Add(new Card(cardString));
      }

      return cards;
    }

    public static void PrintDeck(List<Card> cards)
    {
      foreach (var card in cards)
      {
        Console.WriteLine(card.ToString());
      }
    }

    public static void Shuffle<T>(this IList<T> list)
    {
      int n = list.Count;
      while (n > 1)
      {
        n--;
        int k = rng.Next(n + 1);
        T value = list[k];
        list[k] = list[n];
        list[n] = value;
      }
    }

    // switch (_suit)
    //             {
    //                 case "Hearts":
    //                     Console.Write('♥');
    //                     break;
    //                 case "Clubs":
    //                     Console.Write("♣");
    //                     break;
    //                 case "Diamonds":
    //                     Console.Write("♦");
    //                     break;
    //                 case "Spades":
    //                     Console.Write("♠");
    //                     break;
    //             }
  }
}
