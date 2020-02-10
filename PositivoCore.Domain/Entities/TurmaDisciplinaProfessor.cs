using PositivoCore.Shared.Entities;
using System;


namespace PositivoCore.Domain.Entities
{
    public class TurmaDisciplinaProfessor : JoinEntity
    {
        public TurmaDisciplinaProfessor()
        {
                
        }

        public TurmaDisciplinaProfessor(Guid turmaId, Guid disciplinaId, Guid professorId)
        {
            TurmaId = turmaId;
            DisciplinaId = disciplinaId;
            ProfessorId = professorId;
        }

        public Guid TurmaId { get; protected set; }
        public Guid DisciplinaId { get; protected set; }
        public Guid ProfessorId { get; protected set; }

        public virtual Turma Turma { get; set; }
        public virtual Disciplina Disciplina { get; set; }
        public virtual Professor Professor { get; set; }

    }
}
