using Blog.IServices;
using Blog.Web;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Blog.Web.Controllers
{
    public class CategoryController : BaseWebController
    {
        private readonly ICategoryInfoService _categoryInfoService;
        public CategoryController(ICategoryInfoService categoryInfoService)
        {
            _categoryInfoService = categoryInfoService;
        }
        public IActionResult Index()
        {
            return Json(_categoryInfoService.Queryable(c => c.EnabledMark == true && c.ParentId == "0").Select(s => new { CategoryId = s.CategoryId, CategoryName = s.CategoryName }));
        }
    }
}