using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Drinks.Commands.Update;

public class UpdateDrinkCommandHandler : IRequestHandler<UpdateDrinkCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateDrinkCommandHandler> _logger;

    public UpdateDrinkCommandHandler(IMapper mapper, ILogger<UpdateDrinkCommandHandler> logger, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateDrinkCommand request, CancellationToken cancellationToken)
    {
        var entityToUpdate = await _unitOfWork.DrinkRepository.GetByIdAsync(request.Id);
        if (entityToUpdate == null)
        {
            _logger.LogError("Id {Id} not found", request.Id);
            throw new NotFoundException(nameof(Drink), request.Id);
        }

        _mapper.Map(request, entityToUpdate, typeof(UpdateDrinkCommand), typeof(Drink));

        _unitOfWork.DrinkRepository.UpdateEntity(entityToUpdate);

        await _unitOfWork.Complete();
        
        _logger.LogInformation("Update successfull for {Id}", request.Id);
        
        return Unit.Value;
    }
}