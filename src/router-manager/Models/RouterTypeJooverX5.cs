using System;
using System.Collections.Generic;
using System.Net.Http;

namespace RouterManager.Models
{
    public class RouterTypeJooverX5 : IRouterType
    {
        public string Title { get; set; } = "JooverX5";
        public void Reconnect(Router router)
        {
 
            var result = DoCommand(router, "DISCONNECT_NETWORK");
            result = DoCommand(router, "SET_BEARER_PREFERENCE", new Dictionary<string, string>
            {
                {"BearerPreference", "Only_GSM\nLTE_preferred"}
            });
            result = DoCommand(router, "SET_BEARER_PREFERENCE", new Dictionary<string, string>
            {
                {"BearerPreference", "Only_LTE\nLTE_preferred"}
            });

            result = DoCommand(router, "CONNECT_NETWORK");
        }

        private static object DoCommand(Router router, string command,Dictionary<string,string> oldDict=null, bool notCallback=true)
        {
            using (var client = new HttpClient())

            {
                var dict = oldDict ?? new Dictionary<string, string>();
                dict["isTest"] = "false";
                dict["goformId"] = command;
                if (notCallback)
                {
                    dict["notCallback"] = "true";
                }
                var task = client.PostAsync($"http://{router.IP}/goform/goform_set_cmd_process",
                    new FormUrlEncodedContent(dict));
                try
                {
                    var response = task.Result;
                    var result = response.Content.ReadAsStringAsync().Result;
                    return result;
                }
                catch
                {
                    return string.Empty;
                }
            }
        }
    

        public string GetOutIP()
        {
            throw new NotImplementedException();
        }

        public bool IsActive()
        {
            throw new NotImplementedException();
        }
    }
}