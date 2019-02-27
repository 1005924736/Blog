using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.IO;
using SqlSugar;

namespace Blog.Common.Utils
{
    /// <summary>
    /// 配置文件相关操作
    /// </summary>
    public class ConfigurationUtil
    {
        public static readonly IConfiguration Configuration;

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static string DBConnectionString { get => Configuration.GetConnectionString("MySqlConnection"); }

        /// <summary>
        /// Redis连接字符串
        /// </summary>
        public static string RedisConnectionString { get => Configuration.GetConnectionString("RedisConnection"); }

        /// <summary>
        /// 数据库类型
        /// </summary>
        public static DbType DbType
        {
            get
            {
                DbType dbType = DbType.SqlServer;
                string s = ConfigurationUtil.GetSection("DbType");
                switch (s)
                {
                    case "MySql":
                        dbType = DbType.MySql;
                        break;
                    case "SqlServer":
                        dbType = DbType.SqlServer;
                        break;
                    case "Sqlite":
                        dbType = DbType.Sqlite;
                        break;
                    case "Oracle":
                        dbType = DbType.Oracle;
                        break;
                    case "PostgreSQL":
                        dbType = DbType.PostgreSQL;
                        break;
                    default:
                        dbType = DbType.SqlServer;
                        break;
                }

                return dbType;
            }
        }

        static ConfigurationUtil()
        {
            string directory = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf(@"\bin")); //Directory.GetCurrentDirectory()
            Configuration = new ConfigurationBuilder()
                .SetBasePath(directory)
                .AddJsonFile("appsettings.json", true)
                .Build();
        }

        /// <summary>
        /// 将制定节点转换为实体对象
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="key">配置文件key</param>
        /// <returns></returns>
        public static T GetSection<T>(string key) where T : class, new()
        {
            var obj = new ServiceCollection()
                .AddOptions()
                .Configure<T>(Configuration.GetSection(key))
                .BuildServiceProvider()
                .GetService<IOptions<T>>()
                .Value;
            return obj;
        }

        /// <summary>
        /// 获取指定key对应的value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetSection(string key)
        {
            return Configuration.GetValue<string>(key);
        }
    }
}
