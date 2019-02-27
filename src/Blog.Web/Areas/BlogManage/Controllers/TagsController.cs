using Blog.Entities;
using Blog.Entities.Dtos;
using Blog.IServices;
using Blog.Web.Filter;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Linq;

namespace Blog.Web.Areas.BlogManage.Controllers
{
    [Area("BlogManage")]
    public class TagsController : BaseControler
    {
        private readonly ITagsInfoService _tagsInfoService;
        public TagsController(ITagsInfoService tagsInfoService)
        {
            _tagsInfoService = tagsInfoService;
        }

        [HttpPost]
        [Description("标签列表")]
        public IActionResult Index(QueryDto query)
        {
            return Json(_tagsInfoService.QueryableByPage(query), "yyyy-MM-dd HH:mm:ss");
        }

        [HttpPost]
        [Description("新增/编辑标签")]
        public IActionResult Form(TagsInfo tags)
        {
            return Json(_tagsInfoService.Save(tags));
        }

        [AllowAccessFilter]
        [Description("标签详情")]
        public IActionResult Detail(string key)
        {
            return Json(_tagsInfoService.FindEntity(c => c.TagId == key));
        }

        [HttpPost]
        [Description("删除标签")]
        public IActionResult Delete(string key)
        {
            return Json(_tagsInfoService.Update(tag => new TagsInfo() { DeleteMark = true }, c => c.TagId == key));
        }

        [HttpPost]
        [Description("启用禁用标签")]
        public IActionResult Enable(string id, bool status)
        {
            return Json(_tagsInfoService.Update(tag => new TagsInfo() { EnabledMark = status }, c => c.TagId == id));
        }

        [AllowAccessFilter]
        [Description("获取所有标签")]
        public IActionResult List()
        {
            return Json(_tagsInfoService.Queryable(c => c.EnabledMark == true).Select(d => new { value = d.TagId, name = d.TagName, selected = "", disabled = "" }));
        }
    }
}