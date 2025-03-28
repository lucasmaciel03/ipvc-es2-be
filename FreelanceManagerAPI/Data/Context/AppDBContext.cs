using FreelanceManagerAPI.Data.Entities;
using FreelanceManagerAPI.Data.Entities.Base;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FreelanceManagerAPI.Data.Context
{
    public class AppDBContext : IdentityDbContext<ApplicationUser>
    {
        protected readonly IHttpContextAccessor _httpAccessor;

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        { }

        public AppDBContext(DbContextOptions<AppDBContext> options, IHttpContextAccessor httpAccessor) : base(options)
        {
            _httpAccessor = httpAccessor;
        }
        #region database tables
        public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectUser> ProjectUsers { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<ProjectInvite> ProjectInvites { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            SetDefaultPropertiesOnEntities();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetDefaultPropertiesOnEntities();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void SetDefaultPropertiesOnEntities()
        {
            var entries = ChangeTracker.Entries<EntityBase>();

            if (entries != null)
            {
                string identityName = _httpAccessor.HttpContext?.User?.Identity?.Name ?? "unknown";

                foreach (var entry in entries)
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Property(prop => prop.RowVersion).IsModified = false;

                        entry.Entity.UpdatedAt = null;
                        entry.Entity.CreatedAt = DateTime.Now;
                        entry.Entity.CreatedBy = identityName ?? "unknown";
                    }

                    if (entry.State == EntityState.Modified)
                    {
                        entry.Property(prop => prop.CreatedAt).IsModified = false;
                        entry.Property(prop => prop.CreatedBy).IsModified = false;
                        entry.Property(prop => prop.RowVersion).IsModified = false;

                        entry.Entity.UpdatedAt = DateTime.Now;
                        entry.Entity.UpdatedBy = identityName ?? "unknown";
                    }
                }
            }
        }
    }
}