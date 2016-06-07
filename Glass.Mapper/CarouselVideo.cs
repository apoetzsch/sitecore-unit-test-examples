using Glass.Mapper.Sc.Configuration.Attributes;

namespace Glass.Mapper
{
  [SitecoreType(TemplateId = "{1A1D95F7-58AA-44A4-8242-AE4F02C4BD4C}", AutoMap = true)]
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
