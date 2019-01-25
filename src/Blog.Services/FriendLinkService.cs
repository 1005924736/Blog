using Blog.Common.Utils;
using Blog.Entities;
using Blog.Entities.Dtos;
using Blog.IRepository;
using Blog.IServices;

namespace Blog.Services
{
    class FriendLinkService : BaseService<FriendLink>, IFriendLinkService
    {
        IFriendLinkRepository _friendLinkRepository;
        public FriendLinkService(IFriendLinkRepository friendLinkRepository) : base(friendLinkRepository)
        {
            _friendLinkRepository = friendLinkRepository;
        }

        /// <summary>
        /// 新增/编辑友情链接
        /// </summary>
        /// <param name="link">友情链接信息</param>
        /// <returns></returns>
        public OperateResult Save(FriendLink link)
        {
            if (string.IsNullOrWhiteSpace(link.FriendLinkId))
            {
                link.FriendLinkId = SnowflakeUtil.NextStringId();
                return Insert(link);
            }
            else
            {
                return Update(link, f => new { f.DeleteMark, f.CreatorTime });
            }
        }
    }
}
