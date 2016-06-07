using System.Text.RegularExpressions;

namespace Basic.Net
{
  public static class StringExtensions
  {
    /// <summary>
    /// check if string has value
    /// </summary>
    /// <param name="value">string instance</param>
    /// <returns>true if string has values, false otherwise</returns>
    public static bool HasValue(this string value)
    {
      return !string.IsNullOrEmpty(value);
    }

    /// <summary>
    /// remove whitespaces and multiple spaces from string
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string RemoveWhitespaces(this string text)
    {
      // remove whitespace
      text = Regex.Replace(text, @"\s+", " ", RegexOptions.Multiline);

      // remove multiple spaces
      return Regex.Replace(text, @"[ ]{2,}", " ");
    }


    /// <summary>
    /// capitalize first character of string
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string Capitalize(this string text)
    {
      return text.HasValue()
        ? char.ToUpper(text[0]) + (text.Length > 1 ? text.Substring(1).ToLower() : string.Empty)
        : string.Empty;
    }
  }
}
