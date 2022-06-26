namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(name: "Roles")]
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

        public virtual ICollection<RoleByActionByActionType> RoleByModuleByActionTypes { get; set; }

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
