using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sitecore.Data;
using Sitecore.FakeDb;

namespace Basic.Sitecore.Tests
{
  [TestClass]
  public class TaggingHelperTests
  {
    [TestMethod]
    public void ShouldGetCategoryTags()
    {
      var webPageTemplateId = ID.NewID;
      var tagOneId = ID.NewID;
      var tagThreeId = ID.NewID;

      using (var db = new Db
      {
        new DbTemplate("WebPage", webPageTemplateId)
        {
          new DbField("Categories", TaggingHelper.CategoryTagFieldId)
        },
        new DbItem("WebPage", ID.NewID, webPageTemplateId) { { "Categories", $"{tagOneId}|{tagThreeId}"} },
        new DbItem("Tags")
        {
          new DbItem("Cat 1", tagOneId),
          new DbItem("Cat 2", ID.NewID),
          new DbItem("Cat 3", tagThreeId)
        }
      })
      {
        var item = db.GetItem("/sitecore/content/WebPage");

        var result = TaggingHelper.GetCategoryTags(item);

        Assert.IsTrue(result.Any());
        Assert.IsTrue(result.Contains("Cat 1"));
        Assert.IsFalse(result.Contains("Cat 2"));
        Assert.IsTrue(result.Contains("Cat 3"));
      }
    }
  }
}
