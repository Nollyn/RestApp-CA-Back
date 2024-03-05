using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Restaurants.Commands.Create;

public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateRestaurantCommandHandler> _logger;

    public CreateRestaurantCommandHandler(IMapper mapper, ILogger<CreateRestaurantCommandHandler> logger,
        IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurant = _mapper.Map<Restaurant>(request);
        _unitOfWork.Repository<Restaurant>().AddEntity(restaurant);
        var result = await _unitOfWork.Complete();

        if (result > 0) return restaurant.Id;
        _logger.LogError("{EntityName} was not inserted", restaurant.Name);
        throw new Exception("Record was not inserted");
    }
}