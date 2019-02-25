using Newtonsoft.Json.Converters;

namespace Blog.Common.Log
{
    public class DateTimeFormat : IsoDateTimeConverter
    {
        public DateTimeFormat()
        {
            DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        }
    }
}
