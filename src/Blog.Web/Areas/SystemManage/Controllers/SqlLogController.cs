using System.ComponentModel;
using Blog.Entities.Dtos;
using Blog.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.SystemManage.Controllers
{
    [Area("SystemManage")]
    public class SqlLogController : BaseControler
    {
        private ISysExecuteSqlLogService _sysExecuteSqlLogService;

        public SqlLogController(ISysExecuteSqlLogService sysExecuteSqlLogService)
        {
            _sysExecuteSqlLogService = sysExecuteSqlLogService;
        }

        [HttpPost]
        [Description("SQL日志数据列表")]
        public IActionResult Index(QueryDto query)
        {
            return Json(_sysExecuteSqlLogService.QueryableByPage(query), "yyyy-MM-dd HH:mm:ss");
        }
    }
}