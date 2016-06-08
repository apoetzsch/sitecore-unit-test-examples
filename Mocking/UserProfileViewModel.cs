using Sitecore.Globalization;
using Sitecore.Security.Accounts;

namespace Mocking
{
  public class UserProfileViewModel
  {
    private string UserName { get; }

    public UserProfileViewModel(string userName)
    {
      UserName = userName;
    }

    public string Title => ScUser?.Profile.GetCustomProperty("Title") ?? Translate.Text("UserNotExisting");

    public string DisplayName => ScUser?.Profile.GetCustomProperty("DisplayName") ?? Translate.Text("UserNotExisting");

    public bool IsValidUser => ScUser != null;

    private User ScUser => User.Exists(UserName) ? User.FromName(UserName, true) : null;
  }

}
