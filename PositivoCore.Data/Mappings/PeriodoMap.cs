using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PositivoCore.Domain.Entities;

namespace PositivoCore.Data.Mappings
{
    public class PeriodoMap : IEntityTypeConfiguration<Periodo>
    {
        public void Configure(EntityTypeBuilder<Periodo> builder)
        {
            builder.ToTable("Periodo");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .HasColumnType("nvarchar(20)")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.IdPeriodoLetivoTipo)
                .IsRequired();

            builder.HasOne<PeriodoLetivoTipo>(x => x.PeriodoLetivoTipo)
                .WithMany(s => s.Periodos)
                .HasForeignKey(z => z.IdPeriodoLetivoTipo);

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
                 .WithOne(z => z.Periodo);
        }
    }
}
