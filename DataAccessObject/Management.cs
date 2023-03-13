using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Management<T> where T:class
    {
        CarRentalSystemDBContext _dBContext = new CarRentalSystemDBContext();

        public List<T> GetAll()
        {
            return _dBContext.Set<T>().ToList();
        }

        public T GetBy(Expression<Func<T, bool>> predicate)
        {
            return _dBContext.Set<T>().SingleOrDefault(predicate);
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> predicate)
        {
            return _dBContext.Set<T>().Where(predicate);
        }

        public T Insert(T entity)
        {
            _dBContext.Set<T>().Add(entity);
            _dBContext.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            if(entity != null)
            {
                _dBContext.Set<T>().Update(entity);
                _dBContext.SaveChanges();
                return entity;
            }
            return null;
        }

        public void Remove(T entity)
        {
            if (entity != null)
            {
                _dBContext.Set<T>().Remove(entity);
                _dBContext.SaveChanges();
            }
        }
    }
}
