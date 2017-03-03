using System;
using Microsoft.AspNetCore.Mvc;
using RouterManager.Models;

namespace RouterManager.Controllers
{
    [Route("api/route")]
    public class RouterController : Controller
    {
        private static readonly object SyncLocker = new object();
        [Route("list"),HttpGet]
        public IActionResult List()
        {

            return Success(GlobalModel.Routers);
        }

        [Route("lock"), HttpPost]
        public IActionResult Lock(string id, string ip)
        {
            lock (SyncLocker)
            {
                var router = GlobalModel.Routers.Find(c => c.Id == id);
                if (!string.IsNullOrWhiteSpace(router.ClientIP))
                {
                    return Error($"已经被{router.ClientIP}使用");
                }
                router.ClientIP = id;
                router.Changed = true;
                router.UploadTime = DateTime.Now;
            }
            GlobalModel.SaveRouters();
            return Success("成功");
        }

        [Route("unlock"), HttpPost]
        public IActionResult Unlock(string id, string ip, bool force = false)
        {
            lock (SyncLocker)
            {
                var router = GlobalModel.Routers.Find(c => c.Id == id);
                if (string.IsNullOrWhiteSpace(router.ClientIP))
                {
                    return Error($"{id}已经被释放过了");
                }
                if (ip != router.ClientIP && !force)
                {
                    return Error($"当前操作IP并非锁定IP，请在操作平台上强制解锁");
                }
                router.ClientIP = string.Empty;
                router.Changed = true;
                router.UploadTime = DateTime.Now;
            }
            GlobalModel.SaveRouters();
            return Reconnect(id);
        }

        [Route("reconnect"),HttpPost]
        public IActionResult Reconnect(string id)
        {
            var router = GlobalModel.Routers.Find(c => c.Id == id);
            if (router == null)
                return Error("未找到匹配的路由器");
            var routerType = GlobalModel.RouterTypes.Find(c => c.Title == router.TypeTitle);
            if (routerType == null)
                return Error("未找到匹配的路由器类型，请在GlobalModel.RouterTypes添加");
            routerType.Reconnect(router);
            return Success("成功");
        }

        private IActionResult Success(object data)
        {
            return Json(new {code = 0, data});
        }

        private IActionResult Error(string msg)
        {
            return Json(new {code = 1, msg});
        }
    }
}