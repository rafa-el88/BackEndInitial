using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PositivoCore.Domain.Entities;

namespace PositivoCore.Data.Mappings
{
    public class MensagemMap : IEntityTypeConfiguration<Mensagem>
    {
        public void Configure(EntityTypeBuilder<Mensagem> builder)
        {
            builder.ToTable("Mensagem");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Assunto)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Texto)
                .IsRequired();

            builder.Property(c => c.PermiteResposta)
                .HasColumnType("bit")
                .IsRequired();

            builder.HasOne(x => x.MensagemVinculada)
                .WithMany(s => s.MensagemVinculadas)
                .HasForeignKey(z => z.IdMensagemVinculada)
                .OnDelete(DeleteBehavior.NoAction);

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
                .HasMany(x => x.DestinatarioMensagens)
                .WithOne(z => z.Mensagem);
        }
    }
}
