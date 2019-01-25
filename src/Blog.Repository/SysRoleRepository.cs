using Blog.IRepository;
using Blog.Entities;
using SqlSugar;
using Blog.Core;

namespace Blog.Repository
{
    public class SysRoleRepository : BaseRepository<SysRole>, ISysRoleRepository
    {
        public SysRoleRepository()
        {
            //单表过滤数据
            Db.QueryFilter.Add(new SqlFilterItem
            {
                FilterValue = filete => new SqlFilterResult() { Sql = " DeleteMark=0" },
                IsJoinQuery = false
            });
        }
    }
}
