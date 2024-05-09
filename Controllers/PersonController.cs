using AspCore_Api_2.Models;
using Microsoft.AspNetCore.Mvc;
using AspCore_Api_2.Services;

namespace AspCore_Api_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PeopleController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public IActionResult GetPerson(string name = null, string gender = null, string birthPlace = null)
        {
            var people = _personService.FilterPerson(name, gender, birthPlace);
            return Ok(people);
        }

        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            var newPerson = _personService.AddPerson(person);
            return CreatedAtAction(nameof(GetPerson), new { id = newPerson.Id }, newPerson);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePerson(Guid id, Person person)
        {
            var updatedPerson = _personService.UpdatePerson(id, person);
            if (updatedPerson == null)
                return NotFound();

            return Ok(updatedPerson);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(Guid id)
        {
            var result = _personService.DeletePerson(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
