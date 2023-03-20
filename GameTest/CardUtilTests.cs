using War.Game;

namespace GameTest;

[TestClass]
public class CardUtilTests
{
  [TestMethod]
  public void ReadInCards_MissingFile()
  {
    var cards = CardUtil.ReadInCards("missingFile.txt");
  }

  [TestMethod]
  public void ReadInCards_EmptyFile()
  {
    var cards = CardUtil.ReadInCards("EmptyFile.txt");
  }

  [TestMethod]
  public void ReadInCards_FileWithBadCards()
  {
    var cards = CardUtil.ReadInCards("BadValues.txt");
  }

  [TestMethod]
  public void ReadInCards_GoodCards()
  {
    var cards = CardUtil.ReadInCards("GoodValues.txt");
  }
}