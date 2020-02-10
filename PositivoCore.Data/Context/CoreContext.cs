using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using PositivoCore.Data.Mappings;
using PositivoCore.Domain.Entities;
using PositivoCore.Shared.Helper;

namespace PositivoCore.Data.Context
{
    public class CoreContext : DbContext
    {
        public CoreContext(DbContextOptions options) : base(options) { }

        public CoreContext() { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Escola> Escolas { get; set; }
        public DbSet<NivelEnsino> NiveisEnsino { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<TurmaDisciplinaProfessor> TurmasDisciplinasProfessores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new DisciplinaMap());
            modelBuilder.ApplyConfiguration(new EscolaMap());
            modelBuilder.ApplyConfiguration(new NivelEnsinoMap());
            modelBuilder.ApplyConfiguration(new ProfessorMap());
            modelBuilder.ApplyConfiguration(new SerieMap());
            modelBuilder.ApplyConfiguration(new TurmaMap());
            modelBuilder.ApplyConfiguration(new TurmaDisciplinaProfessorMap());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {       
            optionsBuilder.UseSqlServer(HelperConnectionString.Get());
        }
    }
}
