using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConcreteNounsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConcreteNounsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArraySortController : ControllerBase
    {
        private readonly ConcreteNounsDbContext _context;

        public ArraySortController(ConcreteNounsDbContext context)
        {
            _context = context;
        }

        // GET: api/ArraySorts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetArray([FromQuery(Name = "words")]string words, [FromQuery] string noun)
        {
            //string[,] arr = { { "AB", "3" }, { "aalto", "8.9" }, { "abm", "2.7" } };
            //string[] topArr = new string[100];
            //float[,] numArr = new float[arr.GetLength(0), 2];
            //int[,] c = { { 1 }, { 2 } };
            //string x = arr[0, 1];
            string result = string.Empty;

            string f = words.Replace("[", "");
            string y = f.Replace("]", "");
            string z = y.Replace("'", "");
            string e = z.Replace(",", "");
            string[] topArr = e.Split(' ');

            //Semantic categories nouns contained count
            int animalCount = 0;
            int artifactCount = 0;
            int bodyCount = 0;
            int foodCount = 0;
            int groupCount = 0;
            int locationCount = 0;
            int objectCount = 0;
            int personCount = 0;
            int plantCount = 0;
            int shapeCount = 0;
            int stateCount = 0;
            int substanceCount = 0;
            int timeCount = 0;

            //Animal
            for (int i = 0; i < topArr.GetLength(0); i++)
            {
                if (topArr[i] != null)
                {
                    int dbCount = _context.Animal.Where(x => x.Animal1.Equals(topArr[i].ToUpper())).Count();
                    if (dbCount > 0)
                    {
                        animalCount += 1;
                    }
                }
            }

            //Artifact
            for (int i = 0; i < topArr.GetLength(0); i++)
            {
                if (topArr[i] != null)
                {
                    int dbCount = _context.Artifact.Where(x => x.Artifact1.Equals(topArr[i].ToUpper())).Count();
                    if (dbCount > 0)
                    {
                        artifactCount += 1;
                    }
                    //List<Artifact> query = await _context.Artifact.
                    //Where(a => a.Artifact1 == topArr[i].ToUpper()).ToListAsync();
                    //if (query.Count > 0)
                    //{
                    //    artifactCount += 1;
                    //}
                }
            }

            //Body
            for (int i = 0; i < topArr.GetLength(0); i++)
            {
                if (topArr[i] != null)
                {
                    int dbCount = _context.Body.Where(x => x.Body1.Equals(topArr[i].ToUpper())).Count();
                    if (dbCount > 0)
                    {
                        bodyCount += 1;
                    }
                }
            }

            //Food
            for (int i = 0; i < topArr.GetLength(0); i++)
            {
                if (topArr[i] != null)
                {
                    int dbCount = _context.Food.Where(x => x.Food1.Equals(topArr[i].ToUpper())).Count();
                    if (dbCount > 0)
                    {
                        foodCount += 1;
                    }
                }
            }

            //Group
            for (int i = 0; i < topArr.GetLength(0); i++)
            {
                if (topArr[i] != null)
                {
                    int dbCount = _context.Group.Where(x => x.Group1.Equals(topArr[i].ToUpper())).Count();
                    if (dbCount > 0)
                    {
                        groupCount += 1;
                    }
                    //List<Group> query = await _context.Group.
                    //Where(a => a.Group1 == topArr[i].ToUpper()).ToListAsync();
                    //if (query.Count > 0)
                    //{
                    //    groupCount[0] += 1;
                    //}
                }
            }

            //Location
            for (int i = 0; i < topArr.GetLength(0); i++)
            {
                if (topArr[i] != null)
                {
                    int dbCount = _context.LocationN.Where(x => x.Location.Equals(topArr[i].ToUpper())).Count();
                    if (dbCount > 0)
                    {
                        locationCount += 1;
                    }
                    //List<LocationN> query = await _context.LocationN.
                    //Where(a => a.Location == topArr[i].ToUpper()).ToListAsync();
                    //if (query.Count > 0)
                    //{
                    //    locationCount[0] += 1;
                    //}
                }
            }

            //Object
            for (int i = 0; i < topArr.GetLength(0); i++)
            {
                if (topArr[i] != null)
                {
                    int dbCount = _context.Object.Where(x => x.Object1.Equals(topArr[i].ToUpper())).Count();
                    if (dbCount > 0)
                    {
                        objectCount += 1;
                    }
                }
            }

            //Person
            for (int i = 0; i < topArr.GetLength(0); i++)
            {
                if (topArr[i] != null)
                {
                    int dbCount = _context.Person.Where(x => x.Person1.Equals(topArr[i].ToUpper())).Count();
                    if (dbCount > 0)
                    {
                        personCount += 1;
                    }
                    //List<Person> query = await _context.Person.
                    //Where(a => a.Person1 == topArr[i].ToUpper()).ToListAsync();
                    //if (query.Count > 0)
                    //{
                    //    personCount[0] += 1;
                    //}
                }
            }

            //Plant
            for (int i = 0; i < topArr.GetLength(0); i++)
            {
                if (topArr[i] != null)
                {
                    int dbCount = _context.Plant.Where(x => x.Plant1.Equals(topArr[i].ToUpper())).Count();
                    if (dbCount > 0)
                    {
                        plantCount += 1;
                    }
                }
            }

            //Shape
            for (int i = 0; i < topArr.GetLength(0); i++)
            {
                if (topArr[i] != null)
                {
                    int dbCount = _context.Shape.Where(x => x.Shape1.Equals(topArr[i].ToUpper())).Count();
                    if (dbCount > 0)
                    {
                        shapeCount += 1;
                    }
                }
            }

            //State
            for (int i = 0; i < topArr.GetLength(0); i++)
            {
                if (topArr[i] != null)
                {
                    int dbCount = _context.State.Where(x => x.State1.Equals(topArr[i].ToUpper())).Count();
                    if (dbCount > 0)
                    {
                        stateCount += 1;
                    }
                    //List<State> query = await _context.State.
                    //Where(a => a.State1 == topArr[i].ToUpper()).ToListAsync();
                    //if (query.Count > 0)
                    //{
                    //    stateCount[0] += 1;
                    //}
                }
            }

            //Substance
            for (int i = 0; i < topArr.GetLength(0); i++)
            {
                if (topArr[i] != null)
                {
                    int dbCount = _context.Substance.Where(x => x.Substance1.Equals(topArr[i].ToUpper())).Count();
                    if (dbCount > 0)
                    {
                        substanceCount += 1;
                    }
                }
            }

            //Time
            for (int i = 0; i < topArr.GetLength(0); i++)
            {
                if (topArr[i] != null)
                {
                    int dbCount = _context.Time.Where(x => x.Time1.Equals(topArr[i].ToUpper())).Count();
                    if (dbCount > 0)
                    {
                        timeCount += 1;
                    }
                }
            }

            //Result
            if (animalCount > 15)
            {
                if (result == string.Empty)
                {
                    string l = noun;
                    int Count = _context.Animal.Where(x => x.Animal1 == noun.ToUpper()).Count();
                    if (Count > 0)
                    {
                        result = "LITERAL";
                    }
                }
            }
            if (artifactCount > 15)
            {
                if (result == string.Empty)
                {
                    int dbCount = _context.Artifact.Where(x => x.Artifact1 == noun.ToUpper()).Count();
                    if (dbCount > 0)
                    {
                        result = "LITERAL";
                    }
                }
            }
            if (bodyCount > 15)
            {
                if (result == string.Empty)
                {
                    int dbCount = _context.Body.Where(x => x.Body1.Equals(noun.ToUpper())).Count();
                    if (dbCount > 0)
                    {
                        result = "LITERAL";
                    }
                }
            }
            if (foodCount > 15)
            {
                if (result == string.Empty)
                {
                    int dbCount = _context.Food.Where(x => x.Food1.Equals(noun.ToUpper())).Count();
                    if (dbCount > 0)
                    {
                        result = "LITERAL";
                    }
                }
            }
            if (groupCount > 15)
            {
                if (result == string.Empty)
                {
                    int dbCount = _context.Group.Where(x => x.Group1.Equals(noun.ToUpper())).Count();
                    if (dbCount > 0)
                    {
                        result = "LITERAL";
                    }
                }
            }
            if (locationCount > 15)
            {
                if (result == string.Empty)
                {
                    int dbCount = _context.LocationN.Where(x => x.Location.Equals(noun.ToUpper())).Count();
                    if (dbCount > 0)
                    {
                        result = "LITERAL";
                    }
                }
            }
            if (objectCount > 15)
            {
                if (result == string.Empty)
                {
                    int dbCount = _context.Object.Where(x => x.Object1.Equals(noun.ToUpper())).Count();
                    if (dbCount > 0)
                    {
                        result = "LITERAL";
                    }
                }
            }
            if (personCount > 15)
            {
                if (result == string.Empty)
                {
                    int dbCount = _context.Person.Where(x => x.Person1.Equals(noun.ToUpper())).Count();
                    int l = dbCount;
                    if (dbCount > 0)
                    {
                        result = "LITERAL";
                    }
                }
            }
            if (plantCount > 15)
            {
                if (result == string.Empty)
                {
                    int dbCount = _context.Plant.Where(x => x.Plant1.Equals(noun.ToUpper())).Count();
                    if (dbCount > 0)
                    {
                        result = "LITERAL";
                    }
                }
            }
            if (shapeCount > 15)
            {
                if (result == string.Empty)
                {
                    int dbCount = _context.Shape.Where(x => x.Shape1.Equals(noun.ToUpper())).Count();
                    if (dbCount > 0)
                    {
                        result = "LITERAL";
                    }
                }
            }
            if (stateCount > 15)
            {
                if (result == string.Empty)
                {
                    int dbCount = _context.State.Where(x => x.State1.Equals(noun.ToUpper())).Count();
                    if (dbCount > 0)
                    {
                        result = "LITERAL";
                    }
                }
            }
            if (substanceCount > 15)
            {
                if (result == string.Empty)
                {
                    int dbCount = _context.Substance.Where(x => x.Substance1.Equals(noun.ToUpper())).Count();
                    if (dbCount > 0)
                    {
                        result = "LITERAL";
                    }
                }
            }
            if (timeCount > 15)
            {
                if (result == string.Empty)
                {
                    int dbCount = _context.Time.Where(x => x.Time1.Equals(noun.ToUpper())).Count();
                    if (dbCount > 0)
                    {
                        result = "LITERAL";
                    }
                }
            }
            if(result == string.Empty)
            {
                result = "METAPHORICAL";
            }

            await Task.Delay(0);
            return Ok(new { result });
        }
    }
}