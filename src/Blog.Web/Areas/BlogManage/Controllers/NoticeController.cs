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
    public class NoticeController : BaseControler
    {
        private readonly INoticeinfoService _noticeinfoService;
        public NoticeController(INoticeinfoService noticeinfoService)
        {
            _noticeinfoService = noticeinfoService;
        }

        [HttpPost]
        [Description("通知列表")]
        public IActionResult Index(QueryDto query)
        {
            return Json(_noticeinfoService.QueryableByPage(query), "yyyy-MM-dd HH:mm:ss");
        }

        [HttpPost]
        [Description("新增/编辑通知")]
        public IActionResult Form(Noticeinfo noticeinfo)
        {
            return Json(_noticeinfoService.Save(noticeinfo));
        }
        
        [AllowAccessFilter]
        [Description("通知详情")]
        public IActionResult Detail(string key)
        {
            return Json(_noticeinfoService.FindEntity(c => c.NoticeId == key));
        }

        [HttpPost]
        [Description("删除通知")]
        public IActionResult Delete(string key)
        {
            return Json(_noticeinfoService.Update(n => new Noticeinfo() { DeleteMark = true }, c => c.NoticeId == key));
        }
    }
}