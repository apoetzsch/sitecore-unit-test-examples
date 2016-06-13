using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basic.Net.Tests
{
  [TestClass]
  public class StringExtensionsTests
  {
    [TestMethod]
    public void ShouldHaveValue()
    {
      var testString = "My value";

      Assert.IsTrue(testString.HasValue());
    }

    [TestMethod]
    public void ShouldHaveNoValue()
    {
      var testString = "";

      Assert.IsFalse(testString.HasValue());
    }

    [TestMethod]
    public void ShouldRemoveWhitespaces()
    {
      var withWhitespaces = "   Co    nte nt    ";

      var trimmed = withWhitespaces.RemoveWhitespaces();

      Assert.AreEqual("Content", trimmed);
    }

    [TestMethod]
    public void ShouldCapitalizeString()
    {
      var mixedUppercases = "mIxEDUpperCases";

      var capitalizedString = mixedUppercases.Capitalize();

      Assert.AreNotEqual(mixedUppercases, capitalizedString);
      Assert.AreEqual("Mixeduppercases", capitalizedString);
    }
  }
}