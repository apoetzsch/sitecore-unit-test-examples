using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration.Attributes;
using GlassMapper.Intrefaces;

namespace GlassMapper
{
  [SitecoreType(TemplateId = "{1834f1f3-96cd-4869-b76d-2d8994cc98ce}", AutoMap = true)]
  public class Carousel
  {
    public virtual string Title { get; set; }

    [SitecoreChildren(InferType = true)]
    public virtual IEnumerable<ICarouselContent> CarouselItems { get; set; }
  }
}
