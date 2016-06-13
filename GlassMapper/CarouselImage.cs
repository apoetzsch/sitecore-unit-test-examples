using System;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using GlassMapper.Intrefaces;
using Sitecore.Data;

namespace GlassMapper
{
  [SitecoreType(TemplateId = "{b0a50837-c6ab-411d-a36d-9074adbeb486}", AutoMap = true)]
  public class CarouselImage : GlassBase, ICarouselContent
  {
    [SitecoreField("CarouselImage")]
    public virtual Glass.Mapper.Sc.Fields.Image Image { get; set; }

    [SitecoreField("CarouselCaption")]
    public virtual string Caption { get; set; }
  }
}
