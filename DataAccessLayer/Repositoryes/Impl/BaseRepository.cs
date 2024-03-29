﻿using DataAccessLayer.Models;
using DataAccessLayer.Repositoryes.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositoryes.Impl
{
    public abstract class BaseRepository<T> : IRepository<T>
        where T : class
    {
        private readonly DbSet<T> _set;
        private readonly DbContext _context;
        public BaseRepository(DbContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }

        public BaseRepository()
        {
            _context = new StoresDbContext();
            _set = _context.Set<T>();
        }

        public void Create(T item)
        {
            _set.Add(item);
        }
        public void Delete(int id)
        {
            var item = Get(id);
            _set.Remove(item);
        }
        public IEnumerable<T> Find(
        Func<T, bool> predicate,
        int pageNumber = 0,
        int pageSize = 10)
        {
            return
            _set.Where(predicate)
            .Skip(pageSize * pageNumber)
            .Take(pageNumber)
            .ToList();
        }

        public T Get(int id)
        {
            return _set.Find(id);
        }
        public IEnumerable<T> GetAll()
        {
            return _set.ToList();
        }
        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            //T currItem = _set.FirstOrDefault(p => p == item);
            //currItem = item.;
            //_context.Entry(currItem).State = EntityState.Modified;
        }

        public bool Update(T item, string propertyName, object editedValue)
        {
            try
            {
                PropertyInfo propertyInfo = (item.GetType()).GetProperty(propertyName);
                T currItem = _set.FirstOrDefault(p => p == item);
                propertyInfo.SetValue(currItem, editedValue);
                //_set.Find(item);
                _context.Entry(currItem).State = EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}

