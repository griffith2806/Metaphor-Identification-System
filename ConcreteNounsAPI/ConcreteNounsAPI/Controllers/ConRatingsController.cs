using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConcreteNounsAPI.Models;
using Newtonsoft.Json;

namespace ConcreteNounsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConRatingsController : ControllerBase
    {
        private readonly ConcreteNounsDbContext _context;

        public ConRatingsController(ConcreteNounsDbContext context)
        {
            _context = context;
        }

        // GET: api/ConRatings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConRating>>> GetConRating()
        {
            string[] testNames = { "woman", "man", "bus" };
            Console.WriteLine(testNames);
            List<ConRating> conRatings = await _context.ConRating.
            Where(a => testNames.Contains(a.Word)).OrderByDescending(a => a.ConcM).Take(100).ToListAsync();
            return conRatings;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<ConRating>>> PostConRating(ConRating conRating)
        {
            //string[] testNames = { "woman", "man", "bus" };
            List<ConRating> conRatings = await _context.ConRating.
                Where(a => conRating.Word.Equals(a.Word)).ToListAsync();
            return conRatings; 
        }

        private bool ConRatingExists(string id)
        {
            return _context.ConRating.Any(e => e.Id == id);
        }
    }
}
