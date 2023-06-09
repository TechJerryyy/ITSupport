﻿using ITSupport.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSupport.SQL.Repository
{
    public class SQLRepository<T> : Core.Interfaces.IRepository<T> where T : BaseEntity
    {
        internal DataContext context;
        internal DbSet<T> dbSet;
        internal DbSet<CommonLookup> DbSet;
        public SQLRepository(DataContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
            this.DbSet = context.Set<CommonLookup>();
        }
        public IQueryable<T> Collection()
        {
            return dbSet;
        }
        public void Commit()
        {
            context.SaveChanges();
        }
        public void Delete(Guid Id)
        {
            var t = Find(Id);
            if (context.Entry(t).State == EntityState.Detached)
            {
                dbSet.Attach(t);
            }
            dbSet.Remove(t);
        }
        public T Find(Guid Id)
        {
            return dbSet.Find(Id);
        }
        public void Insert(T t)
        {
            dbSet.Add(t);
        }
        public void Update(T t)
        {
            dbSet.Attach(t);
            context.Entry(t).State = EntityState.Modified;
        }
    }
}
