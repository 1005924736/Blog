using Blog.Core;
using Blog.Entities;

namespace Blog.IRepository
{
    public interface ITagsInfoRepository : IBaseRepository<TagsInfo>
    {
        /// <summary>
        /// 查询各个标签文章数量
        /// </summary>
        /// <returns></returns>
        dynamic TagsCount();
    }
}
