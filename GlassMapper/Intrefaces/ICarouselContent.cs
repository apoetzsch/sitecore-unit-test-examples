namespace GlassMapper.Intrefaces
{
  public interface ICarouselContent : IGlassBase
  {
    Glass.Mapper.Sc.Fields.Image Image { get; set; }

    string Caption { get; set; }
  }
}
