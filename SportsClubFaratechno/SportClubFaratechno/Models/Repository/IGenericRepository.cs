using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SportClubFaratechno.Models.Repository
{
    public interface IGenericRepository<T> where T : class
    {
         LogChanges<T> LogChanges { get; set; }

        T GetById(object id);
        IQueryable<T> GetAll();
        IQueryable<T> Find(Expression<Func<T, bool>> expression);
        bool Exists(Expression<Func<T, bool>> expression);
        T Add(T entity);
        List<T> AddRange(IEnumerable<T> entities);
        public void Update(T entity);
        void Remove(T entity);
        public void RemoveById(object id);

        void RemoveRange(IEnumerable<T> entities);
        void SaveChanges();
    }
}
