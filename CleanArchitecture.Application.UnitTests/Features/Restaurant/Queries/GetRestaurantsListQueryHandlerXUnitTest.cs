using AutoMapper;
using CleanArchitecture.Application.Features.Restaurants.Queries.GetRestaurantsList;
using CleanArchitecture.Application.Mappings;
using CleanArchitecture.Application.UnitTests.Mocks;
using CleanArchitecture.Infrastructure.Repositories;
using Moq;
using Shouldly;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.Features.Restaurant.Queries;

public class GetRestaurantsListQueryHandlerXUnitTest
{
    private readonly IMapper _mapper;
    private readonly Mock<UnitOfWork> _unitOfWork;

    public GetRestaurantsListQueryHandlerXUnitTest()
    {
        _unitOfWork = MockUnitOfWork.GetUnitOfWork();

        var mapperConfig = new MapperConfiguration(d =>
        {
            d.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task GetRestaurantListTest()
    {
        var handler = new GetRestaurantsListQueryHandler(_mapper, _unitOfWork.Object);
        var result = await handler.Handle(new GetRestaurantListQuery(), CancellationToken.None);

        result.ShouldBeOfType<List<RestaurantsVm>>();
    }
}