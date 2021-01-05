using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using IoT.Api.System.Contexts;
using MongoDB.Driver;

namespace IoT.Api.System.Repositories
{
    public interface IDataRepository<T>
    {
        public DbContext Context { get; }
        public Task CreateDocument(T item);
        public Task<List<T>> GetMany(FilterDefinition<T> filter);
        public Task<T> GetOne(FilterDefinition<T> filter);
        //public Task Update();
        public Task Delete(T item);
    }
}