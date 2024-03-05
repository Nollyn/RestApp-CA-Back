using MediatR;

namespace CleanArchitecture.Application.Features.Dishes.Commands.Delete;

public class DeleteDishCommand : IRequest
{
    public int Id { get; set; }
}