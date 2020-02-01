using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeroesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class HeroesController : ControllerBase
    {
        IHeroService _heroService;

        public HeroesController(IHeroService heroService)
        {
            _heroService = heroService;
        }

        // GET: api/Heroes
        [HttpGet]
        public async Task<IEnumerable<Hero>> GetAllAsync(string name = "")
        {
            if (Request.QueryString.HasValue)
            {
                return await _heroService.SearchHeroAsync(name);
            }

            return await _heroService.GetAllAsync();
        }

        // GET: api/Heroes/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<Hero> Get(int id)
        {
            return await _heroService.GetAsync(id);
        }

        // POST: api/Heroes
        [HttpPost]
        public async Task<Hero> Post(Hero hero)
        {
            return await _heroService.AddAsync(hero);
        }

        // PUT: api/Heroes
        [HttpPut]
        public async Task Put(Hero hero)
        {
            await _heroService.UpdateAsync(hero);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _heroService.DeleteAsync(id);
        }
    }
}
