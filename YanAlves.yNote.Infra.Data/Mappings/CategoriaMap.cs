using System.Data.Entity.ModelConfiguration;
using YanAlves.yNote.Domain.Entities;

namespace YanAlves.yNote.Infra.Data.Mappings
{
    public class CategoriaMap : EntityTypeConfiguration<Categoria>
    {
        public CategoriaMap()
        {
            HasKey(u => u.CategoriaId);

            Property(u => u.CategoriaId)
                .IsRequired();

            Property(u => u.Titulo)
                .IsRequired()
                .HasMaxLength(150);

            Property(u => u.Descricao)
                .IsOptional()
                .HasMaxLength(256);

            Property(u => u.UsuarioId)
                .IsRequired();

            ToTable("Categorias");
        }
    }
}