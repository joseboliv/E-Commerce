namespace Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ActionType : Identifier
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public short PermissionCode { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public virtual ICollection<RoleByActionByActionType> RoleByModuleByActionTypes { get; set; }
    }
}
