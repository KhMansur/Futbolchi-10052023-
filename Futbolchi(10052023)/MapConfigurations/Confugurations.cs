using AutoMapper;
using Fulbolchi.Data.Models;
using Fulbolchi.Data.Models.Identity;
using Futbolchi_10052023_.DTOs;
using Futbolchi_10052023_.DTOs.Identity;

namespace Futbolchi_10052023_.MapConfigurations
{
    public class Confugurations : Profile
    {
        public Confugurations()
        {
            CreateMap<AddFutbolchiDTO, Futbolchi>().ReverseMap();

            CreateMap<ApiUser, UserDto>().ReverseMap();
        }
    }
}
