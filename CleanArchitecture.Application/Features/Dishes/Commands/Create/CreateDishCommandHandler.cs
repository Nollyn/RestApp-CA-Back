using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Dishes.Commands.Create;

public class CreateDishCommandHandler : IRequestHandler<CreateDishCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateDishCommandHandler> _logger;

    public CreateDishCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateDishCommandHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<int> Handle(CreateDishCommand request, CancellationToken cancellationToken)
    {
        var dish = _mapper.Map<Dish>(request);
        _unitOfWork.DishRepository.AddEntity(dish);
        var result = await _unitOfWork.Complete();

        if (result <= 0)
        {
            throw new Exception($"Record was not inserted");
        }
        
        _logger.LogInformation("Registry {EntityName} successfully created", dish.Name);

        return dish.Id;
    }
}