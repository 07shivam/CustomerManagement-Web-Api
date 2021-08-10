using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        //this list will store the data of customber
       public static List<Customer> customerData = new List<Customer>();

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(customerData);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Customer c1;
            try
            {
                c1 = customerData.FirstOrDefault(x => x.id == id);
            }
            catch (Exception e)
            {
                return NotFound("Required Customer Is Not Found");
            }
            return Ok(c1);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            Customer c1 = new Customer();
            c1.id = customerData.Count() + 1;
            c1.firstName = customer.firstName;
            c1.lastName = customer.lastName;
            c1.dateOfBirth = customer.dateOfBirth;
            c1.customerType = customer.customerType;
            c1.emailAddress = c1.emailAddress;


            customerData.Add(c1);
            return Ok(c1);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customer customer)
        {   
            if(customer.id.Equals(id))
            {
                Customer c1 = new Customer();
                c1.id = customer.id;
                c1.firstName = customer.firstName;
                c1.lastName = customer.lastName;
                c1.dateOfBirth = customer.dateOfBirth;
                c1.customerType = customer.customerType;
                c1.emailAddress = c1.emailAddress;


                customerData[id-1] = c1;
                return Ok("Required Customer has been updated");
            }
            return NotFound("Required Customer Is Not Found");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // values.RemoveAt(id);
                /*var itemToRemove = values.Single(r => r.id == id);
                values.Remove(itemToRemove);*/

                var item = customerData.SingleOrDefault(x => x.id == id);
                if (item != null)
                    customerData.Remove(item);
            }
            catch (Exception e)
            {
                return NotFound("Required Customer Is Not Found");
            }
            return Ok("Required Customer has been deleted");
        }
    }
}
