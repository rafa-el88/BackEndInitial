using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PositivoCore.Domain.Entities;

namespace PositivoCore.Data.Mappings
{
    public class NivelEnsinoMap : IEntityTypeConfiguration<NivelEnsino>
    {
        public void Configure(EntityTypeBuilder<NivelEnsino> builder)
        {
            builder.ToTable("NivelEnsino");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .HasColumnType("nvarchar(255)")
                .HasMaxLength(255)
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
                .HasMany(x => x.Series)
                .WithOne(z => z.NivelEnsino);
        }
    }
}
