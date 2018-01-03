using System;
using System.Collections.Generic;

namespace MyApp.Helpers
{
    public static class DictionaryExtensions
    {
        public static string ToQueryString<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
        {
            return ToQueryString<TKey, TValue>(dictionary, "?");
        }

        public static string ToQueryString<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, string startupDelimiter)
        {
            string result = string.Empty;
            foreach (var item in dictionary)
            {
                if (string.IsNullOrEmpty(result))
                    result += startupDelimiter; // "?";
                else
                    result += "&";

                result += string.Format("{0}={1}", item.Key, Uri.EscapeDataString(item.Value.ToString()));
            }
            return result;
        }
    }
}
