using Blog.Entities;
using Blog.Entities.Dtos;

namespace Blog.IServices
{
    public interface ISysButtonService : IBaseService<SysButton>
    {
        /// <summary>
        /// 新增/修改按钮
        /// </summary>
        /// <param name="sysButton">按钮实体</param>
        /// <returns></returns>
        OperateResult Save(SysButton sysButton);
    }
}
