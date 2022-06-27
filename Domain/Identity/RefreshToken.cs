namespace Domain.Identity
{
    using System;

    public class RefreshToken
    {
        public Guid UserId { get; set; }
        public string Toekn { get; set; }
        public DateTime DueDate { get; set; }
    }
}
