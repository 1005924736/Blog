using Blog.Common.Utils;
using Blog.Entities;
using Blog.Entities.Dtos;
using Blog.IRepository;
using Blog.IServices;

namespace Blog.Services
{
    public class TagsInfoService : BaseService<TagsInfo>, ITagsInfoService
    {
        ITagsInfoRepository _tagsInfoRepository;
        public TagsInfoService(ITagsInfoRepository tagsInfoRepository) : base(tagsInfoRepository)
        {
            _tagsInfoRepository = tagsInfoRepository;
        }

        /// <summary>
        /// 新增标签
        /// </summary>
        /// <param name="tags">标签信息</param>
        /// <returns></returns>
        public OperateResult Save(TagsInfo tags)
        {
            if (QueryableCount(c => c.TagName == tags.TagName && c.TagId != tags.TagId && tags.DeleteMark == false) > 0)
            {
                return new OperateResult("标签已存在，请勿重复添加");
            }
            if (string.IsNullOrWhiteSpace(tags.TagId))
            {
                tags.TagId = SnowflakeUtil.NextStringId();
                return Insert(tags);
            }
            else
            {
                return Update(tags, i => new { i.CreatorTime, i.EnabledMark });
            }
        }

        /// <summary>
        /// 查询各个标签文章数量
        /// </summary>
        /// <returns></returns>
        public dynamic TagsCount()
        {
            return _tagsInfoRepository.TagsCount();
        }
    }
}
