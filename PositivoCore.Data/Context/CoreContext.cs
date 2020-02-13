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
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Colecao> Colecoes { get; set; }
        public DbSet<ConvidadosEvento> ConvidadosEvento { get; set; }
        public DbSet<DestinatarioMensagem> DestinatarioMensagens { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Escola> Escolas { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; }
        public DbSet<NivelEnsino> NiveisEnsino { get; set; }
        public DbSet<Periodo> Periodo { get; set; }
        public DbSet<PeriodoLetivoConfiguracao> PeriodoLetivoConfiguracao { get; set; }
        public DbSet<PeriodoLetivoTipo> PeriodoLetivoTipo { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Responsavel> Responsavel { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<TurmaDisciplinaProfessor> TurmasDisciplinasProfessores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();
            modelBuilder.ApplyConfiguration(new AdministradorMap());
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new ColecaoMap());
            modelBuilder.ApplyConfiguration(new ConvidadosEventoMap());
            modelBuilder.ApplyConfiguration(new DestinatarioMensagemMap());
            modelBuilder.ApplyConfiguration(new DisciplinaMap());
            modelBuilder.ApplyConfiguration(new EscolaMap());
            modelBuilder.ApplyConfiguration(new MensagemMap());
            modelBuilder.ApplyConfiguration(new NivelEnsinoMap());
            modelBuilder.ApplyConfiguration(new PeriodoMap());
            modelBuilder.ApplyConfiguration(new PeriodoLetivoConfiguracaoMap());
            modelBuilder.ApplyConfiguration(new PeriodoLetivoTipoMap());
            modelBuilder.ApplyConfiguration(new ProfessorMap());
            modelBuilder.ApplyConfiguration(new SerieMap());
            modelBuilder.ApplyConfiguration(new TurmaMap());
            modelBuilder.ApplyConfiguration(new TurmaDisciplinaProfessorMap());
            modelBuilder.ApplyConfiguration(new ResponsavelMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(HelperConnectionString.Get());
        }
    }
}
