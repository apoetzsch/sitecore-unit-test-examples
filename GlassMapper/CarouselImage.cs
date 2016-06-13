using Glass.Mapper;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace GlassMapper
{
  [SitecoreType(TemplateId = "{b0a50837-c6ab-411d-a36d-9074adbeb486}", AutoMap = true)]
  public class CarouselImage : ICarouselContent
  {
    [SitecoreField("CarouselImage")]
    public virtual Glass.Mapper.Sc.Fields.Image Image { get; set; }

    [SitecoreField("CarouselCaption")]
    public virtual string Caption { get; set; }
  }
}
