namespace Authentication.Cryptography
{
    using Authentication.Resources;
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Threading.Tasks;

    public static class CryptographyExtension
    {
        public static async Task<(byte[], byte[], byte[])> Encryptor(this string password)
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
            return await Task.FromResult((memoryStream.ToArray(), key, iv));
        }

        public static string Decryptor(this string oldPassword, byte[] password, byte[] key, byte[] iv)
        {
            if (password == null || password.Length <= 0) throw new ArgumentNullException(Message.password_is_null);
            if (key == null || key.Length <= 0) throw new ArgumentNullException(Message.key_is_null);
            if (iv == null || iv.Length <= 0) throw new ArgumentNullException(Message.iv_is_null);

            MemoryStream memoryStream = new(password);
            RijndaelManaged algorithm = new() { Key = key, IV = iv };
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
