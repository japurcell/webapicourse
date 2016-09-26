using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    public class CustomersController : ApiController
    {
        readonly RepositoryMethods<Customer> _repository;

        public CustomersController(RepositoryMethods<Customer> repository)
        {
            _repository = repository;
        }

        // GET: api/Customers
        public async Task<IEnumerable<Customer>> Get()
        {
            return await _repository.All();
        }

        // GET: api/Customers/5
        public async Task<Customer> Get(int id)
        {
            return await _repository.Find(id);
        }

        // POST: api/Customers
        public async void Post([FromBody]Customer value)
        {
            await _repository.Create(value);
        }

        // PUT: api/Customers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Customers/5
        public void Delete(int id)
        {
        }
    }
}
