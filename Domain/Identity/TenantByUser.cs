namespace Domain
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(name: "TenantByUsers")]
    public class TenantByUser : Identifier
    {
        public Guid UserId { get; set; }
        public Guid TenantId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        [ForeignKey(nameof(TenantId))]
        public virtual Tenant Tenant { get; set; }
    }
}