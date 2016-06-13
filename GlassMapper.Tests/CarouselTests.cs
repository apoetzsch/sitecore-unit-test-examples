using System.Linq;
using Glass.Mapper.Sc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sitecore.Data;
using Sitecore.FakeDb;

namespace GlassMapper.Tests
{
  [TestClass]
  public class CarouselTests
  {
    [TestMethod]
    public void ShouldHaveCarouselItems()
    {
      App_Start.GlassMapperSc.Start();

      using (var db = SetupDb())
      {
        var service = new SitecoreService(db.Database);
        var carousel = service.GetItem<Carousel>("/sitecore/content/ProductCarousel");

        Assert.IsNotNull(carousel);
        Assert.IsInstanceOfType(carousel, typeof(Carousel));
        Assert.IsTrue(carousel.CarouselItems.Any());
        Assert.AreEqual(3, carousel.CarouselItems.Count());
      }
    }

    [TestMethod]
    public void ShouldHaveInferredCarouselItems()
    {
      /*
       * IMPORTANT: if you want GlassMapper to resolve the correct inferTypes, don't forget to configure 
       * the base project in GlassMapper.Tests.App_Start.GlassMapperScCustom.GlassLoaders()
       */

      App_Start.GlassMapperSc.Start();

      using (var db = SetupDb())
      {
        var service = new SitecoreService(db.Database);
        var carousel = service.GetItem<Carousel>("/sitecore/content/ProductCarousel");

        Assert.IsNotNull(carousel);
        Assert.IsTrue(carousel.CarouselItems.Any());

        foreach (var carouselItem in carousel.CarouselItems)
        {
          Assert.IsInstanceOfType(
            carouselItem,
            carouselItem.Name.StartsWith("ProductImage") ? typeof(CarouselImage) : typeof(CarouselVideo),
            carouselItem.Name);
        }
        
      }
    }

    private Db SetupDb()
    {
      var carouselTemplateId = new ID("{1834f1f3-96cd-4869-b76d-2d8994cc98ce}");
      var carouselImageTemplateId = new ID("{b0a50837-c6ab-411d-a36d-9074adbeb486}");
      var carouselVideoTemplateId = new ID("{a9391281-0249-4f75-8652-9e32baea58ae}");

      return new Db
      {
        new DbTemplate("Carousel", carouselTemplateId),
        new DbTemplate("CarouselImage", carouselImageTemplateId),
        new DbTemplate("CarouselVideo", carouselVideoTemplateId),

        new DbItem("ProductCarousel", ID.NewID, carouselTemplateId)
        {
          new DbItem("ProductImage 1", ID.NewID, carouselImageTemplateId),
          new DbItem("ProductVideo", ID.NewID, carouselVideoTemplateId),
          new DbItem("ProductImage 2", ID.NewID, carouselImageTemplateId)
        }
      };
    }
  }
}
