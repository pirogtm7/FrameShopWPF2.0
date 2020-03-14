using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace FrameShopWPF
{
    public class DataAccess
    {
        public static string pathXML = ConfigurationManager.AppSettings.Get("Path");
        public static string pathDataAccess = ConfigurationManager.AppSettings.Get("DataAccessPath");

        public static string[] GetDataFromFile()
        {
            string text = File.ReadAllText(pathDataAccess);
            string[] WordsArr = text.Split(' ', '\n');
            return WordsArr;
        }
    }
}
