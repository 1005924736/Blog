using Blog.Entities;
using Blog.IRepository;
using Blog.IServices;

namespace Blog.Services
{
    class SysExecuteSqlLogService : BaseService<SysExecuteSqlLog>, ISysExecuteSqlLogService
    {
        ISysExecuteSqlLogRepository _sysExecuteSqlLogRepository;
        public SysExecuteSqlLogService(ISysExecuteSqlLogRepository sysExecuteSqlLogRepository) : base(sysExecuteSqlLogRepository)
        {
            _sysExecuteSqlLogRepository = sysExecuteSqlLogRepository;
        }
    }
}
