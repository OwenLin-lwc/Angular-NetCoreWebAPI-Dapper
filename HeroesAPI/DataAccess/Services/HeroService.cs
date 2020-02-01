using DataAccess.Entities;
using DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class HeroService : IHeroService
    {
        IUnitOfWork _unitOfWork;
        public HeroService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Hero>> GetAllHeroesByPageIndex(int pageIndex, int pageSize)
        {
            return await _unitOfWork.HeroRepository.GetAllHeroesByPageIndex(pageIndex, pageSize);
        }
        public async Task<IEnumerable<Hero>> GetAllAsync()
        {
            return await _unitOfWork.HeroRepository.GetAllAsync();
        }

        public async Task<Hero> AddAsync(Hero hero)
        {
            return await _unitOfWork.HeroRepository.AddAsync(hero);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.HeroRepository.DeleteAsync(id);
        }

        public async Task UpdateAsync(Hero hero)
        {
            await _unitOfWork.HeroRepository.UpdateAsync(hero);
        }

        public async Task<Hero> GetAsync(int id)
        {
            return await _unitOfWork.HeroRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Hero>> SearchHeroAsync(string name)
        {
            return await _unitOfWork.HeroRepository.SearchHeroAsync(name);
        }
    }
}
