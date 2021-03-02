using System;

namespace Admin.Entity
{
    public class Response
    {
        public bool IsSuccess { get; set; }

        public object[] Data { get; set; }

        public string ErrorMessage { get; set; }

        public Exception Exception { get; set; }
    }
}
