using AutoMapper;
using Entities.Concrete;
using Entities.Dtos;

namespace ProgrammersBlog.Mvc.AutoMapper.Profiles
{
    public class UserProfiles:Profile
    {
        public UserProfiles()
        {
            CreateMap<UserAddDto, User>();
        }
    }
}
