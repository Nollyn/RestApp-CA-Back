using MediatR;

namespace CleanArchitecture.Application.Features.Drinks.Commands.Delete;

public class DeleteDrinkCommand : IRequest
{
    public int Id { get; set; }
}