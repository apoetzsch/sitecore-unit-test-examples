using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Sitecore.FakeDb;

namespace Sitecore.Tests
{
  [TestClass]
  public class ItemUtilsTests
  {
    [TestMethod]
    public void ShouldInitializeItemUtils()
    {
      using (var db = SetupDb())
      {
        var item = db.GetItem("/sitecore/Content/Content Item");

        var utils = new ItemUtils(item);

        Assert.AreEqual(item, utils.Item);
      }
    }

    [TestMethod]
    public void ShouldGetComponents()
    {
      using (var db = SetupDb())
      {
        var contentItem = db.GetItem("/sitecore/Content/Content Item");
        var utils = new ItemUtils(contentItem);

        var components = utils.ComponentItems;

        Assert.IsTrue(components.Any());
        Assert.AreEqual(3, components.Count);

        foreach (var name in new[] { "Text", "Image", "Teaser" })
        {
          Assert.IsTrue(components.Any(x => x.Name == name), $"{name} should be a component item");
        }
      }
    }

    private static Db SetupDb()
    {
      return new Db
      {
        new DbItem("Content Item")
        {
          new DbItem("Components")
          {
            new DbItem("Text"),
            new DbItem("Image"),
            new DbItem("Teaser")
          }
        }
      };
    }
  }
}