using Blog.Entities;
using Blog.IRepository;
using Blog.IServices;

namespace Blog.Services
{
    public class SysLoginLogService : BaseService<SysLoginLog>, ISysLoginLogService
    {
        ISysLoginLogRepository _sysLoginLogRepository;
        public SysLoginLogService(ISysLoginLogRepository sysLoginLogRepository) : base(sysLoginLogRepository)
        {
            _sysLoginLogRepository = sysLoginLogRepository;
        }
    }
}
