using Blog.Entities;
using Blog.IServices;
using Blog.Web;
using Blog.Web.Filter;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace AppSoft.Areas.SystemManage.Controllers
{
    [Area("SystemManage")]
    public class ButtonController : BaseControler
    {
        private readonly ISysButtonService _sysButtonService;
        public ButtonController(ISysButtonService sysButtonService)
        {
            _sysButtonService = sysButtonService;
        }
        [HttpPost]
        [Description("获取菜单下所有按钮")]
        public IActionResult Index(string moduleId)
        {
            var list = _sysButtonService.Queryable(b => b.SysModuleId == moduleId, o => o.SortCode, false);
            var obj = new { code = 0, msg = "成功", count = list.Count, data = list };
            return Json(obj);
        }

        [HttpPost]
        [Description("新增按钮")]
        public IActionResult Form(SysButton button)
        {
            button.EnCode = button.JsEvent;
            button.CreatorAccountId = CurrentUser.AccountId;
            return Json(_sysButtonService.Save(button));
        }

        [HttpGet, Description("获取按钮详情")]
        [AllowAccessFilter]
        public IActionResult GetForm(string key)
        {
            return Json(_sysButtonService.FindEntity(b => b.ButtonId == key));
        }

        [HttpPost]
        [Description("删除按钮")]
        public IActionResult Delete(string key)
        {
            return Json(_sysButtonService.Delete(key));
        }
    }
}