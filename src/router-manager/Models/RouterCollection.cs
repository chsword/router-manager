using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace RouterManager.Models
{
    public class RouterCollection : List<Router>
    {
        public string ConfigPath => System.IO.Path.Combine(GlobalModel.RoutePath, "Config");

        public void Load()
        {
            var files = System.IO.Directory.GetFiles(ConfigPath);
            this.Clear();
            foreach (var file in files)
            {
                var json = File.ReadAllText(file);
                if (string.IsNullOrWhiteSpace(json)) continue;
                var filename = Path.GetFileNameWithoutExtension(file);
                var old = this.FirstOrDefault(c => c.Id == filename);
                this.Remove(old);
                var router = JsonConvert.DeserializeObject<Router>(json);
                router.Id = filename;
                router.UploadTime = File.GetLastWriteTime(file);
                this.Add(router);
            }

        }
    }
}