using SportClubFaratechno.Models.SportClubFaratechnoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace SportClubFaratechno.Models.Repository
{
    public class SportClubRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly SportClubFaratechnoDBContext _context;

        //public LogChanges<T> LogChanges { get; set; }
        public LogChanges<T> LogChanges { get; set; } = new LogChanges<T>();

        public SportClubRepository()
        {
         //this.LogChanges  = new LogChanges<T>();
        _context = TheServiceProvider.Instance.GetService<SportClubFaratechnoDBContext>(); 
        }
        public T Add(T entity)
        {

            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            LogChanges.ActionName = "insert";
            LogChanges.Inserted = entity;
            return entity;
        }
        public List<T> AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            _context.SaveChanges();
            LogChanges.ActionName = "insertGroup";
            LogChanges.GroupInserted =entities.ToList();
            return entities.ToList();
        }
        public IQueryable<T> Find(Expression<Func<T, bool>> filter)
        {
            DbSet<T> dbSet1 = _context.Set<T>();
            IQueryable<T> query = dbSet1;

            query = query.Where(filter);
            return query;
        }

        
        public bool Exists(Expression<Func<T, bool>> filter)
        {
            DbSet<T> dbSet1 = _context.Set<T>();
            IQueryable<T> query = dbSet1;

            bool res  = query.Any(filter);
            return res;
        }
        public IQueryable<T> GetAll()
        {
            DbSet<T> dbSet1 = _context.Set<T>();
            IQueryable<T> query = dbSet1;
            return query;
        }
        public T GetById(object id)
        {
            return _context.Set<T>().Find(id);
        }
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
            LogChanges.ActionName = "delete";
        }
        public void RemoveById(object id)
        {

            var entity = _context.Set<T>().Find(id);
            LogChanges.ActionName = "delete";
            LogChanges.Detelted = entity;
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
            
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            

            _context.Set<T>().Update(entity);
           
            _context.SaveChanges();
            LogChanges.ActionName = "update";
            LogChanges.AfterChange = entity;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

       
    }
}
