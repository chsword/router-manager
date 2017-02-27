using System;

namespace router_manager.Models
{
    public interface IRouterType
    {
        string Title { get; set; }

        void ReConnection();
        string GetOutIP();

        bool IsActive();
    }
}