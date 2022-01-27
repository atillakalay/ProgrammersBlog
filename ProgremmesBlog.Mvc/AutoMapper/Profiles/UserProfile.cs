using AutoMapper;
using Entities.ComplexTypes;
using Entities.Concrete;
using Entities.Dtos;
using ProgrammersBlog.Mvc.Helpers.Abstract;

namespace ProgrammersBlog.Mvc.AutoMapper.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile(IImageHelper imageHelper)
        {
            CreateMap<UserAddDto, User>().ForMember(dest => dest.Picture, opt => opt.MapFrom(x => imageHelper.Upload(x.UserName, x.PictureFile, PictureType.User, null)));
            CreateMap<User, UserUpdateDto>();
            CreateMap<UserUpdateDto, User>();
        }
    }
}
