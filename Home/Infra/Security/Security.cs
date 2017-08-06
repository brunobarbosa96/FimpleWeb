using System;
using System.Text;

namespace Home.Infra.Security
{
    public static class Security
    {
        public static string Encrypt(string value)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string Decrypt(string value)
        {
            var base64EncodedBytes = Convert.FromBase64String(value);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}