using System;
using System.Collections.Generic;
using System.Text;

namespace Natural_Core.Models
{
    public class Response
    {
        public string? Message { get; set; }
        public int StatusCode { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
