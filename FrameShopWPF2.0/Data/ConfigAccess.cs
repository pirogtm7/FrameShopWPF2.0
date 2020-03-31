using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace FrameShopWPF
{
    public class ConfigAccess
    {
        public static string pathXML = ConfigurationManager.AppSettings.Get("Path");
        public static string enoughString = ConfigurationManager.AppSettings.Get("Enough");
        public static string notEnoughString = ConfigurationManager.AppSettings.Get("NotEnough");
        public static string youNeedString = ConfigurationManager.AppSettings.Get("YouNeed");
        public static string youHaveString = ConfigurationManager.AppSettings.Get("YouHave");
        public static string ConnectionString = ConfigurationManager.AppSettings.Get("ConnectionString");
    }
}
