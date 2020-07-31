using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using XFSignalRApi.Data;
using XFSignalRApi.Models.Base;

namespace XFSignalRApi.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ChatContext _context;
        private DbSet<T> _dataset;

        public GenericRepository(ChatContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                _dataset.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public void Delete(int id)
        {
            var result = _dataset.SingleOrDefault(p => p.Id.Equals(id));

            try
            {
                if (result != null)
                {
                    _dataset.Remove(result);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Exists(int? id)
        {
            return _dataset.Any(p => p.Id.Equals(id));
        }

        public IList<T> FindAll()
        {
            return _dataset.ToList();
        }

        public T FindByID(int id)
        {
            return _dataset.SingleOrDefault(p => p.Id.Equals(id));
        }

        public T Update(T item)
        {
            if (!Exists(item.Id))
                return null;

            var result = _dataset.SingleOrDefault(p => p.Id.Equals(item.Id));
            try
            {
                _context.Entry(result).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }
    }
}

