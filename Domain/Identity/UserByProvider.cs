namespace Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(name: "UserByProviders")]
    public class UserByProvider
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid ProviderId { get; set; }

        public DateTime DateCreated { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        [ForeignKey(nameof(ProviderId))]
        public virtual ExternalProvider Role { get; set; }
    }
}
