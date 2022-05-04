using System;

namespace ControleEstacionamento.Api.Extensions
{
    public static class ExtensionMethods
    {
        public static string StringFormat(this string value)
        {
            return String.Join("", System.Text.RegularExpressions.Regex.Split(value, @"[^a-zA-Z\d]"));
        }
      
    }
}
