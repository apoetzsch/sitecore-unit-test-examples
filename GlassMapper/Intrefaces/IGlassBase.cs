using System;

namespace GlassMapper.Intrefaces
{
  public interface IGlassBase
  {
    Guid Id { get; }

    string Name { get; }

    Guid TemplateId { get; }
  }
}
