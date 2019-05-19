using System;

namespace JDOK.EncryptionLib
{
    /// <summary>
    /// Validates inputs for the Encryption Library
    /// </summary>
    public static class Validator
    {
        public static bool IsValidKey(string value)
        {
            return int.TryParse(value, out int result);
        }
    }
}