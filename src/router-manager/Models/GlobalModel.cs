
using System.Collections.Generic;

namespace RouterManager.Models
{
    public class GlobalModel
    {
        public static string RoutePath { get; private set; }
        public static RouterCollection Routers { get; } = new RouterCollection();

        public static List<IRouterType> RouterTypes { get; } = new List<IRouterType>
        {
            new RouterType360P1(),
            new RouterTypeJooverX5()
        };

        public static void Init(string envContentRootPath)
        {
            if (!string.IsNullOrWhiteSpace(RoutePath))
            {
                throw new System.Exception("只能初始化一次");
            }
            RoutePath = envContentRootPath;
            Routers.Load();
        }

        public static void SaveRouters()
        {
            
        }
    }
}