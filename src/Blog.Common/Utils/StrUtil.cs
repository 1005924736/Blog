using System;
using System.Text;

namespace Blog.Common.Utils
{
    /// <summary>
    /// 字符串转换
    /// https://www.cnblogs.com/Jacklovely/p/5826336.html C#命名规范
    /// </summary>
    public class StrUtil
    {
        /// <summary>
        /// 首字母小写
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns></returns>
        public static string LetterLowerCase(string s)
        {
            return s.Substring(0, 1).ToLower() + s.Substring(1);
        }

        /// <summary>
        /// 首字母大写
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns></returns>
        public static string LetterUpperCase(string s)
        {
            return s.Substring(0, 1).ToUpper() + s.Substring(1);
        }


        /// <summary>
        /// 将下划线大写方式命名的字符串转换为驼峰式，例如：HELLO_WORLD->HelloWorld
        /// </summary>
        /// <param name="name">转换前的驼峰式命名的字符串</param>
        /// <returns></returns>
        public static string CamelName(string name)
        {
            StringBuilder builder = new StringBuilder();
            if (string.IsNullOrEmpty(name))
            {
                return "";
            }
            else if (!name.Contains('_'))
            {
                return name.Substring(0, 1).ToLower() + name.Substring(1);
            }
            else
            {
                string[] camels = name.Split('_');
                for (int i = 0; i < camels.Length; i++)
                {
                    builder.Append(camels[i].Substring(0, 1).ToUpper());
                    builder.Append(camels[i].Substring(1).ToLower());
                }
            }

            return builder.ToString();
        }
    }
}
