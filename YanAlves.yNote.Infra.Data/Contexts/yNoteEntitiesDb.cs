using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YanAlves.yNote.Domain.Entities;
using YanAlves.yNote.Domain.Enums;
using YanAlves.yNote.Infra.Data.Mappings;

namespace YanAlves.yNote.Infra.Data.Contexts
{
    public class yNoteEntitiesDb : DbContext
    {
        public yNoteEntitiesDb()
            : base("name=yNoteEntitiesDb")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<Blog4EntitiesDb, Migrations.Configuration>("Blog4EntitiesDb"));
            //Database.SetInitializer(new DropCreateDatabaseAlways<Blog4EntitiesDb>());
            Database.SetInitializer<yNoteEntitiesDb>(null);
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Conventions
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // General Custom Context Properties
            modelBuilder.Properties()
                .Configure(p => p.HasDatabaseGeneratedOption
                (DatabaseGeneratedOption.None));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            AddConfigMap(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void AddConfigMap(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoriaMap());
            modelBuilder.Configurations.Add(new TagMap());
            modelBuilder.Configurations.Add(new TarefaMap());
        }
    }
}
