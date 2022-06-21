namespace Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class Identifier : AuditableCreate
    {
        [Required]
        public Guid Id { get; set; }

        public Guid? UserCreated { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
