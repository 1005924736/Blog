using Blog.Entities;
using Blog.Entities.Dtos;

namespace Blog.IServices
{
    public interface ISysRoleService : IBaseService<SysRole>
    {
        /// <summary>
        /// 新增/修改角色
        /// </summary>
        /// <param name="sysRole"></param>
        /// <returns></returns>
        OperateResult Save(SysRole sysRole);
    }
}
