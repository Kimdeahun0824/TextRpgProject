using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg.Src
{
    internal class ItemManager
    {
        private static ItemManager instance = new ItemManager();
        public Dictionary<string, Item> mItems;
        private Item mSelectItem;

        private ItemManager()
        {
            mItems = new Dictionary<string, Item>();
        }

        public void ItemAdd(string key, Item item)
        {
            if (mItems.ContainsKey(key))
            {
                return;
            }
            else
            {
                mItems.Add(key, item);
            }

        }

        public Item ItemFind(string key)
        {
            if (mItems.ContainsKey(key))
            {
                return mItems[key];
            }
            else
            {
                return null;
            }
        }

        public void ItemSelect(Item item)
        {
            mSelectItem = item;
        }

        public static ItemManager Instance
        {
            get
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
        public Item SelectItem
        {
            get { return mSelectItem; }
            private set { mSelectItem = value; }
        }
    }
}
