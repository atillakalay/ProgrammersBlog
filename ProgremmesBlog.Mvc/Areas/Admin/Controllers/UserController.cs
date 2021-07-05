using System;
using System.IO;
using System.Threading.Tasks;
using Core.Utilities.Extensions;
using Core.Utilities.Results.ComplexTypes;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProgrammersBlog.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IWebHostEnvironment _env;


        public UserController(UserManager<User> userManager, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(new UserListDto
            {
                Users = users,
                ResultStatus = ResultStatus.Success
            });
        }
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_UserAddPartial");
        }

        public async Task<string> ImageUpload(UserAddDto userAddDto)
        {
            string wwwroot = _env.WebRootPath;
            //string fileName = Path.GetFileNameWithoutExtension(userAddDto.PictureFile.FileName);
            string fileNameExtension = Path.GetExtension(userAddDto.PictureFile.FileName);
            DateTime dateTime = DateTime.Now;
            string fileName = $"{userAddDto.UserName}_{dateTime.FullDateAndTimeStringWithUnderScore()}";
            var path = Path.Combine($"{wwwroot}/img", fileName);
            await using (var stream = new FileStream(path, FileMode.Create))
            {
                await userAddDto.PictureFile.CopyToAsync(stream);
            }

            return fileName;
        }
    }
}
