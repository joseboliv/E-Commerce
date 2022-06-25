namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User : Identifier
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public byte[] Password { get; set; }

        [Required]
        public byte[] CodeKey { get; set; }

        [Required]
        public byte[] CodeIV { get; set; }

        [StringLength(250)]
        public string CodeHash { get; set; }

        public short? AccessFailedCount { get; set; }

        [Required]
        public bool ExternalProvider { get; set; }

        public DateTime? BirthDay { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime? DueDate { get; set; }

        public string DeviceToken { get; set; }

        [StringLength(8)]
        public string CodeValidation { get; set; }

        public bool IsValidation { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;

        public Guid? UserModifier { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ICollection<RoleByUser> RolesByUsers { get; set; }
        public virtual ICollection<UserByProvider> UserByProviders { get; set; }
        public virtual ICollection<TenantByUser> TenantByUsers { get; set; }
    }
}
