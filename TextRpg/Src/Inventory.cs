using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg.Src
{
    internal class Inventory
    {
        private Dictionary<string, Item> mItems;
        private int mInventorySize;

        public void AddItem(string key, Item item)
        {
            mItems.Add(key, item);
        }
    }
}
