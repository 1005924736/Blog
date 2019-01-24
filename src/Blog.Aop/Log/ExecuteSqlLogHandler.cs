using Blog.Common.Auth;
using Blog.Common.Net;
using System;
using System.Diagnostics;

namespace Blog.Aop.Log
{
    public class ExecuteSqlLogHandler : LogHandler<ExecuteSqlLog>
    {
        Stopwatch stopwatch = new Stopwatch();
        public ExecuteSqlLogHandler(string sql, string parm) : base(LogMode.SqlLog)
        {
            AuthorizationUser currentUser = null;
            var current = HttpContextHelper.Current;
            if (current != null)
            {
                currentUser = AuthenticationHelper.Current();
            }
            if (currentUser == null)
            {
                currentUser = new AuthorizationUser()
                {
                    RealName = "匿名用户"
                };
            }
            LogInfo = new ExecuteSqlLog()
            {
                SqlCommand = sql,
                Parameter = parm,
                CreateAccountId = currentUser.AccountId,
                CreateUserName = currentUser.RealName,
                CreatorTime = DateTime.Now
            };
            stopwatch.Start();
        }

        public override void WriteLog()
        {
            stopwatch.Stop();
            LogInfo.ElapsedTime = stopwatch.Elapsed.TotalSeconds;
            base.WriteLog();
        }
    }
}
