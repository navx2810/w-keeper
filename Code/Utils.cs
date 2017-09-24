using System;
using System.Security.Cryptography;
using System.Text;

namespace Keeper.Code
{
    public static class Utils
    {
        public static bool IsEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }
        public static string Hash(string val)
        {
            using(SHA256 hash = SHA256.Create())
            {
                byte[] h = hash.ComputeHash(Encoding.ASCII.GetBytes(val));
                return Convert.ToBase64String(h);
            }
        }
    }
}