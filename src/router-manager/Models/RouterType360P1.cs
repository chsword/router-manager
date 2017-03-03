using System;

namespace RouterManager.Models
{
    public class RouterType360P1:IRouterType
    {
        public string Title { get; set; } = "360P1";
        public void Reconnect(Router router)
        {
            throw new NotImplementedException();
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