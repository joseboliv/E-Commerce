namespace IdentityService.Context.Seeder
{
    using Authentication;
    using Authentication.Helpers;
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UserConfiguration : BaseConfiguration, IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(GetData());
        }

        public IEnumerable<User> GetData()
        {
            var credential = new Credential();
            var resultCredentials = credential.GenerateUserCredential("P@ssw0rd");
            var credentials = resultCredentials.Map(new User());
            var users = UserGenerate();
            users.Select(e =>
            {
                e.Password = credentials.Password;
                e.CodeKey = credentials.CodeKey;
                e.CodeIV = credentials.CodeIV;
                e.CodeHash = credentials.CodeHash;
                return e;
            }).ToList();
            return users;
        }

        public IEnumerable<User> UserGenerate() =>
            new List<User> {
                new User
                {
                    Id = CreaterUser,
                    Name = "Root",
                    Email ="admin@admin.com",
                    AccessFailedCount = 0,
                    ExternalProvider = false,
                    BirthDay = DateTime.Now,
                    PhoneNumber = string.Empty,
                    DueDate = DateTime.Now.AddDays(365),
                    DeviceToken = string.Empty,
                    CodeValidation = "0000",
                    IsValidation = true,
                    IsActive = true,
                    CreatorUser = CreaterUser
                }
            };
    }
}
