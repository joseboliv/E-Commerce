namespace Authentication
{
    using Authentication.Cryptography;
    using Authentication.Helpers;
    using Authentication.Models;
    using Authentication.Resources;
    using System;
    using System.Security.Cryptography;
    using System.Threading.Tasks;

    public class Credential : ICredential
    {
        public Credential() { }

        public async Task<T> GenerateUserCredential<T>(string username, string password)
        {
            UserModel user = new();
            user.UserName = username;
            user.CreatedDate = DateTime.Now;
            await EncryptorPass(password, user);
            user.CodeHash = Convert.ToBase64String(HashGenerate(user).Hash);
            return user.ToConvertObjects<T>();
        }

        public bool SignIn<T>(T source, string password)
        {
            UserModel user = source.ToConvertObjects<UserModel>();
            string myHash = Convert.ToBase64String(HashGenerate(user).Hash);
            if (myHash != user.CodeHash) throw new Exception();
            if (password.Decryptor(user.Password, user.CodeKey, user.CodeIV) == password)
                return true;
            return false;
        }

        public async Task<(byte[], byte[], byte[], string)> ChangedPassword<T>(T source, string oldPassword, string newPassword)
        {
            UserModel user = source.ToConvertObjects<UserModel>();
            await EncryptorPass(newPassword, user);

            if (newPassword.Decryptor(user.Password, user.CodeKey, user.CodeIV) == oldPassword)
                throw new ArgumentException(Message.the_password_must_be_different_from_your_last_password);

            user.CodeHash = Convert.ToBase64String(HashGenerate(user).Hash);
            return (user.Password, user.CodeKey, user.CodeIV, user.CodeHash);
        }

        private static async Task EncryptorPass(string newPassword, UserModel user) =>
            (user.Password, user.CodeKey, user.CodeIV) = await newPassword.Encryptor();

        private static SHA512 HashGenerate(UserModel user)
        {
            SHA512 myHash = new SHA512CryptoServiceProvider();
            myHash.ComputeHash(BitConverter.GetBytes(user.CreatedDate.DayOfYear));
            return myHash;
        }
    }
}
