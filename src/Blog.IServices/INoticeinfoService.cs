using Blog.Entities;
using Blog.Entities.Dtos;

namespace Blog.IServices
{
    public interface INoticeinfoService : IBaseService<Noticeinfo>
    {
        /// <summary>
        /// 添加/编辑通知
        /// </summary>
        /// <param name="noticeinfo">通知信息</param>
        /// <returns></returns>
        OperateResult Save(Noticeinfo noticeinfo);
    }
}
