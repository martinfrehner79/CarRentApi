using CarRentApi.Models.Classes;
using CarRentApi.Models.Dtos;
using AutoMapper;

namespace CarRentApi.Models.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Car, CarDto>();
            CreateMap<CarDto, Car>();

            CreateMap<CarClass, CarClassDto>();
            CreateMap<CarClassDto, CarClass>();

            CreateMap<CarBrand, CarBrandDto>();
            CreateMap<CarBrandDto, CarBrand>();

            CreateMap<Contract, ContractDto>();
            CreateMap<ContractDto, Contract>();

            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();

            CreateMap<Reservation, ReservationDto>();
            CreateMap<ReservationDto, Reservation>();

            CreateMap<DailyFee, DailyFeeDto>();
            CreateMap<DailyFeeDto, DailyFee>();
        }
    }
}
