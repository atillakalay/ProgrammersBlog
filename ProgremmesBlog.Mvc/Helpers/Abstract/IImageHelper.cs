using System.Threading.Tasks;
using Core.Utilities.Results.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;

namespace ProgrammersBlog.Mvc.Helpers.Abstract
{
    public interface IImageHelper
    {
        Task<IDataResult<ImageUploadedDto>> UploadUserImage(string userName, IFormFile pictureFile, string folderName = "userImages");
        IDataResult<ImageDeletedDto> Delete(string pictureName);
    }
}