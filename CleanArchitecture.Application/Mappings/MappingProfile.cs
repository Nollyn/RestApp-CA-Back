using AutoMapper;
using CleanArchitecture.Application.Features.Dishes.Commands.Create;
using CleanArchitecture.Application.Features.Dishes.Commands.Update;
using CleanArchitecture.Application.Features.Dishes.Queries.GetDishesList;
using CleanArchitecture.Application.Features.Drinks.Commands.Create;
using CleanArchitecture.Application.Features.Drinks.Commands.Update;
using CleanArchitecture.Application.Features.Drinks.Queries.GetDrinksList;
using CleanArchitecture.Application.Features.Restaurants.Commands.Create;
using CleanArchitecture.Application.Features.Restaurants.Queries.GetRestaurantsList;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Drink, DrinksVm>();
            CreateMap<CreateDrinkCommand, Drink>();
            CreateMap<UpdateDrinkCommand, Drink>();

            CreateMap<Dish, DishesVm>();
            CreateMap<CreateDishCommand, Dish>();
            CreateMap<UpdateDishCommand, Dish>();

            CreateMap<Restaurant, RestaurantsVm>();
            CreateMap<CreateRestaurantCommand, Restaurant>();
        }
    }
}
