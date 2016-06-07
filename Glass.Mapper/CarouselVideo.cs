using Glass.Mapper.Sc.Configuration.Attributes;

namespace Glass.Mapper
{
  [SitecoreType(TemplateId = "{a9391281-0249-4f75-8652-9e32baea58ae}", AutoMap = true)]
  public class CarouselVideo : ICarouselContent
  {
    [SitecoreField("CarouselVideoUrl")]
    public virtual string VideoUrl { get; set; }

    [SitecoreField("CarouselImage")]
    public virtual Sc.Fields.Image Image { get; set; }

    [SitecoreField("CarouselCaption")]
    public virtual string Caption { get; set; }
  }
}
