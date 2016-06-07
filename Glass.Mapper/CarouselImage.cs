using Glass.Mapper.Sc.Configuration.Attributes;

namespace Glass.Mapper
{
  [SitecoreType(TemplateId = "{FCD72AC5-292D-48D0-A7C3-FCAE0FC8D742}", AutoMap = true)]
  public class CarouselImage : ICarouselContent
  {
    [SitecoreField("CarouselImage")]
    public virtual Sc.Fields.Image Image { get; set; }

    [SitecoreField("CarouselCaption")]
    public virtual string Caption { get; set; }
  }
}
