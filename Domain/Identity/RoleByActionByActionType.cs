namespace Domain
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(name: "RoleByActionByActionTypes")]
    public class RoleByActionByActionType : Identifier
    {
        public Guid RoleId { get; set; }
        public Guid ActionId { get; set; }
        public Guid ActionTypeId { get; set; }

        [ForeignKey(nameof(RoleId))]
        public virtual Role Role { get; set; }

        [ForeignKey(nameof(ActionId))]
        public virtual Action Action { get; set; }

        [ForeignKey(nameof(ActionTypeId))]
        public virtual ActionType ActionType { get; set; }
    }
}
