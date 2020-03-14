using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameShopWPF
{
    public class FrameShop
    {
        private List<Material> materials = new List<Material>();

        public List<Material> Materials { get { return materials; } set { materials = value; } }

        public void FrameShopFill()
        {
            string[] WordsArr = DataAccess.GetDataFromFile();

            for (int i = 0; i < WordsArr.Length; i = i + 11)
            {
                Materials.Add(new Material()
                {
                    Name = WordsArr[i + 2],
                    QuanInStock = Convert.ToInt32(WordsArr[i + 6]),
                    QuanPerUnit = Convert.ToInt32(WordsArr[i + 10])
                });
            }
        }
    }
}
