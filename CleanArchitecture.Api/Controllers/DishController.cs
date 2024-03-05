using System.Net;
using CleanArchitecture.Application.Features.Dishes.Commands.Create;
using CleanArchitecture.Application.Features.Dishes.Commands.Delete;
using CleanArchitecture.Application.Features.Dishes.Commands.Update;
using CleanArchitecture.Application.Features.Dishes.Queries.GetDishesList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers;

/// <summary>
/// Controller for Dish CRUD and behaviour
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
public class DishController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mediator"></param>
    public DishController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Returns a Restaurant Dishes list
    /// </summary>
    /// <param name="restaurantId"></param>
    /// <returns></returns>
    [HttpGet("{restaurantId:int}", Name = "GetDishes")]
    [ProducesResponseType(typeof(IEnumerable<DishesVm>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ObjectResult))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<DishesVm>>> GetDishesByRestaurant(int restaurantId)
    {
        return Ok(await _mediator.Send(new GetDishesListQuery(restaurantId)));
    }
    
    /// <summary>
    /// Creates a Dish (data)
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost(Name = "CreateDish")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ObjectResult))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<int>> Create([FromBody] CreateDishCommand command)
    {
        return await _mediator.Send(command);
    }
    
    /// <summary>
    /// Updates a Dish (Data)
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut(Name = "UpdateDish")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ObjectResult))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Update([FromBody] UpdateDishCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }
    
    /// <summary>
    /// Deletes a Dish (Data from database)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id:int}", Name = "DeleteDsih")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ObjectResult))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteDishCommand { Id = id });

        return NoContent();
    }
}