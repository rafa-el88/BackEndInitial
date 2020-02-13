using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PositivoCore.Domain.Entities;

namespace PositivoCore.Data.Mappings
{
    public class ColecaoMap : IEntityTypeConfiguration<Colecao>
    {
        public void Configure(EntityTypeBuilder<Colecao> builder)
        {
            builder.ToTable("Colecao");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Padrao)
                .HasColumnType("bit")
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(c => c.DataCadastro)
                .HasColumnType("DateTime")
                .IsRequired();

            builder.Property(c => c.DataAtualizacao)
                .HasColumnType("DateTime")
                .IsRequired();

            builder.Property(c => c.Ativo)
                .HasColumnType("bit")
                .IsRequired();
        }
    }
}
