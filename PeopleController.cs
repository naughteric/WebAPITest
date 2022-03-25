using TestProject.Models;
using TestProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace TestProject.Controllers;

[ApiController]
[Route("[controller]")]

public class PeopleController : ControllerBase
{
    public PeopleController()
    {

    }

    [HttpGet]
    public ActionResult<List<People>> GetAll() =>
        PeopleService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<People> Get(int id)
    {
        var people = PeopleService.Get(id);

        if (people == null)
            return NotFound();
        
        return people;
    }

    [HttpPost]
    public IActionResult Create(People people)
    {
        PeopleService.Add(people);
        return CreatedAtAction(nameof(Create), new { id = people.id }, people);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, People people)
    {
        if (id != people.id)
            return BadRequest();
        
        var existingPeople = PeopleService.Get(id);
        if (existingPeople is null)
            return NotFound();
        
        PeopleService.Update(people);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var people = PeopleService.Get(id);

        if (people is null)
            return NotFound();

        PeopleService.Delete(id);

        return NoContent();    
    }
}
