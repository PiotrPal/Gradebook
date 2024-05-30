using Gradebook.App.Commands.Students.AddStudent;
using Gradebook.App.Commands.Students.RemoveStudent;
using Gradebook.App.Commands.Students.UpdateStudent;
using Gradebook.App.Dtos;
using Gradebook.App.Queries.Students.GetStudentByEmail;
using Gradebook.App.Queries.Students.GetStudentByID;
using Gradebook.App.Queries.Students.GetStudents;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Gradebook.Presenntation.Controllers;
[Route("api/students")]
[ApiController]
public class StudentsController : Controller {
    private readonly IMediator _mediator;

    public StudentsController(IMediator mediator) {
        _mediator = mediator;
    }

    [HttpGet]
    [SwaggerOperation("Get students")]
    [ProducesResponseType(typeof(IEnumerable<StudentDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Get() {
        var result = await _mediator.Send(new GetStudentsQuery());
        return Ok(result);
    }

    [HttpGet("{ID}")]
    [SwaggerOperation("Get students by ID")]
    [ProducesResponseType(typeof(StudentDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetByID([FromRoute] int ID) {
        var result = await _mediator.Send(new GetStudentByIDQuery(ID));
        return result != null ? Ok(result) : NotFound();
    }

    [HttpGet("[action]/{Email}")]
    [SwaggerOperation("Get students by Eamil")]
    [ProducesResponseType(typeof(StudentDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetByEmail([FromRoute] string Email) {
        var result = await _mediator.Send(new GetStudentByEmailQuery(Email));
        return result != null ? Ok(result) : NotFound();
    }

    [HttpPost]
    [SwaggerOperation("Add student")]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<ActionResult> Post([FromBody] AddStudentCommand command) {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetByID), new { ID = result.ID }, result);
    }

    [HttpPut]
    [SwaggerOperation("Update student")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<ActionResult> Put([FromBody] UpdateStudentCommand command) {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{ID}")]
    [SwaggerOperation("Remove student")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<ActionResult> Delete([FromRoute] int ID) {
        await _mediator.Send(new RemoveStudentCommand(ID));
        return NoContent();
    }
}

