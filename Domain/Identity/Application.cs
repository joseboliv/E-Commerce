﻿namespace Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Application : Identifier
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Version { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public virtual ICollection<Module> Modules { get; set; }
    }
}
