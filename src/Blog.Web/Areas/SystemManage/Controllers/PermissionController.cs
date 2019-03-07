using Blog.IServices;
using Blog.Web.Filter;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Web.Areas.SystemManage.Controllers
{
    [Area("SystemManage")]
    public class PermissionController : BaseControler
    {
        private readonly ISysPermissionService _sysPermissionService;
        private readonly ISysModuleService _sysModuleService;
        public PermissionController(ISysPermissionService sysPermissionService, ISysModuleService sysModuleService)
        {
            _sysPermissionService = sysPermissionService;
            _sysModuleService = sysModuleService;
        }

        [HttpGet, AllowAccessFilter]
        [Description("获取角色授权信息")]
        public async Task<JsonResult> GetAuthorization(string key)
        {
            string AuthorizeIds = "";
            if (!string.IsNullOrWhiteSpace(key))
            {
                var list = _sysPermissionService.Queryable(p => p.AuthorizeId == key).Select(o => o.SysModuleId);
                AuthorizeIds = string.Join(",", list);
            }
            return Json(new { Permission = AuthorizeIds, Tree = await _sysModuleService.Tree() });
        }

        [HttpPost]
        [Description("角色分配权限")]
        public async Task<JsonResult> Index(string roleId, List<string> permission)
        {
            return Json(await _sysPermissionService.Save(roleId, permission, CurrentUser.AccountId));
        }
    }
}