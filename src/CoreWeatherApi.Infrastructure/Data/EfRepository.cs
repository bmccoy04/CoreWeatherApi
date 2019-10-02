using CoreWeatherApi.Core.Interfaces;
using CoreWeatherApi.Core.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;

namespace CoreWeatherApi.Infrastructure.Data
{
    public class EfRepository : IRepository
    {
        private readonly AppDbContext _appDbContext;

        public EfRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public T GetById<T>(int id) where T : BaseEntity
        {
            return _appDbContext.Set<T>().SingleOrDefault(e => e.Id == id);
        }

        public IEnumerable<T> List<T>() where T : BaseEntity
        {
            return _appDbContext.Set<T>();
        }

        public IEnumerable<T> List<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity
        {
            return _appDbContext.Set<T>()
                                .Where(predicate);
        }

        public IEnumerable<TOut> List<TIn, TOut>(Expression<Func<TIn, bool>> predicate) where TIn : BaseEntity
        {
            return _appDbContext.Set<TIn>()
                                .Where(predicate)
                                .ProjectTo<TOut>();
        }
        public T Add<T>(T entity) where T : BaseEntity
        {
            _appDbContext.Set<T>().Add(entity);
            _appDbContext.SaveChanges();

            return entity;
        }

        public void Delete<T>(T entity) where T : BaseEntity
        {
            _appDbContext.Set<T>().Remove(entity);
            _appDbContext.SaveChanges();
        }

        public void Update<T>(T entity) where T : BaseEntity
        {
            _appDbContext.Entry(entity).State = EntityState.Modified;
            _appDbContext.SaveChanges();
        }
    }
}
