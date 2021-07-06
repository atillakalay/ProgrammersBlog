using AutoMapper;
using Entities.Concrete;
using Entities.Dtos;

namespace ProgrammersBlog.Mvc.AutoMapper.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<UserAddDto, User>();
        }
    }
}
