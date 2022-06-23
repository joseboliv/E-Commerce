namespace Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class Identifier
    {
        [Required]
        public Guid Id { get; set; }

        public Guid? UserCreated { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
