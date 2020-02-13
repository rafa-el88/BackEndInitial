using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PositivoCore.Domain.Entities;

namespace PositivoCore.Data.Mappings
{
    public class ConvidadosEventoMap : IEntityTypeConfiguration<ConvidadosEvento>
    {
        public void Configure(EntityTypeBuilder<ConvidadosEvento> builder)
        {
            builder.ToTable("ConvidadosEvento");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.IdConvidado)
                .IsRequired();

            builder.Property(c => c.TipoPerfil)
                .HasColumnType("int");

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