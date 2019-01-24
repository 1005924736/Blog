using System;
using System.Collections.Generic;

namespace Blog.Web.Autofac
{
    public interface IEngine
    {
        T Resolve<T>() where T : class;

        object Resolve(Type type);

        IEnumerable<T> ResolveAll<T>();

        object ResolveUnregistered(Type type);
    }
}
