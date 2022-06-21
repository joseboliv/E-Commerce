namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tenant : Identifier, IEquatable<Tenant>, IComparable<Tenant>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public virtual ICollection<TenantByUser> TenantByUsers { get; set; }
        public int CompareTo(Tenant other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(Tenant other)
        {
            throw new NotImplementedException();
        }
    }
}
