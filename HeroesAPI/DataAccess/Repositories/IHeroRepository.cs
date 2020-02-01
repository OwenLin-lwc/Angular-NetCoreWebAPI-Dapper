using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IHeroRepository : IGenericRepository<Hero>
    {
        Task<IEnumerable<Hero>> GetAllHeroesByPageIndex(int pageIndex, int pageSize);

        Task<IEnumerable<Hero>> GetAllAsync();

        Task<Hero> GetAsync(int id);

        Task<Hero> AddAsync(Hero hero);

        Task DeleteAsync(int id);

        Task UpdateAsync(Hero hero);

        Task<IEnumerable<Hero>> SearchHeroAsync(string name);
    }
}
