using Blog.Entities;
using Blog.Entities.Dtos;

namespace Blog.IServices
{
    public interface ICategoryInfoService : IBaseService<CategoryInfo>
    {
        /// <summary>
        /// 新增修改栏目
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        OperateResult Save(CategoryInfo category);
    }
}
