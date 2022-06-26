namespace Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(name: "ExternalProvides")]
    public class ExternalProvider : Identifier
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public ICollection<UserByProvider> UserByProviders { get; set; }
    }
}
