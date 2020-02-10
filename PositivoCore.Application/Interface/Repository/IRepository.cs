using PositivoCore.Shared.Entities;
using System;
using System.Collections.Generic;

namespace PositivoCore.Application.Interface.Repository
{
    public interface IRepository<T> where T : Entity
    {
        void Insert(T obj);
        void Update(T obj);
        void Delete(T obj);
        List<T> UpdateList(List<T> obj);
        T Find(Guid id);
        List<T> InsertList(List<T> obj);
        void DeleteList(List<T> obj);
    }
}
