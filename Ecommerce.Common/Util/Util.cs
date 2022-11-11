using System.Globalization;

namespace Ecommerce.Common.Util;

public static class Util
{
    private static readonly TextInfo Text = CultureInfo.CurrentCulture.TextInfo;
    public static string Capitalize(string inputString)
    {
        return Text.ToTitleCase(ToLowerCase(inputString));
    }

    private static string ToLowerCase(string inputString)
    {
        return inputString.ToLower();
    }
}