using Blog.Common.Utils;
using Blog.Entities;
using Blog.Entities.Dtos;
using Blog.IRepository;
using Blog.IServices;

namespace Blog.Services
{
    public class BannerInfoService : BaseService<BannerInfo>, IBannerInfoService
    {
        IBannerInfoRepository _bannerInfoRepository;
        public BannerInfoService(IBannerInfoRepository bannerInfoRepository) : base(bannerInfoRepository)
        {
            _bannerInfoRepository = bannerInfoRepository;
        }

        /// <summary>
        /// 添加/修改banner图
        /// </summary>
        /// <param name="banner">轮播图信息</param>
        /// <returns></returns>
        public OperateResult Save(BannerInfo banner)
        {
            if (string.IsNullOrWhiteSpace(banner.BannerId))
            {
                banner.BannerId = SnowflakeUtil.NextStringId();
                return Insert(banner);
            }
            else
            {
                return Update(banner, i => new { i.CreatorTime, i.DeleteMark });
            }
        }
    }
}
