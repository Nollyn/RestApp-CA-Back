using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Drinks.Commands.Delete;

public class DeleteDrinkCommandHandler : IRequestHandler<DeleteDrinkCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<DeleteDrinkCommandHandler> _logger;

    public DeleteDrinkCommandHandler(ILogger<DeleteDrinkCommandHandler> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteDrinkCommand request, CancellationToken cancellationToken)
    {
        var entityToDelete = await _unitOfWork.DrinkRepository.GetByIdAsync(request.Id);
        if (entityToDelete == null)
        {
            _logger.LogError("Id: {Id} does not exist", request.Id);
            throw new NotFoundException(nameof(Drink), request.Id);
        }

        _unitOfWork.DrinkRepository.DeleteEntity(entityToDelete);

        await _unitOfWork.Complete();
        
        _logger.LogInformation("The registry {Id} was successfully deleted", request.Id);

        return Unit.Value;
    }
}