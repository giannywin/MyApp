using System;
namespace MyApp.Helpers
{
    public static class StringUtils
    {
        public static string UppercaseFirst(string s)
        {
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}
