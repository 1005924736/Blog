using System.ComponentModel;
using Blog.Entities.Dtos;
using Blog.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.SystemManage.Controllers
{
    [Area("SystemManage")]
    public class LogController : BaseControler
    {
        private ISysLoginLogService _sysLoginLogService;

        public LogController(ISysLoginLogService sysLoginLogService)
        {
            _sysLoginLogService = sysLoginLogService;
        }

        [HttpPost]
        [Description("登录日志数据列表")]
        public IActionResult Index(QueryDto query)
        {
            return Json(_sysLoginLogService.QueryableByPage(query), "yyyy-MM-dd HH:mm:ss");
        }
    }
}