using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PositivoCore.Application.Interface.Repository;
using PositivoCore.Data.Context;
using PositivoCore.Shared.Entities;

namespace PositivoCore.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly CoreContext _context;
        private readonly DbSet<T> _DbSet;

        public Repository(CoreContext context)
        {
            _context = context;
            _DbSet = _context.Set<T>();
        }

        public void Delete(T obj)
        {
            _DbSet.Remove(obj);
            _context.SaveChanges();
        }

        public void DeleteList(List<T> obj)
        {
            obj.ForEach(n => _DbSet.Remove(n));
            _context.SaveChanges();
        }

        public T Find(Guid id)
        {
          return _DbSet.Find(id);
        }

        public void Insert(T obj)
        {
           _DbSet.Add(obj);
           _context.SaveChanges();
        }

        public List<T> InsertList(List<T> obj)
        {
            obj.ForEach(n => _DbSet.Add(n));
            _context.SaveChanges();
            return obj;
        }

        public void Update(T obj)
        {
            _context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public List<T> UpdateList(List<T> obj)
        {
            obj.ForEach(n => _DbSet.Update(n));
            _context.SaveChanges();
            return obj;
        }
    }
}