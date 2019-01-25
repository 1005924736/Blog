using Blog.Entities;
using Blog.Entities.Dtos;

namespace Blog.IServices
{
    public interface ITimeLineService : IBaseService<TimeLine>
    {
        /// <summary>
        /// 添加/编辑时间轴
        /// </summary>
        /// <param name="timeLine"></param>
        /// <returns></returns>
        OperateResult Save(TimeLine timeLine);
    }
}
