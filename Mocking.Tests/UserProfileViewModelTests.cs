using System.Web.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Sitecore.FakeDb.Security.Web;

namespace Mocking.Tests
{
  [TestClass]
  public class UserProfileViewModelTests
  {
    private readonly string _userName = @"sitecore\Test.User";

    [TestMethod]
    public void ShouldBeValidUser()
    {
      using (new MembershipSwitcher(MembershipProviderSetup()))
      {
        var viewModel = new UserProfileViewModel(_userName);

        Assert.IsTrue(viewModel.IsValidUser);
      }
    }

    [TestMethod]
    public void ShouldBeInvalidUser()
    {
      Assert.Fail();
    }

    [TestMethod]
    public void ShouldHaveTitle()
    {
      Assert.Fail();
    }

    [TestMethod]
    public void ShouldHaveDefaultMessageForTitle()
    {
      Assert.Fail();
    }

    [TestMethod]
    public void ShouldHaveDisplayName()
    {
      Assert.Fail();
    }

    [TestMethod]
    public void ShouldHaveDefaultMessageForDisplayName()
    {
      Assert.Fail();
    }
    

    // Test Setup
    private MembershipProvider MembershipProviderSetup()
    {
      // mock membership user
      var user = Substitute.For<MembershipUser>();
      user.UserName.Returns(_userName);

      // mock membership provider
      var provider = Substitute.For<MembershipProvider>();
      provider.GetUser(Arg.Is<string>(name => name != _userName), Arg.Any<bool>()).ReturnsNull();
      provider.GetUser(Arg.Is(_userName), Arg.Any<bool>()).Returns(user);

      // use provider and set some user details (will be stored in a static var in 
      // Webit.Jeno.Sc.Data.Intranet.Test.TestSupport.TestProfileProvider - see App.config)
      using (new MembershipSwitcher(provider))
      {
        var scUser = Sitecore.Security.Accounts.User.FromName(_userName, true);

        scUser.Profile.SetCustomProperty("DisplayName", "User, Test");
        scUser.Profile.SetCustomProperty("Title", "Dr.");

        scUser.Profile.Save();
      }

      return provider;
    }
  }
}
