using Blog.Entities;
using Blog.Entities.Dtos;

namespace Blog.IServices
{
    public interface IBannerInfoService : IBaseService<BannerInfo>
    {
        /// <summary>
        /// 新增、编辑轮播图信息
        /// </summary>
        /// <param name="banner">轮播图信息</param>
        /// <returns></returns>
        OperateResult Save(BannerInfo banner);
    }
}
