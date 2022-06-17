namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Role : Identifier, IEquatable<Role>, IComparable<Role>
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public bool IsDeleted { get; set; }

        public Guid? UserModifier { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ICollection<RoleByUser> RolesByUsers { get; set; }

        public int CompareTo(Role other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(Role other)
        {
            throw new NotImplementedException();
        }
    }
}
