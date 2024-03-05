using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Dishes.Commands.Update;

public class UpdateDishCommandHandler : IRequestHandler<UpdateDishCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateDishCommandHandler> _logger;

    public UpdateDishCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateDishCommandHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Unit> Handle(UpdateDishCommand request, CancellationToken cancellationToken)
    {
        var entityToUpdate = await _unitOfWork.DishRepository.GetByIdAsync(request.Id);
        if (entityToUpdate == null)
        {
            _logger.LogError("Id {Id} not found", request.Id);
            throw new NotFoundException(nameof(Dish), request.Id);
        }

        _mapper.Map(request, entityToUpdate, typeof(UpdateDishCommand), typeof(Dish));
        
        _unitOfWork.DishRepository.UpdateEntity(entityToUpdate);

        await _unitOfWork.Complete();
        
        _logger.LogInformation("Update successfull for {Id}", request.Id);

        return Unit.Value;
    }
}