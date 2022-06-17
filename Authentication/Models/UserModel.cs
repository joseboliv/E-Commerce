namespace Authentication.Models
{
    using System;

    public class UserModel
    {
        public Guid Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual byte[] Password { get; set; }
        public virtual string CodeHash { get; set; }
        public virtual byte[] CodeIV { get; set; }
        public virtual byte[] CodeKey { get; set; }
        public virtual short AccessFailedCount { get; set; }
        public virtual string Role { get; set; }
        public virtual DateTime DueDate { get; set; }
        public virtual DateTime CreatedDate { get; set; }
    }
}