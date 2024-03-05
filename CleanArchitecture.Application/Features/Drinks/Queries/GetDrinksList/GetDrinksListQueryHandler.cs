using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.Drinks.Queries.GetDrinksList
{
    public class GetDrinksListQueryHandler : IRequestHandler<GetDrinksListQuery, List<DrinksVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDrinksListQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<DrinksVm>> Handle(GetDrinksListQuery request, CancellationToken cancellationToken)
        {
            var drinksList = await _unitOfWork.DrinkRepository.GetDrinksByRestaurant(request._RestaurantId);

            return _mapper.Map<List<DrinksVm>>(drinksList);
        }
    }
}
