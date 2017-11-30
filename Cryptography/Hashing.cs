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
            //TODO: check if UTF8 is needed encoding instead of default
            byte[] bytes = Encoding.Default.GetBytes(plainText);

            // Initialize a SHA256 hash object.
            SHA256 newSHA256 = SHA256.Create();

            // Compute the hash
            byte[] hashedText = newSHA256.ComputeHash(bytes);
            string hashedTextString = Encoding.Default.GetString(hashedText, 0, hashedText.Length);

            return hashedTextString;
        }
    }
}
