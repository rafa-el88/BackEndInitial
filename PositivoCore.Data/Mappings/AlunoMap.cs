﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PositivoCore.Domain.Entities;

namespace PositivoCore.Data.Mappings
{
    public class AlunoMap : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("Aluno");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(c => c.Cpf)
                .HasColumnType("nvarchar(20)")
                .HasMaxLength(20)
                .IsRequired(false);

            builder.Property(c => c.Matricula)
                .HasColumnType("nvarchar(20)")
                .HasMaxLength(20)
                .IsRequired(false);

            builder.Property(c => c.Apelido)
                .HasColumnType("nvarchar(20)")
                .HasMaxLength(20)
                .IsRequired(false);

            builder.Property(c => c.DataNascimento)
                .HasColumnType("DateTime")
                .IsRequired(false);

            builder.Property(c => c.Genero)
                .HasColumnType("int")
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
