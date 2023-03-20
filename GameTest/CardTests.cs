using War.Game;

namespace GameTest;

[TestClass]
public class CardTests
{
  [TestMethod]
  public void Card_NullValue()
  {
#pragma warning disable 8625 //disable null reference to literal warning for this test
    Assert.ThrowsException<ValidationException>(() => new Card(null));
#pragma warning restore 8625
  }

  [TestMethod]
  public void Card_BlankValue()
  {
    Assert.ThrowsException<ValidationException>(() => new Card(""));
  }

  [TestMethod]
  public void Card_HighValue()
  {
    Assert.ThrowsException<ValidationException>(() => new Card("153C"));
  }

  [TestMethod]
  public void Card_LowValue()
  {
    Assert.ThrowsException<ValidationException>(() => new Card("-1S"));
  }

  [TestMethod]
  public void Card_BadFaceValue()
  {
    Assert.ThrowsException<ValidationException>(() => new Card("DC"));
  }

  [TestMethod]
  public void Card_BadSuit()
  {
    Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Card("2F"));
  }

  [TestMethod]
  public void Card_SuitStored_Club()
  {
    var card = new Card("8C");
    Assert.AreEqual(Suit.Club, card.suit);
  }

  [TestMethod]
  public void Card_SuitStored_Diamond()
  {
    var card = new Card("8D");
    Assert.AreEqual(Suit.Diamond, card.suit);
  }

  [TestMethod]
  public void Card_SuitStored_Heart()
  {
    var card = new Card("8H");
    Assert.AreEqual(Suit.Heart, card.suit);
  }

  [TestMethod]
  public void Card_SuitStored_Spade()
  {
    var card = new Card("8S");
    Assert.AreEqual(Suit.Spade, card.suit);
  }

  [TestMethod]
  public void Card_NumValueStored()
  {
    var card = new Card("8C");
    Assert.AreEqual(8, card.value);
  }

  [TestMethod]
  public void Card_JackValueStored()
  {
    var card = new Card("JC");
    Assert.AreEqual(11, card.value);
  }

  [TestMethod]
  public void Card_QueenValueStored()
  {
    var card = new Card("QC");
    Assert.AreEqual(12, card.value);
  }

  [TestMethod]
  public void Card_KingValueStored()
  {
    var card = new Card("KC");
    Assert.AreEqual(13, card.value);
  }

  [TestMethod]
  public void Card_AceValueStored()
  {
    var card = new Card("AC");
    Assert.AreEqual(14, card.value);
  }
}