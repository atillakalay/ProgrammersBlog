using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Core.Utilities.Results.ComplexTypes;
using Entities.ComplexTypes;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using NToastNotify;
using ProgrammersBlog.Mvc.Areas.Admin.Models;
using ProgrammersBlog.Mvc.Helpers.Abstract;
using ProgrammersBlog.Shared.Utilities.Extensions;

namespace ProgrammersBlog.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : BaseController
    {
        private readonly SignInManager<User> _signInManager;
        private readonly IToastNotification _toastNotification;

        public UserController(UserManager<User> userManager, IMapper mapper, SignInManager<User> signInManager, IImageHelper imageHelper, IToastNotification toastNotification) : base(userManager, mapper, imageHelper)
        {
            _signInManager = signInManager;
            _toastNotification = toastNotification;
        }
        [Authorize(Roles = "SuperAdmin,User.Read")]
        public async Task<IActionResult> Index()
        {
            var users = await UserManager.Users.ToListAsync();
            return View(new UserListDto
            {
                Users = users,
                ResultStatus = ResultStatus.Success
            });
        }

        [Authorize(Roles = "SuperAdmin,User.Read")]
        [HttpGet]
        public async Task<PartialViewResult> GetDetail(int userId)
        {
            var user = await UserManager.Users.SingleOrDefaultAsync(u => u.Id == userId);
            return PartialView("_GetDetailPartial", new UserDto { User = user });
        }

        [Authorize(Roles = "SuperAdmin,User.Read")]
        [HttpGet]
        public async Task<JsonResult> GetAllUsers()
        {
            var users = await UserManager.Users.ToListAsync();
            var userListDto = JsonSerializer.Serialize(new UserListDto
            {
                Users = users,
                ResultStatus = ResultStatus.Success
            }, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(userListDto);
        }

        [Authorize(Roles = "SuperAdmin,User.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_UserAddPartial");
        }

        [Authorize(Roles = "SuperAdmin,User.Create")]
        [HttpPost]
        public async Task<IActionResult> Add(UserAddDto userAddDto)
        {
            if (ModelState.IsValid)
            {
                var uploadedImageDtoResult = await ImageHelper.Upload(userAddDto.UserName, userAddDto.PictureFile, PictureType.User);
                userAddDto.Picture = uploadedImageDtoResult.ResultStatus == ResultStatus.Success
                    ? uploadedImageDtoResult.Data.FullName
                    : "userImages/defaultUser.png";
                var user = Mapper.Map<User>(userAddDto);
                var result = await UserManager.CreateAsync(user, userAddDto.Password);
                if (result.Succeeded)
                {
                    var userAddAjaxModel = JsonSerializer.Serialize(new UserAddAjaxViewModel
                    {
                        UserDto = new UserDto
                        {
                            ResultStatus = ResultStatus.Success,
                            Message = $"{user.UserName} adlı kullanıcı adına sahip, kullanıcı başarıyla eklenmiştir.",
                            User = user
                        },
                        UserAddPartial = await this.RenderViewToStringAsync("_UserAddPartial", userAddDto)
                    });
                    return Json(userAddAjaxModel);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    var userAddAjaxErrorModel = JsonSerializer.Serialize(new UserAddAjaxViewModel
                    {
                        UserAddDto = userAddDto,
                        UserAddPartial = await this.RenderViewToStringAsync("_UserAddPartial", userAddDto)
                    });
                    return Json(userAddAjaxErrorModel);
                }

            }
            var userAddAjaxModelStateErrorModel = JsonSerializer.Serialize(new UserAddAjaxViewModel
            {
                UserAddDto = userAddDto,
                UserAddPartial = await this.RenderViewToStringAsync("_UserAddPartial", userAddDto)
            });
            return Json(userAddAjaxModelStateErrorModel);

        }

        [Authorize(Roles = "SuperAdmin,User.Delete")]
        [HttpPost]
        public async Task<JsonResult> Delete(int userId)
        {
            var user = await UserManager.FindByIdAsync(userId.ToString());
            var result = await UserManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                var deletedUser = JsonSerializer.Serialize(new UserDto
                {
                    ResultStatus = ResultStatus.Success,
                    Message = $"{user.UserName} adlı kullanıcı adına sahip kullanıcı başarıyla silinmiştir.",
                    User = user
                });
                return Json(deletedUser);
            }
            else
            {
                string errorMessages = String.Empty;
                foreach (var error in result.Errors)
                {
                    errorMessages = $"*{error.Description}\n";
                }

                var deletedUserErrorModel = JsonSerializer.Serialize(new UserDto
                {
                    ResultStatus = ResultStatus.Error,
                    Message =
                        $"{user.UserName} adlı kullanıcı adına sahip kullanıcı silinirken bazı hatalar oluştu.\n{errorMessages}",
                    User = user
                });
                return Json(deletedUserErrorModel);
            }
        }

        [Authorize(Roles = "SuperAdmin,User.Update")]
        [HttpGet]
        public async Task<PartialViewResult> Update(int userId)
        {
            var user = await UserManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
            var userUpdateDto = Mapper.Map<UserUpdateDto>(user);
            return PartialView("_UserUpdatePartial", userUpdateDto);
        }

        [Authorize(Roles = "SuperAdmin,User.Update")]
        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
        {
            if (ModelState.IsValid)
            {
                bool isNewPictureUploaded = false;
                var oldUser = await UserManager.FindByIdAsync(userUpdateDto.Id.ToString());
                var oldUserPicture = oldUser.Picture;
                if (userUpdateDto.PictureFile != null)
                {
                    var uploadedImageDtoResult = await ImageHelper.Upload(userUpdateDto.UserName, userUpdateDto.PictureFile, PictureType.User);
                    userUpdateDto.Picture = uploadedImageDtoResult.ResultStatus == ResultStatus.Success
                        ? uploadedImageDtoResult.Data.FullName
                        : "userImages/defaultUser.png";
                    if (oldUserPicture != "userImages/defaultUser.png")
                    {
                        isNewPictureUploaded = true;
                    }
                }

                var updatedUser = Mapper.Map<UserUpdateDto, User>(userUpdateDto, oldUser);
                var result = await UserManager.UpdateAsync(updatedUser);
                if (result.Succeeded)
                {
                    if (isNewPictureUploaded)
                    {
                        ImageHelper.Delete(oldUserPicture);
                    }

                    var userUpdateViewModel = JsonSerializer.Serialize(new UserUpdateAjaxViewModel
                    {
                        UserDto = new UserDto
                        {
                            ResultStatus = ResultStatus.Success,
                            Message = $"{updatedUser.UserName} adlı kullanıcı başarıyla güncellenmiştir.",
                            User = updatedUser
                        },
                        UserUpdatePartial = await this.RenderViewToStringAsync("_UserUpdatePartial", userUpdateDto)
                    });
                    return Json(userUpdateViewModel);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    var userUpdateErorViewModel = JsonSerializer.Serialize(new UserUpdateAjaxViewModel
                    {
                        UserUpdateDto = userUpdateDto,
                        UserUpdatePartial = await this.RenderViewToStringAsync("_UserUpdatePartial", userUpdateDto)
                    });
                    return Json(userUpdateErorViewModel);
                }

            }
            else
            {
                var userUpdateModelStateErrorViewModel = JsonSerializer.Serialize(new UserUpdateAjaxViewModel
                {
                    UserUpdateDto = userUpdateDto,
                    UserUpdatePartial = await this.RenderViewToStringAsync("_UserUpdatePartial", userUpdateDto)
                });
                return Json(userUpdateModelStateErrorViewModel);
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<ViewResult> ChangeDetails()
        {
            var user = await UserManager.GetUserAsync(HttpContext.User);
            var updateDto = Mapper.Map<UserUpdateDto>(user);
            return View(updateDto);
        }

        [Authorize]
        [HttpPost]
        public async Task<ViewResult> ChangeDetails(UserUpdateDto userUpdateDto)
        {
            if (ModelState.IsValid)
            {
                bool isNewPictureUploaded = false;
                var oldUser = await UserManager.GetUserAsync(HttpContext.User);
                var oldUserPicture = oldUser.Picture;
                if (userUpdateDto.PictureFile != null)
                {
                    var uploadedImageDtoResult = await ImageHelper.Upload(userUpdateDto.UserName, userUpdateDto.PictureFile, PictureType.User);
                    userUpdateDto.Picture = uploadedImageDtoResult.ResultStatus == ResultStatus.Success
                        ? uploadedImageDtoResult.Data.FullName
                        : "userImages/defaultUser.png";
                    if (oldUserPicture != "userImages/defaultUser.png")
                    {
                        isNewPictureUploaded = true;
                    }

                }

                var updatedUser = Mapper.Map<UserUpdateDto, User>(userUpdateDto, oldUser);
                var result = await UserManager.UpdateAsync(updatedUser);
                if (result.Succeeded)
                {
                    if (isNewPictureUploaded)
                    {
                        ImageHelper.Delete(oldUserPicture);
                    }
                    _toastNotification.AddSuccessToastMessage($"Bilgileriniz Başarıyla Güncellenmiştir.");
                    return View(userUpdateDto);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View(userUpdateDto);
                }

            }
            else
            {
                return View(userUpdateDto);
            }
        }

        [Authorize]
        [HttpGet]
        public ViewResult PasswordChange()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PasswordChange(UserPasswordChangeDto userPasswordChangeDto)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.GetUserAsync(HttpContext.User);
                var isVerified = await UserManager.CheckPasswordAsync(user, userPasswordChangeDto.CurrentPassword);
                if (isVerified)
                {
                    var result = await UserManager.ChangePasswordAsync(user, userPasswordChangeDto.CurrentPassword,
                        userPasswordChangeDto.NewPassword);
                    if (result.Succeeded)
                    {
                        await UserManager.UpdateSecurityStampAsync(user);
                        await _signInManager.SignOutAsync();
                        await _signInManager.PasswordSignInAsync(user, userPasswordChangeDto.NewPassword, true, false);
                        _toastNotification.AddSuccessToastMessage("Şifreniz başarıyla değiştirilmiştir.");
                        return View();
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }

                        return View(userPasswordChangeDto);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Lütfen, girmiş olduğunuz şu anki şifrenizi kontrol ediniz.");
                    return View(userPasswordChangeDto);
                }
            }
            else
            {
                return View(userPasswordChangeDto);
            }

        }
    }
}
