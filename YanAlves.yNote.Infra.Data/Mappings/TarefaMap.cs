using System.Data.Entity.ModelConfiguration;
using YanAlves.yNote.Domain.Entities;

namespace YanAlves.yNote.Infra.Data.Mappings
{
    public class TarefaMap : EntityTypeConfiguration<Tarefa>
    {
        public TarefaMap()
        {
            HasKey(u => u.TarefaId);

            Property(u => u.TarefaId)
                .IsRequired();

            Property(u => u.Titulo)
                .IsRequired()
                .HasMaxLength(150);

            Property(u => u.UsuarioId)
                .IsRequired()
                .HasMaxLength(128);

            HasMany<Tag>(s => s.Tags)
                .WithMany(c => c.Tarefas)
                .Map(cs =>
                {
                    cs.MapLeftKey("TarefaId");
                    cs.MapRightKey("TagId");
                    cs.ToTable("Tarefa_Tag");
                });

            //HasRequired(u => u.Usuario).WithMany(x => x.Tarefas);

            ToTable("Tarefas");
        }
    }
}