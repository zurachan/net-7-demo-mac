using AutoMapper;
using bikestore.Entity.Auth;
using bikestore.Model.Model;

namespace bikestore.Api.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AccountModel, Account>().ReverseMap();
            CreateMap<UserModel, User>().ReverseMap();
            CreateMap<RoleModel, Role>().ReverseMap();
            CreateMap<MenuModel, Menu>().ReverseMap();
        }
    }
}
