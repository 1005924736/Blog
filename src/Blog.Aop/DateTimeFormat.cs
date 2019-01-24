using Newtonsoft.Json.Converters;

namespace Blog.Aop
{
    public class DateTimeFormat : IsoDateTimeConverter
    {
        public DateTimeFormat()
        {
            DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        }
    }
}
