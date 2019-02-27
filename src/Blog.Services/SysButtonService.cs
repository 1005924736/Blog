using Blog.Common.Utils;
using Blog.Entities;
using Blog.Entities.Dtos;
using Blog.IRepository;
using Blog.IServices;

namespace Blog.Services
{
    public class SysButtonService : BaseService<SysButton>, ISysButtonService
    {
        ISysButtonRepository _sysButtonRepository;
        public SysButtonService(ISysButtonRepository sysButtonRepository) : base(sysButtonRepository)
        {
            _sysButtonRepository = sysButtonRepository;
        }

        /// <summary>
        /// 新增/修改按钮
        /// </summary>
        /// <param name="sysButton">按钮实体</param>
        /// <returns></returns>
        public OperateResult Save(SysButton sysButton)
        {
            if (_sysButtonRepository.QueryableCount(c => c.EnCode == sysButton.EnCode && c.ButtonId != sysButton.ButtonId && c.SysModuleId == sysButton.SysModuleId) > 0)
            {
                OperateResult result = new OperateResult();
                result.Message = "按钮编码已存在";
                return result;
            }
            if (string.IsNullOrEmpty(sysButton.ButtonId))
            {
                sysButton.ButtonId = SnowflakeUtil.NextStringId();
                return InsertRemoveCache(sysButton);
            }
            else
            {
                return UpdateRemoveCache(sysButton, i => new { i.SysModuleId, i.CreatorTime, i.CreatorAccountId });
            }
        }
    }
}
