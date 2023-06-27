using AutoMapper;
using StudyCaseWebApp.DAL.Models;

namespace Bussines.Utils
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<VmUser, User>().ReverseMap();
            CreateMap<VmUpdateUser, User>().ReverseMap();
            CreateMap<VmGetUser, User>().ReverseMap();
        }
    }
}
