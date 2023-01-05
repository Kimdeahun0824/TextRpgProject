using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg.Src
{
    internal class ItemManager : ISingelton<ItemManager>
    {
        private static ItemManager instance = new ItemManager();
        private Dictionary<string, Item> mItems;

        private ItemManager()
        {
            mItems = new Dictionary<string, Item>();
        }

        public ItemManager getInstance()
        {
            if (instance == null)
            {
                instance = new ItemManager();
                return instance;
            }
            else
            {
                return instance;
            }
        }
    }
}
