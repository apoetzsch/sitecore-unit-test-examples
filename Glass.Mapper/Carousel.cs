using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace Glass.Mapper
{
  [SitecoreType(TemplateId = "{E13A8039-947E-4C51-BA3E-F4B31AD632B3}", AutoMap = true)]
  public class Carousel
  {
    public virtual string Title { get; set; }

    [SitecoreChildren(InferType = true)]
    public virtual IEnumerable<ICarouselContent> CarouselItems { get; set; }
  }
}
