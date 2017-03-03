namespace RouterManager.Models
{
    public interface IRouterType
    {
        string Title { get; set; }

        void Reconnect(Router router);
        string GetOutIP();

        bool IsActive();
    }
}