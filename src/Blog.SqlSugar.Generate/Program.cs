using System.IO;
using App.Common.Builder;
using Blog.Common.Utils;
using Blog.Core;

namespace Blog.SqlSugar.Generate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //DbFirst dbFirst = new DbFirst();
            //dbFirst.Init();
        }
    }

    public class DbFirst
    {
        public void Init()
        {
            BlogDbContext.ConnectionString = ConfigurationUtil.DBConnectionString;
            BlogDbContext.CreateClassFileByTable("C:\\Demo");
        }
    }
}
