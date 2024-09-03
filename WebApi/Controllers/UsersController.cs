using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Commands;
using WebApi.Queries;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserCommand command)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var userId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = userId }, null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateUserCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest("User ID mismatch");
        }

        var result = await _mediator.Send(command);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteUserCommand { Id = id });
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _mediator.Send(new GetUserByIdQuery { Id = id });
        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _mediator.Send(new GetAllUsersQuery());
        return Ok(users);
    }
}
