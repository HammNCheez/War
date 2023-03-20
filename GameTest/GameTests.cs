using War.Game;

namespace GameTest;

[TestClass]
public class GameTests
{
  private List<Card> p1Cards = new List<Card>();
  private List<Card> p2Cards = new List<Card>();


  [TestInitialize]
  public void TestInit()
  {
    #region Initialize P1 Cards
    p1Cards.Add(new Card("4H"));
    p1Cards.Add(new Card("JD"));
    p1Cards.Add(new Card("5S"));
    p1Cards.Add(new Card("9C"));
    #endregion

    #region Initialize P2 Cards
    p2Cards.Add(new Card("10H"));
    p2Cards.Add(new Card("5D"));
    p2Cards.Add(new Card("KC"));
    p2Cards.Add(new Card("9S"));
    #endregion
  }

  [TestCleanup]
  public void TestCleanup()
  {
    #region Initialize P1 Cards
    p1Cards = new List<Card>();
    p1Cards.Add(new Card("4H"));
    p1Cards.Add(new Card("JD"));
    p1Cards.Add(new Card("5S"));
    p1Cards.Add(new Card("9C"));
    #endregion

    #region Initialize P2 Cards
    p2Cards = new List<Card>();
    p2Cards.Add(new Card("10H"));
    p2Cards.Add(new Card("5D"));
    p2Cards.Add(new Card("KC"));
    p2Cards.Add(new Card("9S"));
    #endregion
  }

  [TestMethod]
  public void Game_Init_EmptyP1()
  {
    p1Cards.Clear();
    Assert.ThrowsException<ValidationException>(() => new Game(p1Cards, p2Cards));
  }

  [TestMethod]
  public void Game_Init_EmptyP2()
  {
    p2Cards.Clear();
    Assert.ThrowsException<ValidationException>(() => new Game(p1Cards, p2Cards));
  }

  [TestMethod]
  public void Game_Init_NullP1()
  {
#pragma warning disable 8625, 8604
    p1Cards = null;
    Assert.ThrowsException<ValidationException>(() => new Game(p1Cards, p2Cards));
  }

  [TestMethod]
  public void Game_Init_NullP2()
  {
    p2Cards = null;
    Assert.ThrowsException<ValidationException>(() => new Game(p1Cards, p2Cards));
#pragma warning restore
  }

  [TestMethod]
  public void Game_Init_Clean()
  {
    var game = new Game(p1Cards, p2Cards);
    Assert.IsNotNull(game);
  }

  [TestMethod]
  public void Game_Init_CheckP1()
  {
    var game = new Game(p1Cards, p2Cards);
    Assert.AreSame(p1Cards, game.p1Cards);
  }

  [TestMethod]
  public void Game_Init_CheckP2()
  {
    var game = new Game(p1Cards, p2Cards);
    Assert.AreSame(p2Cards, game.p2Cards);
  }

  [TestMethod]
  public void Game_Play_P1Win()
  {
    Assert.IsTrue(false);
  }
}