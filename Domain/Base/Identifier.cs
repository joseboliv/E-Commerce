namespace Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class Identifier
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        public Guid? CreatorUser { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
