namespace War.Game
{
  public class Card
  {
    public Suit suit { get; private set; }
    public int value { get; private set; }

    private string[] faceCards = { "J", "Q", "K", "A" };

    public Card(string value)
    {
      Validate.IsNotNull(value);
      Validate.IsNotEmpty(value);

      string suitChar = value.Substring(value.Length - 1);

      //Set class suit variable
      this.suit = ToSuit(suitChar);


      int cardVal = -1;

      //Check if facecard
      switch (value.Substring(0, value.Length - 1))
      {
        case "J":
          cardVal = 11;
          break;
        case "Q":
          cardVal = 12;
          break;
        case "K":
          cardVal = 13;
          break;
        case "A":
          cardVal = 14;
          break;
      }

      //Check if value is a number
      if (cardVal == -1 && int.TryParse(value.Substring(0, value.Length - 1), out int cardNum))
      {
        cardVal = cardNum;
      }


      if (cardVal < 2 || cardVal > 14)
      {
        throw new ValidationException($"Card '{value}' is not valid.");
      }

      this.value = cardVal;

    }

    public override string ToString()
    {
      string cardVal;

      switch (this.value)
      {
        case 11:
          cardVal = "Jack";
          break;
        case 12:
          cardVal = "Queen";
          break;
        case 13:
          cardVal = "King";
          break;
        case 14:
          cardVal = "Ace";
          break;
        default:
          cardVal = this.value.ToString();
          break;
      }
      return $"{cardVal} of {this.suit}s";
    }

    public static Suit ToSuit(string suitChar) => suitChar switch
    {
      "C" => Suit.Club,
      "D" => Suit.Diamond,
      "H" => Suit.Heart,
      "S" => Suit.Spade,
      _ => throw new ArgumentOutOfRangeException(nameof(suitChar), $"Unexpected Suit Value: {suitChar}"),
    };
  }

  public enum Suit
  {
    Club,
    Diamond,
    Heart,
    Spade
  }
}