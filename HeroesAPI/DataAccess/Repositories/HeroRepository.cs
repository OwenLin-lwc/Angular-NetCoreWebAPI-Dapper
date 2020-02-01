using Dapper;
using Dapper.Contrib.Extensions;
using DataAccess.Entities;
using DataAccess.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class HeroRepository : GenericRepository<Hero>, IHeroRepository
    {
        IConnectionFactory _connectionFactory;

        public HeroRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<IEnumerable<Hero>> GetAllHeroesByPageIndex(int pageIndex, int pageSize)
        {
            // TODO: The stored procedure hasn't implement.
            var query = "usp_GetAllHeroesByPageIndex";
            var param = new DynamicParameters();
            param.Add("@PageIndex", pageIndex);
            param.Add("@PageSize", pageSize);
            var list = await SqlMapper.QueryAsync<Hero>(_connectionFactory.GetConnection, query, param, commandType: CommandType.StoredProcedure);
            return list;
        }
        public async Task<IEnumerable<Hero>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                return await connection.GetAllAsync<Hero>();
            }
        }

        public async Task<Hero> AddAsync(Hero hero)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var id = await connection.InsertAsync(hero);
                hero.Id = id;
            }

            return hero;
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var hero = connection.Get<Hero>(id);
                if (hero != null)
                {
                    await connection.DeleteAsync(hero);
                }
            }
        }

        public async Task UpdateAsync(Hero hero)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                await connection.UpdateAsync(hero);
            }
        }

        public async Task<Hero> GetAsync(int id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                return await connection.GetAsync<Hero>(id);
            }
        }

        public async Task<IEnumerable<Hero>> SearchHeroAsync(string name)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                // TODO: Prevent SQL Injection
                return await connection.QueryAsync<Hero>("select * from Hero where name like '%" + name + "%'");
            }
        }
    }
}
