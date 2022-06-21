namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Module : Identifier
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public Guid ApplicationId { get; set; }

        [ForeignKey(nameof(ApplicationId))]
        public virtual Application Application { get; set; }

        public virtual ICollection<Action> Actions { get; set; }
    }
}
