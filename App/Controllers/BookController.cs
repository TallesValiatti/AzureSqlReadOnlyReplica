using Microsoft.AspNetCore.Mvc;
using App.Application.Commands;
using MediatR;
using App.Application.Queries;

namespace App.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly IMediator _mediator;
    public BookController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(Name = "CreateBookAsync")]
    public async Task<IActionResult> CreateAsync(CreateBookCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpGet(Name = "GetAllBooksAsync")]
    public async Task<IActionResult> GetAllAsync()
    {
        var queryResponse = await _mediator.Send(new GetAllBooksQuery());
        return Ok(queryResponse.Data);
    }
}
