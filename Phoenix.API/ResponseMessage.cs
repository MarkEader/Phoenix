using System.Collections.Generic;

namespace Phoenix.API
{
    public class ResponseMessage<T>
    {
        public bool Success { get; set; }
        public List<T> Items { get; set; }
        public string ExceptionMessage { get; set; }
    }
}