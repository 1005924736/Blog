using Blog.Entities;
using Blog.Entities.Dtos;
using Blog.IServices;
using Blog.Web.Filter;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.IO;

namespace Blog.Web.Areas.CompanyManag.Controllers
{
    [Area("CompanyManag")]
    public class UserController : BaseControler
    {
        ISysAccountService _sysAccountService;
        ISysUserService _sysUserService;
        public UserController(ISysAccountService sysAccountService, ISysUserService sysUserService)
        {
            _sysAccountService = sysAccountService;
            _sysUserService = sysUserService;
        }

        [HttpPost]
        [Description("系统用户信息列表")]
        public ActionResult Index(QueryDto query)
        {
            return Json(_sysAccountService.AccountPagging(query), "yyyy-MM-dd");
        }

        [HttpPost]
        [Description("新增/编辑系统用户信息")]
        public ActionResult Form(AccountDetailsDto account)
        {
            return Json(_sysAccountService.Save(account, CurrentUser.UserId));
        }

        [HttpPost]
        [Description("启用/禁用系统用户")]
        public ActionResult Enable(string id, bool status)
        {
            return Json(_sysAccountService.Update(a => new SysAccount() { EnabledMark = status }, c => c.AccountId == id));
        }

        [HttpPost]
        [Description("删除系统用户")]
        public ActionResult Delete(string key)
        {
            return Json(_sysAccountService.Update(a => new SysAccount() { DeleteMark = true, DeleteAccountId = CurrentUser.AccountId }, c => c.AccountId == key));
        }

        [HttpGet]
        [Description("重置系统用户密码页面")]
        public ActionResult Reset()
        {
            return View();
        }

        [HttpPost]
        [Description("重置系统用户密码")]
        public ActionResult Reset(string key, string Password, string RePassword)
        {
            return Json(_sysAccountService.ResetPassword(key, Password, RePassword));
        }

        [HttpGet]
        [Description("获取系统用户详细信息")]
        [AllowAccessFilter]
        public ActionResult GetForm(string key)
        {
            return Json(_sysAccountService.AccountDetail(key), "yyyy-MM-dd");
        }

        [HttpPost]
        [Description("上传系统用户头像")]
        [AllowAccessFilter]
        public ActionResult Upload([FromServices]IHostingEnvironment env)
        {
            var file = Request.Form.Files[0];
            string fileName = Path.GetFileName(file.FileName);
            string fileExtension = Path.GetExtension(fileName);
            OperateResult<string> result = new OperateResult<string>();
            if (".jpg.png.gif.jpeg".Contains(fileExtension))
            {
                string savePath = env.WebRootPath + "/Uploads/Pictures";
                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                string name = DateTime.Now.ToString("yyyyMMddHHmmss") + fileExtension;
                string imgPath = savePath + "/" + name;
                using (FileStream fs = System.IO.File.Create(imgPath))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
                result.Data = "/Uploads/Pictures/" + name;
                result.Status = ResultStatus.Success;
            }
            else
            {
                result.Message = "上传图片格式必须为jpg|png|gif|jpeg";
            }
            return Json(result);
        }
    }
}