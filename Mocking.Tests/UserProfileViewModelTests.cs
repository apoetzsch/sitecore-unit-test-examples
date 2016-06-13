using System.Web.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Sitecore.FakeDb.Security.Web;
using Sitecore.Globalization;

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
        var profileViewModel = new UserProfileViewModel(_userName);

        Assert.IsTrue(profileViewModel.IsValidUser);
      }
    }

    [TestMethod]
    public void ShouldBeInvalidUser()
    {
      using (new MembershipSwitcher(MembershipProviderSetup()))
      {
        var profileViewModel = new UserProfileViewModel(@"sitecore\INVALID.USER");

        Assert.IsFalse(profileViewModel.IsValidUser);
      }
    }

    [TestMethod]
    public void ShouldHaveTitle()
    {
      using (new MembershipSwitcher(MembershipProviderSetup()))
      {
        var profileViewModel = new UserProfileViewModel(_userName);

        Assert.AreEqual("Dr.", profileViewModel.Title);
      }
    }

    [TestMethod]
    public void ShouldHaveDefaultMessageForTitle()
    {
      using (new MembershipSwitcher(MembershipProviderSetup()))
      {
        var profileViewModel = new UserProfileViewModel(@"sitecore\INVALID.USER");

        Assert.AreEqual(Translate.Text("UserNotExisting"), profileViewModel.Title);
      }
    }

    [TestMethod]
    public void ShouldHaveDisplayName()
    {
      using (new MembershipSwitcher(MembershipProviderSetup()))
      {
        var profileViewModel = new UserProfileViewModel(_userName);

        Assert.AreEqual("User, Test", profileViewModel.DisplayName);
      }
    }

    [TestMethod]
    public void ShouldHaveDefaultMessageForDisplayName()
    {
      using (new MembershipSwitcher(MembershipProviderSetup()))
      {
        var profileViewModel = new UserProfileViewModel(@"sitecore\INVALID.USER");

        Assert.AreEqual(Translate.Text("UserNotExisting"), profileViewModel.DisplayName);
      }
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
      // Mocking.Tests.FakeDbExtensions.TestProfileProvider - see App.config)
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
