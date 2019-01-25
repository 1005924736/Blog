using Blog.Entities;
using Blog.Entities.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.IServices
{
    public interface ISysModuleService : IBaseService<SysModule>
    {
        /// <summary>
        /// 新增/修改菜单
        /// </summary>
        /// <param name="module"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        OperateResult Save(SysModule module);

        /// <summary>
        /// 菜单按钮树
        /// </summary>
        /// <returns></returns>
        Task<List<TreeModuleDto>> Tree();
    }
}
