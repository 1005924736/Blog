using Blog.Entities.Dtos;
using Blog.IServices;
using Blog.Web.Filter;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Blog.Web.Areas.Main.Controllers
{
    [Area("Main")]
    public class HomeController : BaseControler
    {
        private readonly ISysAccountService _sysAccountService;
        public HomeController(ISysAccountService sysAccountService)
        {
            _sysAccountService = sysAccountService;
        }
        [AllowAccessFilter]
        public override IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 默认加载页
        /// </summary>
        /// <returns></returns>
        [Description("后台首页")]
        [AllowAccessFilter]
        public ActionResult Default()
        {
            return View();
        }

        /// <summary>
        /// 修改密码页面
        /// </summary>
        /// <returns></returns>
        [Description("修改密码页面")]
        [AllowAccessFilter]
        public IActionResult Password()
        {
            return View();
        }

        [Description("修改个人信息页面")]
        [AllowAccessFilter]
        public IActionResult Info()
        {
            ViewBag.AccountId = CurrentUser.AccountId;
            return View();
        }

        [HttpPost]
        [Description("修改个人信息")]
        [AllowAccessFilter]
        public ActionResult Info(AccountDetailsDto account)
        {
            account.AccountId = CurrentUser.AccountId;
            account.RoleId = CurrentUser.RoleId;
            account.UserName = CurrentUser.UserName;
            return Json(_sysAccountService.Save(account, CurrentUser.UserId));
        }

        [HttpPost]
        [Description("修改密码")]
        [AllowAccessFilter]
        public IActionResult ChangePwd(string OldPassword, string Password)
        {
            return Json(_sysAccountService.ChangePwd(CurrentUser.AccountId, OldPassword, Password));
        }

        [HttpPost]
        [Description("解锁")]
        [AllowAccessFilter]
        public IActionResult Lock(string pwd)
        {
            var data = _sysAccountService.Login(CurrentUser.UserName, pwd);
            OperateResult result = new OperateResult();
            result.Status = data.Status;
            result.Message = data.Message;
            return Json(result);
        }
    }
}