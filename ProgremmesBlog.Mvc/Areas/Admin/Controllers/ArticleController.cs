using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results.ComplexTypes;

namespace ProgrammersBlog.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _articleService.GetAllByNonDeletedAsync();
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            else
            {
                return NotFound();
            }

        }

        public IActionResult Add()
        {
            return View();
        }
    }
}
