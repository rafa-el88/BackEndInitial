using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PositivoCore.Domain.Entities;

namespace PositivoCore.Data.Mappings
{
    public class EscolaMap : IEntityTypeConfiguration<Escola>
    {
        public void Configure(EntityTypeBuilder<Escola> builder)
        {
            builder.ToTable("Escola");
            builder.HasKey(c => c.Id);

            builder.OwnsOne(c => c.CNPJ, x =>
            {
                x.Property(y => y.Number)
                    .HasColumnName("CNPJ")
                    .HasColumnType("nvarchar(14)")
                    .HasMaxLength(14)
                    .IsRequired();
            });

            builder.Property(c => c.Nome)
                .HasColumnType("nvarchar(255)")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(c => c.RazaoSocial)
                .HasColumnType("nvarchar(255)")
                .HasMaxLength(255);

            builder.Property(c => c.INEP)
                .HasColumnType("nvarchar(45)")
                .HasMaxLength(45);

            builder.Property(c => c.INEPDescricao)
                .HasColumnType("nvarchar(45)")
                .HasMaxLength(45);

            builder.Property(c => c.CodSGE)
                .HasColumnType("nvarchar(45)")
                .HasMaxLength(45);

            builder.Property(c => c.InscricaoEstadual)
                .HasColumnType("nvarchar(45)")
                .HasMaxLength(45);

            builder.Property(c => c.TipoEscola)
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

            builder
                .HasMany(x => x.Turmas)
                .WithOne(z => z.Escola);

            builder
                .HasMany(x => x.PeriodoLetivoConfiguracoes)
                .WithOne(z => z.Escola);
        }
    }
}
