using Blog.Entities;
using Blog.IRepository;
using Blog.IServices;

namespace Blog.Services
{
    public class SysUserService : BaseService<SysUser>, ISysUserService
    {
        private ISysUserRepository _sysUserRepository;
        public SysUserService(ISysUserRepository sysUserRepository) : base(sysUserRepository)
        {
            _sysUserRepository = sysUserRepository;
        }
    }
}
