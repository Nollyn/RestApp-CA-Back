using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.Restaurants.Queries.GetRestaurantsList;

public class GetRestaurantsListQueryHandler : IRequestHandler<GetRestaurantListQuery, List<RestaurantsVm>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetRestaurantsListQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<RestaurantsVm>> Handle(GetRestaurantListQuery request, CancellationToken cancellationToken)
    {
        var restaurantList = await _unitOfWork.DrinkRepository.GetAllAsync();

        return _mapper.Map<List<RestaurantsVm>>(restaurantList);
    }
}
