using Blog.Common.Utils;
using Blog.Entities;
using Blog.Entities.Dtos;
using Blog.IRepository;
using Blog.IServices;

namespace Blog.Services
{
    public class SysRoleService : BaseService<SysRole>, ISysRoleService
    {
        private ISysRoleRepository _sysRoleRepository;
        public SysRoleService(ISysRoleRepository sysRoleRepository) : base(sysRoleRepository)
        {
            _sysRoleRepository = sysRoleRepository;
        }

        /// <summary>
        /// 新增/修改角色
        /// </summary>
        /// <param name="sysRole">角色实体</param>
        /// <returns></returns>
        public OperateResult Save(SysRole sysRole)
        {
            if (QueryableCount(c => c.EnCode == sysRole.EnCode && c.RoleId != sysRole.RoleId && sysRole.DeleteMark == false) > 0)
            {
                OperateResult result = new OperateResult();
                result.Message = "角色编码已存在";
                return result;
            }
            if (string.IsNullOrWhiteSpace(sysRole.RoleId))
            {
                sysRole.RoleId = SnowflakeUtil.NextStringId();
                return Insert(sysRole);
            }
            else
            {
                return Update(sysRole, i => new { i.CreatorTime, i.CreatorAccountId, i.DeleteMark });
            }
        }
    }
}
