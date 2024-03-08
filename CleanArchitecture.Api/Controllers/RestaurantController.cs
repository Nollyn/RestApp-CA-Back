using CleanArchitecture.Application.Features.Restaurants.Commands.Create;
using CleanArchitecture.Application.Features.Restaurants.Queries.GetRestaurantsList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.Api.Controllers;

/// <summary>
/// Controller for Restaurant CRUD and behaviour
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
public class RestaurantController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mediator"></param>
    public RestaurantController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Returns a Restaurant list
    /// </summary>
    /// <returns></returns>
    [HttpGet(Name = "GetRestaurants")]
    [ProducesResponseType(typeof(IEnumerable<RestaurantsVm>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ObjectResult))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<RestaurantsVm>>> GetRestaurants()
    {
        return Ok(await _mediator.Send(new GetRestaurantListQuery()));
    }

    /// <summary>
    /// Creates a Restaurant (data)
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost(Name = "CreateRestaurant")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ObjectResult))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<int>> Create([FromBody] CreateRestaurantCommand command)
    {
        return await _mediator.Send(command);
    }
}