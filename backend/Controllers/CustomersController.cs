using System.Collections.Generic;
using System.Linq;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersControllers : ControllerBase
    {
        [HttpGet]
        public IActionResult GetById(int id)
        {
            return Ok("Alive");
        }

        [HttpGet]
        public ActionResult<PaginatedResponse<Customer>> GetList(int pageLength = 10, int pageIndex = 0, string searchText = "", string orderBy = "")
        {
            var contactList = new List<Customer>{
                new Customer {Name = "Alice Moreira", Phone = "3199832322"},
                new Customer {Name = "Alice Jesus", Phone = "3199832323"},
                new Customer {Name = "Alice Pereira", Phone = "3199832324"},
                new Customer {Name = "Alice Souza", Phone = "3199832325"},
                new Customer {Name = "Alice Fernada", Phone = "3199832326"},
                // new Customer { FirstName = "Alice", LastName = "Johnson", Age = 9, Gender = "F", Grade = 4},
                // new Customer { FirstName = "Mike", LastName = "Ford", Age = 5, Gender = "M", Grade = 1},
                // new Customer { FirstName = "John", LastName = "Smith", Age = 8, Gender = "M", Grade = 4},
                // new Customer { FirstName = "Joe", LastName = "Johnson", Age = 11, Gender = "M", Grade = 6},
                // new Customer { FirstName = "Linda", LastName = "Ford", Age = 8, Gender = "F", Grade = 5},
                // new Customer { FirstName = "Noah", LastName = "Wilson", Age = 9, Gender = "M", Grade = 3},
                // new Customer { FirstName = "Emma", LastName = "Lee", Age = 7, Gender = "F", Grade = 3},
                // new Customer { FirstName = "James", LastName = "Jones", Age = 9, Gender = "F", Grade = 4},
                // new Customer { FirstName = "Mia", LastName = "Brown", Age = 9, Gender = "F", Grade = 4},
                // new Customer { FirstName = "William", LastName = "Davis", Age = 9, Gender = "F", Grade = 4},
                // new Customer { FirstName = "Lucas", LastName = "Arcanjo", Age = 9, Gender = "F", Grade = 4},
                // new Customer { FirstName = "Vanderli", LastName = "Barboza", Age = 9, Gender = "F", Grade = 4}
            };

            // TODO Check if orderby string is a valid Customer property
            var prop = typeof(Customer).GetProperty(orderBy);

            var fitleredList = contactList.Where(x => string.IsNullOrEmpty(searchText) ||
                                                      x.Name.ToLower().Contains(searchText.ToLower()))
                                           .OrderBy(x => prop.GetValue(x, null));

            var filteredCount = fitleredList.Count();

            var data = fitleredList.Skip(pageIndex)
                                   .Take(pageLength);

            return new PaginatedResponse<Customer> 
            {
                TotalCount = contactList.Count,
                FilteredCount = fitleredList.Count(),
                Data = data
            };
        }
    }
}