namespace IdentityService.Context
{
    using Domain;
    using IdentityService.Context.Seeder;
    using Infrastructure.EfCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MainDbContextDesignFactory : DbContextDesignFactoryBase<IdentityDbContext>
    {
    }

    public class IdentityDbContext : AppDbContextBase
    {
        public DbSet<Action> Action { get; set; }
        public DbSet<ActionType> ActionType { get; set; }
        public DbSet<Application> Application { get; set; }
        public DbSet<ExternalProvider> ExternalProvider { get; set; }
        public DbSet<Module> Module { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RoleByActionByActionType> RoleByActionByActionType { get; set; }
        public DbSet<RoleByUser> RoleByUser { get; set; }
        public DbSet<Setting> Setting { get; set; }
        public DbSet<Tenant> Tenant { get; set; }
        public DbSet<TenantByUser> TenantByUser { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserByProvider> UserByProvider { get; set; }

        public IdentityDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<Action>(ConfigureActionAttribute)
                .Entity<ActionType>(ConfigureActionTypeAttribute)
                .Entity<Application>(ConfigureApplicationAttribute)
                .Entity<ExternalProvider>(ConfigureExternalProviderAttribute)
                .Entity<Module>(ConfigureModuleAttribute)
                .Entity<Role>(ConfigureRoleAttribute)
                .Entity<RoleByActionByActionType>(ConfigureRoleByActionByActionTypeAttribute)
                .Entity<RoleByUser>(ConfigureRoleByUserAttribute)
                .Entity<Setting>(ConfigureSettingAttribute)
                .Entity<Tenant>(ConfigureTenantAttribute)
                .Entity<TenantByUser>(ConfigureTenantByUserAttribute)
                .Entity<User>(ConfigureUserAttribute)
                .Entity<UserByProvider>(ConfigureUserByProviderAttribute);

            modelBuilder
                .ApplyConfiguration(new UserConfiguration())
                .ApplyConfiguration(new RoleConfiguration())
                .ApplyConfiguration(new RoleByUserConfiguration())
                .ApplyConfiguration(new ActionTypeConfiguration());

        }

        private void ConfigureActionAttribute(EntityTypeBuilder<Action> builder) { }
        private void ConfigureActionTypeAttribute(EntityTypeBuilder<ActionType> builder) { }
        private void ConfigureApplicationAttribute(EntityTypeBuilder<Application> builder) { }
        private void ConfigureExternalProviderAttribute(EntityTypeBuilder<ExternalProvider> builder) { }
        private void ConfigureModuleAttribute(EntityTypeBuilder<Module> builder) { }
        private void ConfigureRoleAttribute(EntityTypeBuilder<Role> builder) { }
        private void ConfigureRoleByActionByActionTypeAttribute(EntityTypeBuilder<RoleByActionByActionType> builder) { }
        private void ConfigureRoleByUserAttribute(EntityTypeBuilder<RoleByUser> builder)
        {
            builder.HasKey(e => new { e.UserId, e.RoleId, e.Id });
        }
        private void ConfigureSettingAttribute(EntityTypeBuilder<Setting> builder) { }
        private void ConfigureTenantAttribute(EntityTypeBuilder<Tenant> builder) { }
        private void ConfigureTenantByUserAttribute(EntityTypeBuilder<TenantByUser> builder) { }
        private void ConfigureUserAttribute(EntityTypeBuilder<User> builder) { }
        private void ConfigureUserByProviderAttribute(EntityTypeBuilder<UserByProvider> builder)
        {
            builder.HasKey(e => new { e.UserId, e.ProviderId });
            //builder.HasIndex(e => new { e.UserId, e.ProviderId }).HasName("UQ_UserByProvider").IsUnique();
        }
    }
}
