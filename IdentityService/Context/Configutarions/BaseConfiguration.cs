namespace IdentityService.Context.Seeder
{
    using System;

    public abstract class BaseConfiguration
    {
        public Guid CreaterUser { get; set; }
        public Guid RoleRoot { get; set; }
        public DateTime CreatedDate { get; set; }

        public BaseConfiguration()
        {
            CreaterUser = new Guid("94e1c8c7-9aba-4748-823b-71b6ff979f55");
            RoleRoot = new Guid("078166bb-934b-42c7-baa2-cc5d0769854f");
            CreatedDate = new DateTime(2022, 08, 26, 00, 00, 00);
        }
    }
}
