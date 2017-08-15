using System;
using System.Linq;
using System.Reflection;
using EFCoreGlobalQueryFilters.Services;
using Microsoft.EntityFrameworkCore;

namespace EFCoreGlobalQueryFilters.Models
{
    public class PlaylistContext : DbContext
    {
        private Guid _tenantId;
        private readonly IEntityTypeProvider _entityTypeProvider;

        public virtual DbSet<Playlist> Playlists { get; set; }
        public virtual DbSet<Song> Songs { get; set; }

        public PlaylistContext(DbContextOptions<PlaylistContext> options,
                               ITenantProvider tenantProvider,
                               IEntityTypeProvider entityTypeProvider)
            : base(options)
        {
            _tenantId = tenantProvider.GetTenantId();
            _entityTypeProvider = entityTypeProvider;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Playlist>().HasKey(e => e.Id);
            modelBuilder.Entity<Playlist>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<Song>().HasKey(e => e.Id);
            modelBuilder.Entity<Song>().HasQueryFilter(e => !e.IsDeleted);

            foreach (var type in _entityTypeProvider.GetEntityTypes())
            {
                var method = SetGlobalQueryMethod.MakeGenericMethod(type);
                method.Invoke(this, new object[] { modelBuilder });
            }

            base.OnModelCreating(modelBuilder);
        }

        static readonly MethodInfo SetGlobalQueryMethod = typeof(PlaylistContext).GetMethods(BindingFlags.Public | BindingFlags.Instance)
                                                                .Single(t => t.IsGenericMethod && t.Name == "SetGlobalQuery");

        public void SetGlobalQuery<T>(ModelBuilder builder) where T : BaseEntity
        {
            builder.Entity<T>().HasKey(e => e.Id);
            //Debug.WriteLine("Adding global query for: " + typeof(T));
            builder.Entity<T>().HasQueryFilter(e => e.TenantId == _tenantId && !e.IsDeleted);
        }        
    }
}
