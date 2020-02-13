using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PositivoCore.Domain.Entities;

namespace PositivoCore.Data.Mappings
{
    public class PeriodoLetivoConfiguracaoMap : IEntityTypeConfiguration<PeriodoLetivoConfiguracao>
    {
        public void Configure(EntityTypeBuilder<PeriodoLetivoConfiguracao> builder)
        {
            builder.ToTable("PeriodoLetivoConfiguracao");
            builder.HasKey(c => c.Id);            

            builder.Property(x => x.IdPeriodoLetivoTipo)
                .IsRequired();
            builder.Property(x => x.IdPeriodo)
                .IsRequired();
            builder.Property(x => x.IdNivelEnsino)
                .IsRequired();
            builder.Property(x => x.IdEscola)
                .IsRequired();

            builder.HasOne<PeriodoLetivoTipo>(x => x.PeriodoLetivoTipo)
                .WithMany(s => s.PeriodoLetivoConfiguracoes)
                .HasForeignKey(z => z.IdPeriodoLetivoTipo)
                .OnDelete(DeleteBehavior.NoAction);
            

            builder.HasOne<Periodo>(x => x.Periodo)
                .WithMany(s => s.PeriodoLetivoConfiguracoes)
                .HasForeignKey(z => z.IdPeriodo)
                .OnDelete(DeleteBehavior.NoAction);
            

            builder.HasOne<NivelEnsino>(x => x.NivelEnsino)
                .WithMany(s => s.PeriodoLetivoConfiguracoes)
                .HasForeignKey(z => z.IdNivelEnsino)
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne<Escola>(x => x.Escola)
                .WithMany(s => s.PeriodoLetivoConfiguracoes)
                .HasForeignKey(z => z.IdEscola)
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
        }
    }
}
