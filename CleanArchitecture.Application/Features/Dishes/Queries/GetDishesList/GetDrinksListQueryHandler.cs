using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.Dishes.Queries.GetDishesList;

public class GetDrinksListQueryHandler : IRequestHandler<GetDishesListQuery, List<DishesVm>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetDrinksListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<DishesVm>> Handle(GetDishesListQuery request, CancellationToken cancellationToken)
    {
        var dishesList = await _unitOfWork.DishRepository.GetDishesByRestaurant(request._RestaurantId);

        return _mapper.Map<List<DishesVm>>(dishesList);
    }
}