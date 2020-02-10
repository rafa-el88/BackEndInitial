using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PositivoCore.Domain.Entities;

namespace PositivoCore.Data.Mappings
{
    public class TurmaMap : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.ToTable("Turma");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .HasColumnType("nvarchar(255)")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.IdEscola)
                .IsRequired();

                

            builder.HasOne<Escola>(x => x.Escola)
                .WithMany(s => s.Turmas)
                .HasForeignKey(z => z.IdEscola);

            builder.Property(x => x.IdSerie)
                .IsRequired();

            builder.HasOne<Serie>(x => x.Serie)
                .WithMany(s => s.Turmas)
                .HasForeignKey(z => z.IdSerie);

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
