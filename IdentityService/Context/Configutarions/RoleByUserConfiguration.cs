namespace IdentityService.Context.Seeder
{
    using Domain;
    using IdentityService.Enums;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;

    public class RoleByUserConfiguration : BaseConfiguration, IEntityTypeConfiguration<RoleByUser>
    {
        public void Configure(EntityTypeBuilder<RoleByUser> builder)
        {
            builder.HasData(GetData());
        }

        public IEnumerable<RoleByUser> GetData()
        {
            var roles = new List<RoleByUser>();

            foreach (string name in Enum.GetNames(typeof(RoleEnum)))
            {
                roles.Add(new RoleByUser()
                {
                    Id = Guid.NewGuid(),
                    UserId = CreaterUser,
                    RoleId = RoleRoot,
                    IsActive = true,
                    CreatedDate = CreatedDate,
                    CreatorUser = CreaterUser
                });
            }
            return roles;
        }
    }
}
