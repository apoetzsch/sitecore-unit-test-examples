using System.Collections.Generic;
using System.Configuration;
using Basic.Net;
using Sitecore.FakeDb.Security.Web;

namespace Mocking.Tests.FakeDbExtensions
{
  public class TestProfileProvider : FakeProfileProvider
  {
    public override string ApplicationName { get; set; }

    public static Dictionary<string, SettingsPropertyValueCollection> Properties { get; set; } = new Dictionary<string, SettingsPropertyValueCollection>();

    public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection collection)
    {
      var returnCollection = new SettingsPropertyValueCollection();
      var userName = (string)context["UserName"];
      if (userName.HasValue())
      {
        var userProperties = Properties.ContainsKey(userName)
          ? Properties[userName]
          : new SettingsPropertyValueCollection();
        foreach (SettingsProperty property in collection)
        {
          var setting = new SettingsPropertyValue(property);
          if (userProperties[property.Name] != null && userProperties[property.Name].PropertyValue != null)
          {
            setting.PropertyValue = userProperties[property.Name].PropertyValue;
          }
          returnCollection.Add(setting);
        }
      }
      return returnCollection;
    }

    public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection collection)
    {
      var userName = (string)context["UserName"];
      if (userName.HasValue())
      {
        Properties[userName] = collection;
      }
    }
  }
}
