using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRpg.Src.Manager;

namespace TextRpg.Src
{
    internal class ItemManager
    {
        private static ItemManager instance = new ItemManager();
        private Dictionary<string, Item> mItems;

        private ItemManager()
        {
            mItems = new Dictionary<string, Item>();
        }

        public void ItemAdd(string key, Item item)
        {
            mItems.Add(key, item);
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
    }
}
