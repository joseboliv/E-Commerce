namespace Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(name: "Users")]
    public class RoleByUser : Identifier, IEquatable<RoleByUser>, IComparable<RoleByUser>
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid RoleId { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        [ForeignKey(nameof(RoleId))]
        public virtual Role Role { get; set; }

        public int CompareTo(RoleByUser other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(RoleByUser other)
        {
            throw new NotImplementedException();
        }
    }
}
