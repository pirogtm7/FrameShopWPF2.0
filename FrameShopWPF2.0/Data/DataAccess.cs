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

        public static void GetDataFromFile<T, V>(FrameShop myfm)
        {
            string text = File.ReadAllText(pathDataAccess);
            string[] wordsArr = text.Split(' ', '\n');

            for (int i = 0; i < wordsArr.Length; i = i + 11)
            {
                myfm.Materials.Add(new Material()
                {
                    Name = wordsArr[i + 2],
                    QuanInStock = Convert.ToInt32(wordsArr[i + 6]),
                    QuanPerUnit = Convert.ToInt32(wordsArr[i + 10])
                });
            }
        }
    }
}
