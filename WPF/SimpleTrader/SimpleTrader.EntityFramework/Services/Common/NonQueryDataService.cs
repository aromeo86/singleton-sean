using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.EntityFramework.Services.Common
{
    public class NonQueryDataService<T> where T : DomainObject
    {
        private readonly SimpleTraderDbContextFactory dcFactory;

        public NonQueryDataService(SimpleTraderDbContextFactory dcFactory) => this.dcFactory = dcFactory;

        public async Task<T> Create(T entity)
        {
            using SimpleTraderDbContext dc = dcFactory.CreateDbContext();
            EntityEntry<T> newEntity = await dc.Set<T>().AddAsync(entity);
            await dc.SaveChangesAsync();

            return newEntity.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            using SimpleTraderDbContext dc = dcFactory.CreateDbContext();
            T entity = await dc.Set<T>().FirstOrDefaultAsync(e => e.ID == id);
            dc.Set<T>().Remove(entity);
            await dc.SaveChangesAsync();

            return true;
        }

        public async Task<T> Update(int id, T entity)
        {
            using SimpleTraderDbContext dc = dcFactory.CreateDbContext();
            entity.ID = id;
            dc.Set<T>().Update(entity);
            await dc.SaveChangesAsync();

            return entity;
        }
    }
}
