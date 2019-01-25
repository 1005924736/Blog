using Blog.Entities;
using Blog.IRepository;
using Blog.IServices;

namespace Blog.Services
{
    public class SysExceptionLogService : BaseService<SysExceptionLog>, ISysExceptionLogService
    {
        ISysExceptionLogRepository _sysExceptionLogRepository;
        public SysExceptionLogService(ISysExceptionLogRepository sysExceptionLogRepository) : base(sysExceptionLogRepository)
        {
            _sysExceptionLogRepository = sysExceptionLogRepository;
        }
    }
}
