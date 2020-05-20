using System.Collections.Generic;
using System.Threading.Tasks;
using HoroscopeBot.Core.Models;

namespace HoroscopeBot.Core.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task Add(T item);

        Task Remove(int id);

        Task<T> FindById(int id);

        Task<IEnumerable<T>> GetAll();

        Task Update(T item);
    }
}