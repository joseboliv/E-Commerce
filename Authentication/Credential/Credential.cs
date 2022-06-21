namespace Authentication
{
    using Authentication.Cryptography;
    using Authentication.Models;
    using System;
    using System.Security.Cryptography;

    public class Credential : ICredential
    {
        public object GenerateUserCredential(string password)
        {
            PasswordModel passwordCredential = new();
            (passwordCredential.Password, passwordCredential.CodeKey, passwordCredential.CodeIV) = CryptographyHelper.PasswordGenerate(password);
            passwordCredential.CreatedDate = DateTime.Now;
            passwordCredential.CodeHash = Convert.ToBase64String(HashGenerate(passwordCredential.CreatedDate).Hash);
            return passwordCredential;
        }

        public bool SignIn(object source, string password)
        {
            PasswordModel passwordCredential = source as PasswordModel;
            string myHash = Convert.ToBase64String(HashGenerate(passwordCredential.CreatedDate).Hash);
            if (myHash != passwordCredential.CodeHash) throw new Exception();
            if (CryptographyHelper.PasswordDescryptor(source) == password)
                return true;
            return false;
        }

        private static SHA512 HashGenerate(DateTime createdDate)
        {
            SHA512 myHash = new SHA512CryptoServiceProvider();
            myHash.ComputeHash(BitConverter.GetBytes(createdDate.DayOfYear));
            return myHash;
        }
    }
}
