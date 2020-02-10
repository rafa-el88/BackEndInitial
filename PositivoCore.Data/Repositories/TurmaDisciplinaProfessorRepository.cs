using PositivoCore.Domain.Entities;
using PositivoCore.Data.Context;
using PositivoCore.Application.Interface.Repository;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PositivoCore.Data.Repositories
{
    public class TurmaDisciplinaProfessorRepository : ITurmaDisciplinaProfessorRepository
    {

        private readonly CoreContext _context;
        private readonly DbSet<TurmaDisciplinaProfessor> _DbSet;
        public TurmaDisciplinaProfessorRepository(CoreContext context)
        {
            _context = context;
            _DbSet = _context.Set<TurmaDisciplinaProfessor>();
        }

        public List<TurmaDisciplinaProfessor> InsertList(List<TurmaDisciplinaProfessor> obj)
        {
            obj.ForEach(n => _DbSet.Add(n));
            _context.SaveChanges();
            return obj;
        }
    }
}