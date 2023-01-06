using Microsoft.AspNetCore.Mvc;
namespace App.Controllers;

using App.Application.Commands;
using App.Application.Queries;
using MediatR;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;
    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(Name = "CreateCategoryAsync")]
    public async Task<IActionResult> CreateAsync(CreateCategoryCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpGet(Name = "GetAllCategoriesAsync")]
    public async Task<IActionResult> GetAllAsync()
    {
        var queryResponse = await _mediator.Send(new GetAllCategoriesQuery());
        return Ok(queryResponse.Data);
    }
}