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
        private ISysOperateLogService _sysOperateLogService;
        private ISysExecuteSqlLogService _sysExecuteSqlLogService;
        private ISysExceptionLogService _sysExceptionLogService;

        public LogController(ISysLoginLogService sysLoginLogService, ISysOperateLogService sysOperateLogService, ISysExecuteSqlLogService sysExecuteSqlLogService, ISysExceptionLogService sysExceptionLogService)
        {
            _sysLoginLogService = sysLoginLogService;
            _sysOperateLogService = sysOperateLogService;
            _sysExecuteSqlLogService = sysExecuteSqlLogService;
            _sysExceptionLogService = sysExceptionLogService;
        }

        [HttpGet]
        [Description("登录日志数据列表")]
        public IActionResult LoginLog(QueryDto query)
        {
            return Json(_sysLoginLogService.QueryableByPage(query), "yyyy-MM-dd HH:mm:ss");
        }

        [HttpPost]
        [Description("操作日志数据列表")]
        public IActionResult OperateLog(QueryDto query)
        {
            return Json(_sysOperateLogService.QueryableByPage(query), "yyyy-MM-dd HH:mm:ss");
        }

        [HttpPost]
        [Description("SQL日志数据列表")]
        public IActionResult SqlLog(QueryDto query)
        {
            return Json(_sysExecuteSqlLogService.QueryableByPage(query), "yyyy-MM-dd HH:mm:ss");
        }

        [HttpPost]
        [Description("异常日志数据列表")]
        public IActionResult ExceptionLog(QueryDto query)
        {
            return Json(_sysExceptionLogService.QueryableByPage(query), "yyyy-MM-dd HH:mm:ss");
        }
    }
}