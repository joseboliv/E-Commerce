namespace IdentityService.Context.Seeder
{
    using Authentication.Enums;
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;

    public class ActionTypeConfiguration : BaseConfiguration, IEntityTypeConfiguration<ActionType>
    {
        public void Configure(EntityTypeBuilder<ActionType> builder)
        {
            builder.HasData(GetData());
        }

        public IEnumerable<ActionType> GetData()
        {
            var actionTypes = new List<ActionType>();

            foreach (PermisionsCode permisions in (PermisionsCode[])Enum.GetValues(typeof(PermisionsCode)))
            {
                actionTypes.Add(new ActionType()
                {
                    Id = Guid.NewGuid(),
                    Name = permisions.ToString(),
                    PermissionCode = ((short)permisions),
                    IsActive = true,
                    CreatorUser = CreaterUser,
                    CreatedDate = CreatedDate
                });
            }
            return actionTypes;
        }
    }
}
