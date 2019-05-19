using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JDOK.EncryptionLib;

namespace CipherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            int userKey;

            if (args.Length > 0)
            {
                userInput = args[0];

                if (Validator.IsValidKey(args[1]))
                {
                    userKey = int.Parse(args[1]);
                }
                else
                {
                    throw new ArgumentException("The second argument must be an integer");
                }
            }
            else
            {
                Console.WriteLine("Please enter some text to encrypt: ");
                userInput = Console.ReadLine();
                userKey = 0;

                bool validKey = false;

                while (validKey == false)
                {
                    Console.WriteLine("\nPlease enter an non-zero integer between -25 and 25 as the encryption key: ");
                    validKey = int.TryParse(Console.ReadLine(), out int resultKey);
                    userKey = resultKey;
                }
            }

            Cipher cipher = new Cipher();
            string encryptedMessage = cipher.Encrypt(userInput, userKey);

            Console.WriteLine("\nThe encrypted message is: " + encryptedMessage);
            Console.ReadLine();

            string decryptedMessage = cipher.Decrypt(encryptedMessage, userKey);

            Console.WriteLine("\nThe decrypted message is: " + decryptedMessage);
            Console.ReadLine();
        }
    }
}
