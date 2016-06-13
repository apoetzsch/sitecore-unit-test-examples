using System;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace GlassMapper
{
  public class GlassBase
  {
    [SitecoreId]
    public virtual Guid Id { get; private set; }

    [SitecoreInfo(SitecoreInfoType.Name)]
    public virtual string Name { get; set; }

    [SitecoreInfo(SitecoreInfoType.TemplateId)]
    public virtual Guid TemplateId { get; set; }
  }
}
