using Blog.Common.Utils;
using Blog.Entities;
using Blog.Entities.Dtos;
using Blog.IRepository;
using Blog.IServices;

namespace Blog.Services
{
    public class NoticeinfoService : BaseService<Noticeinfo>, INoticeinfoService
    {
        INoticeInfoRepository _noticeInfoRepository;
        public NoticeinfoService(INoticeInfoRepository noticeInfoRepository) : base(noticeInfoRepository)
        {
            _noticeInfoRepository = noticeInfoRepository;
        }

        /// <summary>
        /// 添加/编辑通知
        /// </summary>
        /// <param name="noticeinfo">通知信息</param>
        /// <returns></returns>
        public OperateResult Save(Noticeinfo noticeinfo)
        {
            if (string.IsNullOrWhiteSpace(noticeinfo.NoticeId))
            {
                noticeinfo.NoticeId = SnowflakeUtil.NextStringId();
                return InsertRemoveCache(noticeinfo);
            }
            else
            {
                return UpdateRemoveCache(noticeinfo, f => new { f.DeleteMark, f.CreatorTime });
            }
        }
    }
}
