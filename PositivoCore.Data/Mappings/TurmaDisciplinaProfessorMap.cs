using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PositivoCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PositivoCore.Data.Mappings
{
    public class TurmaDisciplinaProfessorMap : IEntityTypeConfiguration<TurmaDisciplinaProfessor>
    {
        public void Configure(EntityTypeBuilder<TurmaDisciplinaProfessor> builder)
        {
            builder.ToTable("TurmaDisciplinaProfessor");

            builder.HasKey(x => new { x.DisciplinaId, x.ProfessorId, x.TurmaId });
            

            builder.HasOne(x => x.Professor).WithMany(x => x.TurmasDisciplinasProfessores).HasForeignKey(x => x.ProfessorId);
            builder.HasOne(x => x.Turma).WithMany(x => x.TurmasDisciplinasProfessores).HasForeignKey(x => x.TurmaId);
            builder.HasOne(x => x.Disciplina).WithMany(x => x.TurmasDisciplinasProfessores).HasForeignKey(x => x.DisciplinaId);
            


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
