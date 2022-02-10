using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortener.Application.UrlShorteners.Commands.AppConfig
{
    public class Config
    {
        public string BASE_URL;
    }
    public class UrlShortenerConfig
    {
        public Config Config;
        public UrlShortenerConfig()
        {
            Config = Newtonsoft.Json.JsonConvert.DeserializeObject<Config>(File.ReadAllText("AppConfig/Config.json"));
        }
    }
}
