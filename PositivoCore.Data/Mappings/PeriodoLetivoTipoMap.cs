using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PositivoCore.Domain.Entities;

namespace PositivoCore.Data.Mappings
{
    public class PeriodoLetivoTipoMap : IEntityTypeConfiguration<PeriodoLetivoTipo>
    {
        public void Configure(EntityTypeBuilder<PeriodoLetivoTipo> builder)
        {

            builder.ToTable("PeriodoLetivoTipo");
            builder.HasKey(c => c.Id);            

            builder.Property(c => c.Nome)
                .HasColumnType("nvarchar(30)")
                .HasMaxLength(30)
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

            builder
                .HasMany(x => x.PeriodoLetivoConfiguracoes)
                .WithOne(z => z.PeriodoLetivoTipo);
        }
    }
}
