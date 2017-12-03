using System.Security.Cryptography;
using System.Text;

/* SOURCES:
https://msdn.microsoft.com/en-us/library/system.security.cryptography.sha256(v=vs.110).aspx
https://stackoverflow.com/questions/12416249/hashing-a-string-with-sha256
*/

namespace Cryptography
{
    public static class Hashing
    {
        public static string GetHashedText(string plainText)
        {
            SHA256Managed crypt = new SHA256Managed();
            StringBuilder hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(plainText), 0, Encoding.UTF8.GetByteCount(plainText));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
