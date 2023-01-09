using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg.Src
{
    internal class Inventory
    {
        private List<Item> mItems;
        private int mInventorySize;

        public Inventory()
        {
            mItems = new List<Item>();
        }

        public void AddItem(Item item)
        {
            mItems.Add(item);
        }

        public List<Item> Items
        {
            get { return mItems; }
            set { mItems = value; }
        }

        public int InventorySize
        {
            get { return mInventorySize; }
            set { mInventorySize = value; }
        }
    }
}
