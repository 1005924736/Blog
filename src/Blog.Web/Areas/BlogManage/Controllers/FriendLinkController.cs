using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using Blog.Entities;
using Blog.Entities.Dtos;
using Blog.IServices;
using Blog.Web;
using Blog.Web.Filter;

namespace Blog.Web.Areas.BlogManage.Controllers
{
    [Area("BlogManage")]
    public class FriendLinkController : BaseControler
    {
        private readonly IFriendLinkService _friendLinkService;
        public FriendLinkController(IFriendLinkService friendLinkService)
        {
            _friendLinkService = friendLinkService;
        }
        [HttpPost]
        [Description("友情链接信息列表")]
        public IActionResult Index(QueryDto query)
        {
            return Json(_friendLinkService.QueryableByPage(query), "yyyy-MM-dd HH:mm:ss");
        }

        [Description("新增/编辑友情链接信息")]
        [HttpPost]
        public IActionResult Form(FriendLink friendLink)
        {
            return Json(_friendLinkService.Save(friendLink));
        }

        [Description("友情链接详情")]
        [AllowAccessFilter]
        public IActionResult Detail(string key)
        {
            return Json(_friendLinkService.FindEntity(c => c.FriendLinkId == key));
        }

        [Description("删除友情链接信息")]
        [HttpPost]
        public IActionResult Delete(string key)
        {
            return Json(_friendLinkService.Update(f => new FriendLink() { DeleteMark = true }, c => c.FriendLinkId == key));
        }
    }
}