using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

       public static List<Customer> values = new List<Customer>();

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {

            return Ok(values);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Customer cust;
            try
            {
                cust = values.FirstOrDefault(c => c.id == id);
            }
            catch (Exception e)
            {
                return NotFound("not found");
            }
            return Ok(cust);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            Customer custo = new Customer();
            custo.id = values.Count() + 1;
            custo.firstName = customer.firstName;
            custo.lastName = customer.lastName;
            custo.mainCategory = customer.mainCategory;

            values.Add(custo);
            return Ok(custo);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
