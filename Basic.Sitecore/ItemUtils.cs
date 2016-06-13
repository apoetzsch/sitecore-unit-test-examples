using System.Collections.Generic;
using System.Linq;
using Sitecore.Data.Items;

namespace Basic.Sitecore
{
  public class ItemUtils
  {
    private List<Item> _componentItems = new List<Item>();

    public ItemUtils(Item item)
    {
      Item = item;
    }

    public Item Item { get; }

    public List<Item> ComponentItems
    {
      get
      {
        // get the (content)items of the components folder
        var componentsFolderPath = Item.Paths.Path + "/Components";
        var componentsItem = Item.Database.GetItem(componentsFolderPath);
        if (componentsItem != null && !componentsItem.ID.IsGlobalNullId)
        {
          _componentItems = componentsItem.Axes.GetDescendants().ToList();
        }

        return _componentItems;
      }
      set { _componentItems = value; }
    }
  }
}
