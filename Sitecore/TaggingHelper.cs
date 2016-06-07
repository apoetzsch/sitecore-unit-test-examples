using System.Collections.Generic;
using System.Linq;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace Sitecore
{
  public class TaggingHelper
  {
    public static readonly ID CategoryTagFieldId = new ID("{CB142B62-2F9D-4A97-96E8-C661BE673B20}");

    public static ISet<string> GetLocationTags(Item item)
    {
      return GetTags(item, CategoryTagFieldId);
    }

    private static ISet<string> GetTags(Item item, ID tagFieldId)
    {
      if (item == null || tagFieldId == (ID)null || tagFieldId.IsNull)
        return new HashSet<string>();

      var multiListValues = item
        .GetMultiListValues(tagFieldId)
        .Select(tag => tag.DisplayName);

      return new HashSet<string>(multiListValues);
    }
  }

  public static class ItemExtensions
  {
    /// <summary>
    /// GetMultiListValues fetches the Items that are referenced in the MultilistField.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="fieldId"></param>
    /// <returns></returns>
    public static List<Item> GetMultiListValues(this Item item, ID fieldId)
    {
      MultilistField multiselect = item.Fields[fieldId];
      return multiselect.GetItems().ToList();
    }
  }
}
