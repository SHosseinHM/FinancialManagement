using System.Security.Cryptography;
using System.Text;

namespace Application.Security
{
    public static class HashMD5
    {
        public static string Hash(this string hashed)
        {
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(hashed);
            encodedBytes = md5.ComputeHash(originalBytes);
            return BitConverter.ToString(encodedBytes);
        }
    }
}