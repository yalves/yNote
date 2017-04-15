using System.Data.Entity.ModelConfiguration;
using YanAlves.yNote.Domain.Entities;

namespace YanAlves.yNote.Infra.Data.Mappings
{
    public class TagMap : EntityTypeConfiguration<Tag>
    {
        public TagMap()
        {
            ToTable("Tags");

            HasKey(u => u.TagId);

            Property(u => u.TagId)
                .IsRequired();

            Property(u => u.Titulo)
                .IsRequired()
                .HasMaxLength(150);

            Property(u => u.UsuarioId)
                .IsRequired();
        }
    }
}