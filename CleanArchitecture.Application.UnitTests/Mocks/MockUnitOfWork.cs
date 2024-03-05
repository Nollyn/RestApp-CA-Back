using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CleanArchitecture.Application.UnitTests.Mocks;

public static class MockUnitOfWork
{
    public static Mock<UnitOfWork> GetUnitOfWork()
    {
        var dbContextId = Guid.NewGuid();
        
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: $"AppDbContext-{dbContextId}")
            .Options;

        var appDbContextFake = new AppDbContext(options);

        appDbContextFake.Database.EnsureDeleted();
        var mockUnitOfWork = new Mock<UnitOfWork>(appDbContextFake);
            
        return mockUnitOfWork;
    }
}