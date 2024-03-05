using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Drinks.Commands.Create;

public class CreateDrinkCommandHandler : IRequestHandler<CreateDrinkCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateDrinkCommandHandler> _logger;

    public CreateDrinkCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateDrinkCommandHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<int> Handle(CreateDrinkCommand request, CancellationToken cancellationToken)
    {
        var drink = _mapper.Map<Drink>(request);
        _unitOfWork.DrinkRepository.AddEntity(drink);
        var result = await _unitOfWork.Complete();

        if (result <= 0)
        {
            throw new Exception($"Record was not inserted");
        }

        _logger.LogInformation("Registry {EntityName} successfully created", drink.Name);

        return drink.Id;
    }
}