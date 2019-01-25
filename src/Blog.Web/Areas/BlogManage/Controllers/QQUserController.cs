using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using Blog.Entities;
using Blog.Entities.Dtos;
using Blog.IServices;
using Blog.Web;

namespace Blog.Web.Areas.BlogManage.Controllers
{
    [Area("BlogManage")]
    public class QQUserController : BaseControler
    {
        private readonly IQQUserinfoService _qQUserinfoService;
        public QQUserController(IQQUserinfoService qQUserinfoService)
        {
            _qQUserinfoService = qQUserinfoService;
        }

        [HttpPost]
        [Description("QQ用户列表")]
        public IActionResult Index(QueryDto query)
        {
            return Json(_qQUserinfoService.QueryableByPage(query), "yyyy-MM-dd HH:mm:ss");
        }

        [HttpPost]
        [Description("是否设置为博主")]
        public IActionResult Master(string key, bool status)
        {
            return Json(_qQUserinfoService.Update(qq => new QQUserinfo() { IsMaster = status }, c => c.UserId == key));
        }

        [HttpPost]
        [Description("删除QQ用户")]
        public IActionResult Delete(string key)
        {
            return Json(_qQUserinfoService.Delete(c => c.UserId == key));
        }
    }
}