using System;
using System.Collections.Generic;

namespace router_manager.Models
{
    public class Router
    {
        public Guid Id { get; set; }
        public string TypeTitle { get; set; }
        public string Title { get; set; }
        public string IP { get; set; }

        public List<string> Tags { get; set; }

        public RouterStatus Status { get; set; }

        public string ClientIP { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}