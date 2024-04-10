namespace Backend.Interview.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PeopleController : Controller
{
    private readonly IPersonService _personService;
    private readonly IMakeShiftLogger _logger;

    public PeopleController(IPersonService personService, IMakeShiftLogger logger)
    {
        _personService = personService;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetAllPeople()
    {
        try
        {
            var people = _personService.GetAllPeople();
            return Ok(people);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            return BadRequest(ex);
        }
    }

    [HttpPost]
    public IActionResult AddNewPerson(Person newPerson)
    {
        try
        {
            var person = _personService.AddNewPerson(newPerson);
            _logger.LogInfo("Created new person with ID " + person.Id);
            return new ObjectResult(person) { StatusCode = StatusCodes.Status201Created };

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            return BadRequest(ex);
        }
    }

    [HttpPut("{id}")]
    public IActionResult EditPerson(string id, Person editedPerson)
    {
        try
        {
            var person = _personService.EditPerson(id, editedPerson);
            _logger.LogInfo("Edited person with ID " + person.Id);
            return new ObjectResult(person) { StatusCode = StatusCodes.Status201Created };

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            return BadRequest(ex);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePerson(string id)
    {
        try
        {
            _personService.DeletePerson(id);
            _logger.LogInfo("Deleted person with ID " + id);
            return NoContent();

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            return BadRequest(ex);
        }
    }
}
