using AutoFixture;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.UnitTests.Mocks;

public static class MockRestaurantRepository
{
    public static void AddDataRestaurantRepository(AppDbContext appDbContextFake)
    {
        var fixture = new Fixture();
        fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        var restaurants = fixture.CreateMany<Restaurant>().ToList();

        restaurants.Add(fixture.Build<Restaurant>()
            .With(r => r.Id, 9001)
            .Create());

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: $"AppDbContext-{Guid.NewGuid()}")
            .Options;

        appDbContextFake.Restaurants!.AddRange(restaurants);
        appDbContextFake.SaveChanges();
    }
}