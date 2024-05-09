using AspCore_Api_2.Models;
using Microsoft.AspNetCore.Mvc;
using AspCore_Api_2.Services;

namespace AspCore_Api_2.Controllers
{
    [Route("NashTech/Rookies")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public IActionResult GetPerson(string name = null, string gender = null, string birthPlace = null)
        {
            try
            {
                var people = _personService.FilterPerson(name, gender, birthPlace);
                return Ok(people);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            try
            {
                var newPerson = _personService.AddPerson(person);
                return CreatedAtAction(nameof(GetPerson), new { id = newPerson.Id }, newPerson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePerson(Guid id, Person person)
        {
            try
            {
                var updatedPerson = _personService.UpdatePerson(id, person);
                if (updatedPerson == null)
                    return NotFound();

                return Ok(updatedPerson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(Guid id)
        {
            try
            {
                var result = _personService.DeletePerson(id);
                if (!result)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}
