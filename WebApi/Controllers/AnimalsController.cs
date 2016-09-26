using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class AnimalsController : ApiController
    {
        // GET: api/Animals
        public IEnumerable<Animal> Get()
        {
            return AnimalsDB.Animals;
        }

        // GET: api/Animals/5
        [SampleExceptionFilter]
        public Animal Get(string id)
        {
            return AnimalsDB.Animals.Single(a => a.Species == id);
        }

        // POST: api/Animals
        public void Post([FromBody]Animal value)
        {
            AnimalsDB.Animals.Add(value);
        }

        // PUT: api/Animals/5
        public void Put(string id, [FromBody]Animal value)
        {
            AnimalsDB.Animals.RemoveAll(a => a.Species == id);
            AnimalsDB.Animals.Add(value);
        }

        // DELETE: api/Animals/5
        public void Delete(string id)
        {
            AnimalsDB.Animals.RemoveAll(a => a.Species == id);
        }
    }

    public class Animal
    {
        public string Species { get; set; }
        public int NumberOfLegs { get; set; }
        public string Genus { get; set; }

        public override string ToString()
        {
            return string.Format("I'm a {0} with {1} legs in the {2} family", Species, NumberOfLegs, Genus);
        }
    }

    public class AnimalsDB
    {
        public static List<Animal> Animals = new List<Animal>
        {
            new Animal { Species = "Dog", NumberOfLegs = 4, Genus = "Canine" },
            new Animal { Species = "Cat", NumberOfLegs = 4, Genus = "Feline" }
        };
    }
}
