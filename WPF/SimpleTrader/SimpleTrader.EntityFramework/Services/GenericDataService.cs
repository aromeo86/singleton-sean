using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.EntityFramework.Services.Common;

namespace SimpleTrader.EntityFramework.Services
{
    public class GenericDataService<T> : IDataService<T> where T : DomainObject
    {
        private readonly SimpleTraderDbContextFactory dcFactory;
        private readonly NonQueryDataService<T> nonQueryDataService;

        public GenericDataService(SimpleTraderDbContextFactory dcFactory)
        {
            this.dcFactory = dcFactory;
            nonQueryDataService = new NonQueryDataService<T>(dcFactory);
        }

        public async Task<T> Create(T entity) => await nonQueryDataService.Create(entity);

        public async Task<bool> Delete(int id)
        {
            await nonQueryDataService.Delete(id);
            return true;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using SimpleTraderDbContext dc = dcFactory.CreateDbContext();
            IEnumerable<T> entities = await dc.Set<T>().ToListAsync();
            return entities;
        }

        public async Task<T> GetById(int id)
        {
            using SimpleTraderDbContext dc = dcFactory.CreateDbContext();
            T entity = await dc.Set<T>().FirstOrDefaultAsync(e => e.ID == id);
            return entity;
        }

        public async Task<T> Update(int id, T entity) => await nonQueryDataService.Update(id, entity);
    }
}
