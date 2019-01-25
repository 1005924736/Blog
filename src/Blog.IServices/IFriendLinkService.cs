using Blog.Entities;
using Blog.Entities.Dtos;

namespace Blog.IServices
{
    public interface IFriendLinkService : IBaseService<FriendLink>
    {
        /// <summary>
        /// 新增/编辑友情链接
        /// </summary>
        /// <param name="link">友情链接信息</param>
        /// <returns></returns>
        OperateResult Save(FriendLink link);
    }
}
