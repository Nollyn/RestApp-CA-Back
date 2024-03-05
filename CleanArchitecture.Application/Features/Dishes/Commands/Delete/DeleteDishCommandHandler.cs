using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Dishes.Commands.Delete;

public class DeleteDishCommandHandler : IRequestHandler<DeleteDishCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<DeleteDishCommandHandler> _logger;

    public DeleteDishCommandHandler(IUnitOfWork unitOfWork, ILogger<DeleteDishCommandHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteDishCommand request, CancellationToken cancellationToken)
    {
        var entityToDelete = await _unitOfWork.DishRepository.GetByIdAsync(request.Id);
        if (entityToDelete == null)
        {
            _logger.LogError("Id: {Id} does not exist", request.Id);
            throw new NotFoundException(nameof(Dish), request.Id);
        }
        
        _unitOfWork.DishRepository.DeleteEntity(entityToDelete);

        await _unitOfWork.Complete();
        
        _logger.LogInformation("The registry {Id} was successfully deleted", request.Id);

        return Unit.Value;
    }
}