﻿using System.Text.RegularExpressions;

namespace JD.Extensions
{
    public static class StringExtensions
    {
        public static string ToCapitalize(this string str)
        {
            return $"{str.Substring(0, 1).ToUpperInvariant()}{str.Substring(1)}";
        }
        
        public static string ToClean(this string str)
        {
            return Regex.Replace(str, @"[^a-zA-Z0-9]", "");
        }
    }
}