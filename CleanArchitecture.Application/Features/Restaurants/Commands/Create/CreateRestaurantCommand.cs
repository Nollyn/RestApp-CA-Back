using MediatR;

namespace CleanArchitecture.Application.Features.Restaurants.Commands.Create;

public class CreateRestaurantCommand : IRequest<int>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string NIF { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Coutry { get; set; } = string.Empty;
}