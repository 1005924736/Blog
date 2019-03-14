using System.ComponentModel;
using Blog.Entities.Dtos;
using Blog.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.SystemManage.Controllers
{
    [Area("SystemManage")]
    public class OperateLogController : BaseControler
    {
        private ISysOperateLogService _sysOperateLogService;

        public OperateLogController(ISysOperateLogService sysOperateLogService)
        {
            _sysOperateLogService = sysOperateLogService;
        }

        [HttpPost]
        [Description("操作日志数据列表")]
        public IActionResult Index(QueryDto query)
        {
            return Json(_sysOperateLogService.QueryableByPage(query), "yyyy-MM-dd HH:mm:ss");
        }
    }
}