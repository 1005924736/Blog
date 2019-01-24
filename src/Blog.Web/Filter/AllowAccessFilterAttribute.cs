using System;

namespace Blog.Web.Filter
{
    /// <summary>
    /// 标记此特性不需要访问权限验证
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class AllowAccessFilterAttribute : Attribute
    {

    }
}
