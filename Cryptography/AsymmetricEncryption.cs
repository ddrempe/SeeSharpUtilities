using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

/* SOURCES:
https://stackoverflow.com/questions/17128038/c-sharp-rsa-encryption-decryption-with-transmission
*/

namespace Cryptography
{
    public static class AsymmetricEncryption
    {
        public static RSACryptoServiceProvider GenerateCSP()
        {
            return new RSACryptoServiceProvider(2048);
        }

        public static string ConvertParametersToStringKey(RSAParameters parameters)
        {
            //we need some buffer
            var sw = new System.IO.StringWriter();
            //we need a serializer
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            //serialize the key into the stream
            xs.Serialize(sw, parameters);
            //get the string from the stream
            return sw.ToString();
        }

        public static RSAParameters ConvertStringKeyToParameters(string key)
        {
            //get a stream from the string
            var sr = new System.IO.StringReader(key);
            //we need a deserializer
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            //get the object back from the stream
            return (RSAParameters)xs.Deserialize(sr);
        }

        public static string EncryptText(string plainText, RSAParameters publicKey)
        {
            //we have a public key ... let's get a new csp and load that key
            RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
            csp.ImportParameters(publicKey);

            //for encryption, always handle bytes...
            var bytesPlainTextData = System.Text.Encoding.Unicode.GetBytes(plainText);

            //apply pkcs#1.5 padding and encrypt our data 
            var bytesCypherText = csp.Encrypt(bytesPlainTextData, false);

            //we might want a string representation of our cypher text... base64 will do
            string cypherText = Convert.ToBase64String(bytesCypherText);

            return cypherText;
        }

        public static string DecryptText(string cypherText, RSAParameters privateKey)
        {
            //first, get our bytes back from the base64 string ...
            var bytesCypherText = Convert.FromBase64String(cypherText);

            //we want to decrypt, therefore we need a csp and load our private key
            RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
            csp.ImportParameters(privateKey);

            //decrypt and strip pkcs#1.5 padding
            var bytesPlainTextData = csp.Decrypt(bytesCypherText, false);

            //get our original plainText back...
            string plainTextData = Encoding.Unicode.GetString(bytesPlainTextData);

            return plainTextData;
        }
    }
}
