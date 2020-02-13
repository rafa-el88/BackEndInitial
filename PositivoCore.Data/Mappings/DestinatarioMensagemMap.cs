using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PositivoCore.Domain.Entities;

namespace PositivoCore.Data.Mappings
{
    public class DestinatarioMensagemMap : IEntityTypeConfiguration<DestinatarioMensagem>
    {
        public void Configure(EntityTypeBuilder<DestinatarioMensagem> builder)
        {
            builder.ToTable("DestinatarioMensagem");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.TipoPerfil)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.IdMensagem)
                .IsRequired();

            builder.HasOne<Mensagem>(x => x.Mensagem)                
                .WithMany(s => s.DestinatarioMensagens)
                .HasForeignKey(z => z.IdMensagem);

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
