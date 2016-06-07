using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Globalization;
using Sitecore.Security.Accounts;

namespace Nsubstitute
{
    public class UserToolViewModel
    {
      public string UserName { get; set; }

      public string Title => ScUser?.DisplayName ?? Translate.Text("UserNotExisting");

      public string ToolUrl => ScUser != null ? $"http://url.to.usertool.com?username={ScUser.LocalName}" : "";

      private User ScUser => User.Exists(UserName) ? User.FromName(UserName, true) : null;
    }
  
}
