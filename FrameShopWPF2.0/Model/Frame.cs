using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameShopWPF
{
    public class Frame 
    {
        private List<Material> materials = new List<Material>();
        private int width, length, quantity;

        public List<Material> Materials { get { return materials; } set { materials = value; } }
        public int Width { get { return width; } set { width = value; } }
        public int Length { get { return length; } set { length = value; } }
        public int Quantity { get { return quantity; } set { quantity = value; } }

        public int FinalAmount(Material material)
        {
            int finalAmount = material.QuanPerUnit * Width * Length * Quantity;

            return finalAmount;
        }

        public void Save()
        {
            Serializer.XMLSerializator serialization =
                new Serializer.XMLSerializator(typeof(Frame));

            serialization.Serialization(this, DataAccess.pathXML);
        }
    }
}
