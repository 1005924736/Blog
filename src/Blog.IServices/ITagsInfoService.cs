using Blog.Entities;
using Blog.Entities.Dtos;

namespace Blog.IServices
{
    public interface ITagsInfoService : IBaseService<TagsInfo>
    {
        /// <summary>
        /// 新增标签
        /// </summary>
        /// <param name="tags">标签信息</param>
        /// <returns></returns>
        OperateResult Save(TagsInfo tags);

        /// <summary>
        /// 查询各个标签文章数量
        /// </summary>
        /// <returns></returns>
        dynamic TagsCount();
    }
}
