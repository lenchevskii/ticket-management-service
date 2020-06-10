using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketManagement.DAL.Interfaces
{
  public interface IRepository<in TKey, TEntity>
      where TEntity : class
  {
    Task<IEnumerable<TEntity>> GetAsync(TKey key);

    Task<IEnumerable<TEntity>> GetAllAsync();

    Task DeleteAsync(TKey key);

    Task CreateAsync(TEntity entity);

    Task DeleteRangeAsync(TKey[] keys);
  }
}
