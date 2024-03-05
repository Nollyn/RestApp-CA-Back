﻿namespace CleanArchitecture.Application.Features.Restaurants.Queries.GetRestaurantsList;

public class RestaurantsVm
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