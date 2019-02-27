using Blog.IServices;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Blog.Web.Controllers
{
    public class TagsController : BaseWebController
    {
        private readonly ITagsInfoService _tagsInfoService;
        public TagsController(ITagsInfoService tagsInfoService)
        {
            _tagsInfoService = tagsInfoService;
        }

        [Description("文章所属标签数量统计")]
        public IActionResult Index()
        {
            return Json(_tagsInfoService.TagsCount());
        }
    }
}