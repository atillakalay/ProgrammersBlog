using System.Threading.Tasks;
using Core.Utilities.Results.Abstract;
using Entities.ComplexTypes;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;

namespace ProgrammersBlog.Mvc.Helpers.Abstract
{
    public interface IImageHelper
    {
     string Upload(string name, IFormFile pictureFile, PictureType pictureType, string folderName = null);
        IDataResult<ImageDeletedDto> Delete(string pictureName);
    }
}