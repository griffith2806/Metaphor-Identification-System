using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConcreteNounsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConcreteNounsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly ConcreteNounsDbContext _context;

        public AnimalsController(ConcreteNounsDbContext context)
        {
            _context = context;
        }

        // GET: api/ConRatings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<int>>> GetConRating([FromQuery(Name = "words")]string words)
        {
            int count = 0;

            string x = words.Replace("[", "");
            string y = x.Replace("]", "");
            string z = y.Replace("'", "");
            string e = z.Replace(",", "");
            string[] test = e.Split(' ');
            string dfd = test[0];

            for (int i = 0; i < test.Length; i++)
            {
                //words[i].ToUpper();
                int dbCount = _context.Food.Where(x => x.Food1.Equals(test[i].ToUpper())).Count();
                if (dbCount > 0)
                {
                    count += 1;
                }
            }
            await Task.Delay(0);
            //List<int> total = count;
            return Ok(new { count });
        }
    }
}