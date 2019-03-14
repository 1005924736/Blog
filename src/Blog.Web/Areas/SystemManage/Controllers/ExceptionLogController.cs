using System.ComponentModel;
using Blog.Entities.Dtos;
using Blog.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.SystemManage.Controllers
{
    [Area("SystemManage")]
    public class ExceptionLogController : BaseControler
    {
        private ISysExceptionLogService _sysExceptionLogService;

        public ExceptionLogController(ISysExceptionLogService sysExceptionLogService)
        {
            _sysExceptionLogService = sysExceptionLogService;
        }

        [HttpPost]
        [Description("异常日志数据列表")]
        public IActionResult Index(QueryDto query)
        {
            return Json(_sysExceptionLogService.QueryableByPage(query), "yyyy-MM-dd HH:mm:ss");
        }
    }
}