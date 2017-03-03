using System;
using System.Collections.Generic;

namespace RouterManager.Models
{
    public class Router
    {
        [Newtonsoft.Json.JsonIgnore]
        public string Id { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public bool Changed { get; set; } = false;

        public string TypeTitle { get; set; }
        public string Title { get; set; }
      

        public List<string> Tags { get; set; }

        public RouterStatus Status { get; set; }

        public string IP { get; set; }
        public string ClientIP { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public DateTime UploadTime { get; set; }
    }
}