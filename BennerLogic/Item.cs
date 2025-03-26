using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BennerLogic
{
    public class Item
    {
        public int Id { get; set; }
        public int FrontConnection { get; set; }
        public int BackConnection { get; set; }

        public Item()
        {

        }

        public Item(int id)
        {
            Id = id;
        }

        public Item(int id, int frontConnection, int backConnection)
        {
            Id = id;
            FrontConnection = frontConnection;
            BackConnection = backConnection;
        }
    }
}
