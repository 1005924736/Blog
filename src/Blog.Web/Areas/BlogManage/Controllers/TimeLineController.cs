using Blog.Entities;
using Blog.Entities.Dtos;
using Blog.IServices;
using Blog.Web;
using Blog.Web.Filter;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Blog.Web.Areas.BlogManage.Controllers
{
    [Area("BlogManage")]
    public class TimeLineController : BaseControler
    {
        private readonly ITimeLineService _timeLineService;
        public TimeLineController(ITimeLineService timeLineService)
        {
            _timeLineService = timeLineService;
        }

        [Description("时光轴列表")]
        [HttpPost]
        public IActionResult Index(QueryDto query)
        {
            return Json(_timeLineService.QueryableByPage(query), "yyyy-MM-dd HH:mm:ss");
        }

        [Description("添加/修改时光轴")]
        [HttpPost]
        public IActionResult Form(TimeLine timeLine)
        {
            return Json(_timeLineService.Save(timeLine));
        }

        [AllowAccessFilter]
        [Description("时光轴详情")]
        public IActionResult Detail(string key)
        {
            return Json(_timeLineService.FindEntity(key), "yyyy-MM-dd HH:mm:ss");
        }

        [Description("删除时光轴")]
        public IActionResult Delete(string key)
        {
            return Json(_timeLineService.Update(f => new TimeLine() { DeleteMark = true }, c => c.TimeLineId == key));
        }
    }
}