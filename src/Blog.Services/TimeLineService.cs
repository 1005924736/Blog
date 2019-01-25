using Blog.Common.Utils;
using Blog.Entities;
using Blog.Entities.Dtos;
using Blog.IRepository;
using Blog.IServices;

namespace Blog.Services
{
    public class TimeLineService : BaseService<TimeLine>, ITimeLineService
    {
        ITimeLineRepository _timeLineRepository;
        public TimeLineService(ITimeLineRepository timeLineRepository) : base(timeLineRepository)
        {
            _timeLineRepository = timeLineRepository;
        }

        /// <summary>
        /// 添加/编辑时间轴
        /// </summary>
        /// <param name="timeLine"></param>
        /// <returns></returns>
        public OperateResult Save(TimeLine timeLine)
        {
            if (string.IsNullOrWhiteSpace(timeLine.TimeLineId))
            {
                timeLine.TimeLineId = SnowflakeUtil.NextStringId();
                return Insert(timeLine);
            }
            else
            {
                return Update(timeLine, f => new { f.DeleteMark, f.CreatorTime });
            }
        }
    }
}
