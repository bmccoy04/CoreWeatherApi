using CoreWeatherApi.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CoreWeatherApi.Core.Interfaces
{
    public interface IRepository
    {
        T GetById<T>(int id) where T : BaseEntity;

        IEnumerable<T> List<T>() where T : BaseEntity;

        IEnumerable<T> List<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity ;
        
        IEnumerable<TOut> List<TIn, TOut>(Expression<Func<TIn, bool>> predicate) where TIn : BaseEntity;
        
        T Add<T>(T entity) where T : BaseEntity;

        void Update<T>(T entity) where T : BaseEntity;

        void Delete<T>(T entity) where T : BaseEntity;
    }
}