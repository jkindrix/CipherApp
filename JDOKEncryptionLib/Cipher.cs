using System;
using System.Collections.Generic;

namespace JDOK.EncryptionLib
{
    /// <summary>
    /// A Cipher can be used to handle encryption and decryption of a string
    /// using symmetric key encryption
    /// </summary>
    public class Cipher
    {
        /// <summary>
        /// Encrypts a string and returns the encrypted string
        /// </summary>
        /// <param name="message">The string to be encrypted</param>
        /// <param name="key">An integer value to be used in the encryption process</param>
        /// <returns>The encrypted message</returns>
        public string Encrypt(string message, int key)
        {
            string encryptedMessage = "";

            foreach (char character in message)
            {
                encryptedMessage += Translate(character, key);
            }

            return encryptedMessage;
        }

        /// <summary>
        /// Decrypts a message and returns the decrypted message
        /// </summary>
        /// <param name="message">A string representing the message to be decrypted</param>
        /// <param name="key">An integer value to be used in the decryption process</param>
        /// <returns>The encrypted message</returns>
        public string Decrypt(string message, int key)
        {
            string decryptedMessage = "";

            foreach (char character in message)
            {
                decryptedMessage += Translate(character, -key);
            }

            return decryptedMessage;
        }

        /// <summary>
        /// Translates a char to another char based on a user given displacement value
        /// </summary>
        /// <param name="character">The character to be translated</param>
        /// <param name="key">The key value to be used in the translation process</param>
        /// <returns>A translated character</returns>
        private string Translate(char character, int key)
        {
            // Using a string instead of a char array for the domain, because it was simpler to create
            string lowerDomain = "abcdefghijklmnopqrstuvwxyz";
            string upperDomain = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            Dictionary<char, char> lowerDict = GetDictionary(lowerDomain, key);
            Dictionary<char, char> upperDict = GetDictionary(upperDomain, key);

            char translatedChar = character;

            if (lowerDomain.Contains(character.ToString()))
            {
                translatedChar = lowerDict[character];
            }
            else if (upperDomain.Contains(character.ToString()))
            {
                translatedChar = upperDict[character];
            }

            return translatedChar.ToString();
        }

        /// <summary>
        /// Returns a dictionary which represents a one-to-one mapping between two character sets
        /// </summary>
        /// <param name="domain">A string contaning all characters to be encyphered</param>
        /// <param name="key">The distance of the character displacement</param>
        /// <returns>A dictionary of one-to-one character mappings</returns>
        private Dictionary<char,char> GetDictionary(string domain, int key)
        {
            Dictionary<char, char> dictionary = new Dictionary<char, char>();

            foreach (char character in domain)
            {
                int indexOfCharacter = domain.IndexOf(character);
                int indexOfTranslatedCharacter = indexOfCharacter + key;

                // Handles index 'wraparound' if the index is out of bounds
                if (indexOfTranslatedCharacter > domain.Length - 1)
                {
                    indexOfTranslatedCharacter -= domain.Length;
                }
                if (indexOfTranslatedCharacter < 0)
                {
                    indexOfTranslatedCharacter += domain.Length;
                }

                dictionary.Add(character, domain[indexOfTranslatedCharacter]);
            }

            return dictionary;
        }
    }
}