using System.Net;
using CleanArchitecture.Application.Features.Drinks.Commands.Create;
using CleanArchitecture.Application.Features.Drinks.Commands.Delete;
using CleanArchitecture.Application.Features.Drinks.Commands.Update;
using CleanArchitecture.Application.Features.Drinks.Queries.GetDrinksList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers;

/// <summary>
/// Controller for Drink CRUD and behaviour
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
public class DrinkController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mediator"></param>
    public DrinkController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Returns a Restaurant Drink list
    /// </summary>
    /// <param name="restaurantId"></param>
    /// <returns></returns>
    [HttpGet("{restaurantId:int}", Name = "GetDrinks")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ObjectResult))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(IEnumerable<DrinksVm>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<DrinksVm>>> GetDrinksByRestaurant(int restaurantId)
    {
        return Ok(await _mediator.Send(new GetDrinksListQuery(restaurantId)));
    }

    /// <summary>
    /// Creates a Drink (data)
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost(Name = "CreateDrink")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ObjectResult))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<int>> Create([FromBody] CreateDrinkCommand command)
    {
        return await _mediator.Send(command);
    }

    /// <summary>
    /// Updates a Drink (Data)
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut(Name = "UpdateDrink")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ObjectResult))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Update([FromBody] UpdateDrinkCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }

    /// <summary>
    /// Deletes a Drink (Data from database)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id:int}", Name = "DeleteDrink")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ObjectResult))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteDrinkCommand { Id = id });

        return NoContent();
    }
}