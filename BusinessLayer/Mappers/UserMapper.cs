using AutoMapper;
using Domain.Models;

namespace BusinessLayer.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserModel, UserModel>().ReverseMap();
        }
    }
}
