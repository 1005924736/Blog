using Blog.Core;
using Blog.Entities;
using Blog.Entities.Dtos;
using Blog.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Blog.Repository
{
    /// <summary>
    /// 系统用户仓储
    /// </summary>
    public class SysAccountRepository : BaseRepository<SysAccount>, ISysAccountRepository
    {
        /// <summary>
        /// 账户详细信息列表
        /// </summary>
        public PageResult<List<AccountDetailsDto>> AccountPaging(QueryDto queryDto)
        {
            int total = 0;
            var query = Db.Queryable<SysAccount, SysUser>((a, u) => a.AccountId == u.AccountId);
            if (queryDto.ConditionalModels.Any())
            {
                query.Where(queryDto.ConditionalModels);
            }
            var list = query.Select<AccountDetailsDto>().ToPageList(queryDto.page, queryDto.limit, ref total);
            return new PageResult<List<AccountDetailsDto>>() { data = list, count = total, code = 0 };
        }

        /// <summary>
        /// 获取系统账户详细信息
        /// </summary>
        /// <param name="accountId">账户id</param>
        /// <returns></returns>
        public AccountDetailsDto AccountDetail(string accountId)
        {
            var query = Db.Queryable<SysAccount, SysUser>((a, u) => a.AccountId == u.AccountId);
            return query.Where((a, u) => a.AccountId == accountId).Select<AccountDetailsDto>().First();
        }

        /// <summary>
        /// 获取系统账户详细信息
        /// </summary>
        /// <param name="expression">查询条件</param>
        /// <returns></returns>
        public AccountDetailsDto AccountDetail(Expression<Func<SysAccount, bool>> expression)
        {
            var query = Db.Queryable<SysAccount, SysUser>((a, u) => a.AccountId == u.AccountId);
            return query.Where(expression).Select<AccountDetailsDto>().First();
        }
    }
}
