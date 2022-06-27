namespace IdentityService.Context.Seeder
{
    using Domain;
    using IdentityService.Enums;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;

    public class RoleConfiguration : BaseConfiguration, IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(GetData());
        }

        public IEnumerable<Role> GetData()
        {
            var roles = new List<Role>();

            foreach (string name in Enum.GetNames(typeof(RoleEnum)))
            {
                roles.Add(new Role()
                {
                    Id = (name == "Root") ? RoleRoot : Guid.NewGuid(),
                    Name = name,
                    CreatorUser = CreaterUser,
                    CreatedDate = CreatedDate,
                    IsActive = true,
                    IsDeleted = false,
                });
            }
            return roles;
        }
    }
}

