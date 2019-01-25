using Blog.Entities;
using Blog.IRepository;
using Blog.IServices;

namespace Blog.Services
{
    public class SysOperateLogService : BaseService<SysOperateLog>, ISysOperateLogService
    {
        ISysOperateLogRepository _sysOperateLogService;
        public SysOperateLogService(ISysOperateLogRepository sysOperateLogRepository) : base(sysOperateLogRepository)
        {
            _sysOperateLogService = sysOperateLogRepository;
        }
    }
}
