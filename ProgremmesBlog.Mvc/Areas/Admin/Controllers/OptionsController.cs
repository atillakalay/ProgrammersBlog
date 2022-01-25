using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Core.Utilities.Helpers.Abstract.WritableOptionsHelper;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using NToastNotify;
using ProgrammersBlog.Mvc.Areas.Admin.Models;

namespace ProgrammersBlog.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class OptionsController : Controller
    {
        private readonly AboutUsPageInfo _aboutUsPageInfo;
        private readonly IWritableOptions<AboutUsPageInfo> _aboutUsPageInfoWriter;
        private readonly IToastNotification _toastNotification;
        private readonly WebsiteInfo _websiteInfo;
        private readonly IWritableOptions<WebsiteInfo> _websiteInfoWriter;
        private readonly SmtpSettings _smtpSettings;
        private readonly IWritableOptions<SmtpSettings> _smtpSettingsWriter;
        private readonly ArticleRightSideBarWidgetOptions _articleRightSideBarWidgetOptions;
        private readonly IWritableOptions<ArticleRightSideBarWidgetOptions> _articleRightSideBarWidgetOptionsWriter;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public OptionsController(IOptionsSnapshot<AboutUsPageInfo> aboutUsPageInfo, IWritableOptions<AboutUsPageInfo> aboutUsPageInfoWriter, IToastNotification toastNotification, IOptionsSnapshot<WebsiteInfo> websiteInfo, IWritableOptions<WebsiteInfo> websiteInfoWriter, IOptionsSnapshot<SmtpSettings> smtpSettings, IWritableOptions<SmtpSettings> smtpSettingsWriter, IOptionsSnapshot<ArticleRightSideBarWidgetOptions> articleRightSideBarWidgetOptions, IWritableOptions<ArticleRightSideBarWidgetOptions> articleRightSideBarWidgetOptionsWriter, ICategoryService categoryService, IMapper mapper)
        {
            _aboutUsPageInfoWriter = aboutUsPageInfoWriter;
            _toastNotification = toastNotification;
            _websiteInfoWriter = websiteInfoWriter;
            _smtpSettingsWriter = smtpSettingsWriter;
            _articleRightSideBarWidgetOptionsWriter = articleRightSideBarWidgetOptionsWriter;
            _categoryService = categoryService;
            _mapper = mapper;
            _articleRightSideBarWidgetOptions = articleRightSideBarWidgetOptions.Value;
            _smtpSettings = smtpSettings.Value;
            _websiteInfo = websiteInfo.Value;
            _aboutUsPageInfo = aboutUsPageInfo.Value;
        }

        [HttpGet]
        public IActionResult About()
        {
            return View(_aboutUsPageInfo);
        }
        [HttpPost]
        public IActionResult About(AboutUsPageInfo aboutUsPageInfo)
        {
            if (ModelState.IsValid)
            {
                _aboutUsPageInfoWriter.Update(x =>
                {
                    x.Header = aboutUsPageInfo.Header;
                    x.Content = aboutUsPageInfo.Content;
                    x.SeoAuthor = aboutUsPageInfo.SeoAuthor;
                    x.SeoDescription = aboutUsPageInfo.SeoDescription;
                    x.SeoTags = aboutUsPageInfo.SeoTags;
                });
                _toastNotification.AddSuccessToastMessage("Hakkımızda Sayfa İçerikleri başarıyla güncellenmiştir.", new ToastrOptions
                {
                    Title = "Başarılı İşlem!"
                });
                return View(aboutUsPageInfo);

            }
            return View(aboutUsPageInfo);
        }
        [HttpGet]
        public IActionResult GeneralSettings()
        {
            return View(_websiteInfo);
        }
        [HttpPost]
        public IActionResult GeneralSettings(WebsiteInfo websiteInfo)
        {
            if (ModelState.IsValid)
            {
                _websiteInfoWriter.Update(x =>
                {
                    x.Title = websiteInfo.Title;
                    x.MenuTitle = websiteInfo.MenuTitle;
                    x.SeoAuthor = websiteInfo.SeoAuthor;
                    x.SeoDescription = websiteInfo.SeoDescription;
                    x.SeoTags = websiteInfo.SeoTags;
                });
                _toastNotification.AddSuccessToastMessage("Sitenizin genel ayarları başarıyla güncellenmiştir.", new ToastrOptions
                {
                    Title = "Başarılı İşlem!"
                });
                return View(websiteInfo);

            }
            return View(websiteInfo);
        }
        [HttpGet]
        public IActionResult EmailSettings()
        {
            return View(_smtpSettings);
        }
        [HttpPost]
        public IActionResult EmailSettings(SmtpSettings smtpSettings)
        {
            if (ModelState.IsValid)
            {
                _smtpSettingsWriter.Update(x =>
                {
                    x.Server = smtpSettings.Server;
                    x.Port = smtpSettings.Port;
                    x.SenderName = smtpSettings.SenderName;
                    x.SenderEmail = smtpSettings.SenderEmail;
                    x.Username = smtpSettings.Username;
                    x.Password = smtpSettings.Password;
                });
                _toastNotification.AddSuccessToastMessage("Sitenizin e-posta ayarları başarıyla güncellenmiştir.", new ToastrOptions
                {
                    Title = "Başarılı İşlem!"
                });
                return View(smtpSettings);

            }
            return View(smtpSettings);
        }

        [HttpGet]
        public async Task<IActionResult> ArticleRightSideBarWidgetSettings()
        {
            var categoriesResult = await _categoryService.GetAllByNonDeletedAndActiveAsync();
            var articleRightSideBarWidgetOptionsViewModel =
                _mapper.Map<ArticleRightSideBarWidgetOptionsViewModel>(_articleRightSideBarWidgetOptions);
            articleRightSideBarWidgetOptionsViewModel.Categories = categoriesResult.Data.Categories;
            return View(articleRightSideBarWidgetOptionsViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> ArticleRightSideBarWidgetSettings(ArticleRightSideBarWidgetOptionsViewModel articleRightSideBarWidgetOptionsViewModel)
        {
            var categoriesResult = await _categoryService.GetAllByNonDeletedAndActiveAsync();
            articleRightSideBarWidgetOptionsViewModel.Categories = categoriesResult.Data.Categories;
            if (ModelState.IsValid)
            {
                _articleRightSideBarWidgetOptionsWriter.Update(x =>
                {
                    x.Header = articleRightSideBarWidgetOptionsViewModel.Header;
                    x.TakeSize = articleRightSideBarWidgetOptionsViewModel.TakeSize;
                    x.CategoryId = articleRightSideBarWidgetOptionsViewModel.CategoryId;
                    x.FilterBy = articleRightSideBarWidgetOptionsViewModel.FilterBy;
                    x.OrderBy = articleRightSideBarWidgetOptionsViewModel.OrderBy;
                    x.IsAscending = articleRightSideBarWidgetOptionsViewModel.IsAscending;
                    x.StartAt = articleRightSideBarWidgetOptionsViewModel.StartAt;
                    x.EndAt = articleRightSideBarWidgetOptionsViewModel.EndAt;
                    x.MaxViewCount = articleRightSideBarWidgetOptionsViewModel.MaxViewCount;
                    x.MinViewCount = articleRightSideBarWidgetOptionsViewModel.MinViewCount;
                    x.MaxCommentCount = articleRightSideBarWidgetOptionsViewModel.MaxCommentCount;
                    x.MinCommentCount = articleRightSideBarWidgetOptionsViewModel.MinCommentCount;
                });
                _toastNotification.AddSuccessToastMessage("Makale sayfalarınızın widget ayarları başarıyla güncellenmiştir.", new ToastrOptions
                {
                    Title = "Başarılı İşlem!"
                });
                return View(articleRightSideBarWidgetOptionsViewModel);

            }
            return View(articleRightSideBarWidgetOptionsViewModel);
        }
    }
}
