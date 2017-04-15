using System.Data.Entity;
using YanAlves.yNote.Domain.Entities;
using YanAlves.yNote.Infra.Data.Mappings;

namespace YanAlves.yNote.Infra.Data.Contexts
{
    public class IdentityEntityContextDb : DbContext
    {
        public IdentityEntityContextDb()
            : base("name=yNoteUsersDb")
        {
            
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsuarioMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}