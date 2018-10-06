using Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SeeSharpUtilities
{
    class CryptographyOptions
    {
        public static void Run()
        {
            List<string> options = new List<string>
            {
                "1. Symmetric encryption of a text",
                "2. Symmetric decryption of a text",
                "3. Generate symmetric key",
                "4. Asymmetric encryption/decryption of a text",
                "5. Generate asymmetric key pair",
                "6. Hash text"
            };
            Menu cryptographyMenu = new Menu("Cryptography", options);

            int userInput = 0;
            do
            {
                userInput = cryptographyMenu.Display();
                string keyString;
                string inputText;
                string encryptedText;
                string decryptedText;

                switch (userInput)
                {
                    //SYMMETRIC ENCRYPTION
                    case 1:
                        Console.Write("Enter key string: ");
                        keyString = Console.ReadLine();
                        Console.Write("Enter plain text: ");
                        inputText = Console.ReadLine();

                        encryptedText = SymmetricEncryption.EncryptString_Aes(inputText, keyString);
                        Console.WriteLine("Encrypted text: " + encryptedText);
                        break;
                    case 2:
                        Console.Write("Enter key string: ");
                        keyString = Console.ReadLine();
                        Console.Write("Enter encrypted text: ");
                        inputText = Console.ReadLine();

                        decryptedText = SymmetricEncryption.DecryptString_Aes(inputText, keyString);
                        Console.WriteLine("Decrypted text: " + decryptedText);
                        break;
                    case 3:
                        string symmetricKey = SymmetricEncryption.GenerateKey_Aes();
                        Console.WriteLine("Key: " + symmetricKey);
                        break;
                    //ASYMMETRIC ENCRYPTION
                    case 4:
                        Console.Write("Enter plain text: ");
                        inputText = Console.ReadLine();
                        //TODO: read public key somehow better
                        string inputPublicKeyString = @"<?xml version=""1.0"" encoding=""utf - 16""?><RSAParameters xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema""><Exponent>AQAB</Exponent><Modulus>rtzhb4WHroj/yflV4iORwRQkhuD3qHx0nkHmLhOGJE1zvfv+MRgFJ66b1go3JK887Ciqz0F1XW+2R5Lw4DxXicw7X2f9cljpZHZKvxLy5Hys17nyLhIIcm9LmYsDlVgBD6dbtdhy7vcB7q2e8AYxVxibYaGSfS99Z6JBMKsZW5RAQWT3AfFBvW+bYk34kq26O0E/lMJhEt03whG2ba8osKjPY4B4IgaD3Uh6X8isCfvfQfVfkke2zOuQBDP9WgNIYvjTX4V9AmNhMfYTxbM5Kgybe30vP1dbFYusXFN+4DUm3QAzKfanV99c7ljFvSmnQBVjYVgRRSRm6DIphjgprQ==</Modulus></RSAParameters>";
                        RSAParameters inputPublicKey = AsymmetricEncryption.ConvertStringKeyToParameters(inputPublicKeyString);

                        encryptedText = AsymmetricEncryption.EncryptText(inputText, inputPublicKey);
                        Console.WriteLine("Encrypted text: " + encryptedText);

                        //TODO: read private key somehow better
                        string inputPrivateKeyString = @"<?xml version=""1.0"" encoding=""utf - 16""?><RSAParameters xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema""><Exponent>AQAB</Exponent><Modulus>rtzhb4WHroj/yflV4iORwRQkhuD3qHx0nkHmLhOGJE1zvfv+MRgFJ66b1go3JK887Ciqz0F1XW+2R5Lw4DxXicw7X2f9cljpZHZKvxLy5Hys17nyLhIIcm9LmYsDlVgBD6dbtdhy7vcB7q2e8AYxVxibYaGSfS99Z6JBMKsZW5RAQWT3AfFBvW+bYk34kq26O0E/lMJhEt03whG2ba8osKjPY4B4IgaD3Uh6X8isCfvfQfVfkke2zOuQBDP9WgNIYvjTX4V9AmNhMfYTxbM5Kgybe30vP1dbFYusXFN+4DUm3QAzKfanV99c7ljFvSmnQBVjYVgRRSRm6DIphjgprQ==</Modulus><P>z0vr7QOxloBnykNEuksOIZUyjiqV7iTDbiShERaO2v57hVehP56oWhyUxtt92QYdYSz1mLF1Wehq/KlqEAWL9t0OdiM3ZIHrK9zvEV8ZniUKWATT0D8vo3N/tlukmg+bf8ZFiBPmkWPOvZtOp4xDBh+cC6/aD6PNThOr36NjcKM=</P><Q>1/IyC9+RFMvKq9gu+bziPAdgL//yYutGD4hW98qmPNjkstOLjqYd5KxkqUJp+J85NsoiuSML3exYufk0h29/52pWWnHb+hXr5xnLHfjyqes6+1OC4n76ZinLgEivnIce7DIt91KZelmBIA7187GnEgRTBjhA4jZIR2zEXlZakW8=</Q><DP>rSOKcDIPl9az2boJo1eg++ezjA6Bn6BRIqOxa6Zdtweqf5rLcWnAz1Lj6JvXJvb2fv2gO+KsU2XORi3yCmO3nX7Q31dWornohIBJpUa7DN1/IDkX+O1tiqWjW9p7RroWdMhTtu54O6MTQEaBkWuTZ3/rQ8+i4EE97yJ7AZVkLuU=</DP><DQ>TS+bpdTOZbGGCrBl8gwKjUxRnDaO676Ot0STWVSM4Njhve2RR3am3rKj9D/x4tT+vU+445XcSwGMoUSq+vHmtM+0d/WUnCozvNHiYR83lXaoCWdLNCwQ0m2D+KGCa598dQ5mka1rgGj3l37heK56Oh1jk6iNwI2IfkcpVVLmYm8=</DQ><InverseQ>d07CqPxndelotAo5EVaus76hStuLoNJTWoSVkVcQpP7WAP1e6T/44IV9IjDhFA+y3wvlMAofTOxvvsoYQoIehrPqATcXxHzqUXSEF5KRFbEG6jYBZvXlaiuCg+u6W1GnpGIA/TMCx82PFRPXH3mrlGO9P2loeImzhLM9KqOoh+w=</InverseQ><D>njM/0cGhC4ruwDBQPxOnHmO22EBYT5qpdzRvp2gKiHV6LXv6cTgmEcyrOG5tjUbte0sfnfq+0BXtd7u9KWHuYMDhRmOyrO072qQa49uk3IrfZRzZukyeT8nZP8TBLTA9ZYgoNNDqyr+2g9WYYdd4dC/TA/VFrvR0JHprODjT7EEpJgnohqG1giWrv/pg4JSJYxbGBvEY4zXiuIxOszUMYUiHZ3Jpz74BwWnxAcEIVN4jLdvoPrWC0chbpyme0hP1b5XtIHM2iXb+oCCDfaD3qDbfUM3U/pmdh4np9tmC8NeUlomlaUW5aZBBt7n26MD8HJ+ePm3KKvVxBsou7RznEQ==</D></RSAParameters>";
                        RSAParameters inputPrivateKey = AsymmetricEncryption.ConvertStringKeyToParameters(inputPrivateKeyString);
                        decryptedText = AsymmetricEncryption.DecryptText(encryptedText, inputPrivateKey);
                        Console.WriteLine("Decrypted text: " + decryptedText);
                        break;
                    case 5:
                        var csp = AsymmetricEncryption.GenerateCSP();

                        var pubKey = csp.ExportParameters(false);
                        string pubKeyString = AsymmetricEncryption.ConvertParametersToStringKey(pubKey);

                        var privKey = csp.ExportParameters(true);
                        string privKeyString = AsymmetricEncryption.ConvertParametersToStringKey(privKey);

                        Console.WriteLine("Public key: " + pubKeyString);
                        Console.WriteLine("Private key: " + privKeyString);
                        break;
                    case 6:
                        Console.Write("Enter plain text: ");
                        inputText = Console.ReadLine();

                        string hashedText = Hashing.GetHashedText(inputText);
                        Console.WriteLine("Hashed text: " + hashedText);
                        break;
                    default:
                        break;
                }
            } while (userInput != 0);
        }
    }
}
