using System;

namespace Authentication.Models
{
    public class PasswordModel
    {
        public PasswordModel() { }

        public PasswordModel(byte[] Password, byte[] CodeKey, byte[] CodeIV)
        {
            this.Password = Password;
            this.CodeKey = CodeKey;
            this.CodeIV = CodeIV;
        }
        
        public PasswordModel(byte[] Password, byte[] CodeKey, byte[] CodeIV, string CodeHash, DateTime CreatedDate)
        {
            this.Password = Password;
            this.CodeKey = CodeKey;
            this.CodeIV = CodeIV;
            this.CodeHash = CodeHash;
            this.CreatedDate = CreatedDate;
        }

        public virtual byte[] Password { get; set; }
        public virtual byte[] CodeIV { get; set; }
        public virtual byte[] CodeKey { get; set; }
        public virtual string CodeHash { get; set; }
        public virtual DateTime CreatedDate { get; set; }
    }
}