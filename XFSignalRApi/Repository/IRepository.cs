using System;
using System.Collections.Generic;
using XFSignalRApi.Models.Base;

namespace XFSignalRApi.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindByID(int id);
        IList<T> FindAll();
        T Update(T item);
        void Delete(int id);
        bool Exists(int? id);
    }
}
