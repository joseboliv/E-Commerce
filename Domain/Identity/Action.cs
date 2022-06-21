using System;
namespace Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Action : Identifier
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public Guid ModuleId { get; set; }

        [ForeignKey(nameof(ModuleId))]
        public virtual Module Module { get; set; }

        public virtual ICollection<RoleByActionByActionType> RoleByModuleByActionTypes { get; set; }
    }
}
