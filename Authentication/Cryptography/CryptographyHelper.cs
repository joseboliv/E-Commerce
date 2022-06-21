namespace Authentication.Cryptography
{
    using Authentication.Models;
    using Authentication.Resources;
    using System;
    using System.IO;
    using System.Security.Cryptography;

    public static class CryptographyHelper
    {
        public static (byte[], byte[], byte[]) PasswordGenerate(string password)
        {
            if (string.IsNullOrEmpty(password)) throw new ArgumentNullException(Message.password_is_null);
            MemoryStream memoryStream = new();
            RijndaelManaged algorithm = new();
            byte[] key = algorithm.Key;
            byte[] iv = algorithm.IV;
            ICryptoTransform encryptador = algorithm.CreateEncryptor(key, iv);
            CryptoStream crytoStream = new(memoryStream, encryptador, CryptoStreamMode.Write);
            StreamWriter streamWriter = new(crytoStream);
            streamWriter.Write(password);
            if (streamWriter != null) streamWriter.Close();
            if (crytoStream != null) crytoStream.Close();
            if (memoryStream != null) memoryStream.Close();
            if (algorithm != null) algorithm.Clear();
            return (memoryStream.ToArray(), key, iv);
        }

        public static string PasswordDescryptor(object source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var passwordModel = source as PasswordModel;
            if (passwordModel.Password == null || passwordModel.Password.Length <= 0) throw new ArgumentNullException(Message.password_is_null);
            if (passwordModel.CodeKey == null || passwordModel.CodeKey.Length <= 0) throw new ArgumentNullException(Message.key_is_null);
            if (passwordModel.CodeIV == null || passwordModel.CodeIV.Length <= 0) throw new ArgumentNullException(Message.iv_is_null);

            MemoryStream memoryStream = new(passwordModel.Password);
            RijndaelManaged algorithm = new() { Key = passwordModel.CodeKey, IV = passwordModel.CodeIV };
            ICryptoTransform decryptador = algorithm.CreateDecryptor(algorithm.Key, algorithm.IV);
            CryptoStream crytoStream = new(memoryStream, decryptador, CryptoStreamMode.Read);
            StreamReader streamReader = new(crytoStream);
            string passwordDecryptor = streamReader.ReadToEnd();
            if (streamReader != null) streamReader.Close();
            if (crytoStream != null) crytoStream.Close();
            if (memoryStream != null) memoryStream.Close();
            if (algorithm != null) algorithm.Clear();
            return passwordDecryptor;
        }
    }
}
