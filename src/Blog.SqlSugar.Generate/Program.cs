using System.IO;
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

            // string s = StrUtil.CamelName("TP_CMS_HTJBXX");

            string path = Directory.GetCurrentDirectory();
        }
    }

    public class DbFirst
    {
        public void Init()
        {
            BlogDbContext.ConnectionString = "Database=appsoft;Data Source=127.0.0.1;User Id=root;Password=123456;pooling=false;CharSet=utf8;port=3306";
            BlogDbContext.CreateClassFileByTable("C:\\Demo");
        }
    }
}
