namespace Authentication.Models
{
    using System;

    public class UserModel
    {
        public Guid Id { get; set; }
        public virtual string UserName { get; set; }
    }
}