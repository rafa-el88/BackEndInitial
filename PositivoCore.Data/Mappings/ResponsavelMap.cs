
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PositivoCore.Domain.Entities;

namespace PositivoCore.Data.Mappings
{
    public class ResponsavelMap : IEntityTypeConfiguration<Responsavel>
    {
        public void Configure(EntityTypeBuilder<Responsavel> builder)
        {
            builder.ToTable("Responsavel");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                    .HasColumnType("nvarchar(255)")
                    .HasMaxLength(255)
                    .IsRequired();
                    
            builder.Property(c => c.Email)
                    .HasColumnType("nvarchar(255)")
                    .HasMaxLength(255);

            builder.Property(c => c.CPF)
                    .HasColumnType("nvarchar(45)")
                    .HasMaxLength(45);

            builder.Property(c => c.DataNascimento)
                    .HasColumnType("DateTime")
                    .IsRequired(false); 

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
