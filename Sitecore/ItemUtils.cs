using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace Sitecore
{
  public class ItemUtils
  {
    private readonly Item _item;
    private List<Item> _componentItems = new List<Item>();

    public ItemUtils(Item item)
    {
      this._item = item;
    }

    public List<Item> ComponentItems
    {
      get
      {
        // get the (content)items of the components folder
        var componentsFolderPath = _item.Paths.Path + "/Components";
        var componentsItem = _item.Database.GetItem(componentsFolderPath);
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
