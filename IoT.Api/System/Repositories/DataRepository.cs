using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using IoT.Api.System.Contexts;
using IoT.Api.System.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace IoT.Api.System.Repositories
{
    public class DataRepository : IDataRepository<DataDocument>
    {
        public DbContext Context => new DbContext();

        public async Task CreateDocument(DataDocument item)
        {
            item.Date = DateTime.Now.Date;
            item.Hour = DateTime.Now.Hour;
            await Context.UserNotes.InsertOneAsync(item);
        }

        public async Task<List<DataDocument>> GetMany(FilterDefinition<DataDocument> filter)
        {
            return (await Context.UserNotes.FindAsync(filter)).ToList();
        }

        public async Task<DataDocument> GetOne(FilterDefinition<DataDocument> filter)
        {
            return (await Context.UserNotes.FindAsync(filter)).First();
        }

        public async Task Delete(DataDocument item)
        {
            await Context.UserNotes.DeleteOneAsync(x => x.Id == item.Id);
        }
    }
}