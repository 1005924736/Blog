using Blog.Core;
using Blog.Entities;
using Blog.IRepository;
using SqlSugar;

namespace Blog.Repository
{
    public class CategoryInfoRepository : BaseRepository<CategoryInfo>, ICategoryInfoRepository
    {
        public CategoryInfoRepository()
        {
            //单表过滤数据
            Db.QueryFilter.Add(new SqlFilterItem
            {
                FilterValue = filete => new SqlFilterResult() { Sql = "DeleteMark=0 " },
                IsJoinQuery = false
            });
        }
    }
}
