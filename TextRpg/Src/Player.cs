using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg.Src
{
    internal class Player
    {
        private string mName;
        private Dictionary<Status, int> mStatus;

        private Inventory mInventory;
        private Item mLeftHandEquipItem;
        private Item mRightHandEquipItem;
        private Item mArmorEquipItem;

        private int mCombatPower;

        private int mCount;
        private string mCurrentEventName;

        private bool mIs_First;

        public Player()
        {
            mName = "test";

            mStatus = new Dictionary<Status, int>();

            mStatus.Add(Status.LEVEL, 1);
            mStatus.Add(Status.EXP, 1);
            mStatus.Add(Status.HP, 1);
            mStatus.Add(Status.MP, 1);
            mStatus.Add(Status.STRENGTH, 1);
            mStatus.Add(Status.AGILITY, 1);
            mStatus.Add(Status.INTELLIGENCE, 1);
            mStatus.Add(Status.CHARISMA, 1);
            mStatus.Add(Status.HEALTH, 1);
            mStatus.Add(Status.WISDOM, 1);

            mInventory = new Inventory();

            mLeftHandEquipItem = null;
            mRightHandEquipItem = null;
            mArmorEquipItem = null;

            mCurrentEventName = "<위대한 모험가를 꿈꾸는>";

            mCount = 0;
        }

        public Player(Player player)
        {
            mName = player.Name;
            mStatus = player.Stat;
            mInventory = player.PlayerInventory;
            mLeftHandEquipItem = player.LeftHandEquipItem;
            mRightHandEquipItem = player.RightHandEquipItem;
            mArmorEquipItem = player.RightHandEquipItem;
            mCurrentEventName = player.CurrentEventName;
        }

        public void DataLoad(string value)
        {
            switch (mCount)
            {
                case 0:
                    mName = value;
                    mCount++;
                    break;
                case 1:
                    mStatus[Status.LEVEL] = int.Parse(value);
                    mCount++;
                    break;
                case 2:
                    mStatus[Status.EXP] = int.Parse(value);
                    mCount++;
                    break;
                case 3:
                    mStatus[Status.HP] = int.Parse(value);
                    mCount++;
                    break;
                case 4:
                    mStatus[Status.MP] = int.Parse(value);
                    mCount++;
                    break;
                case 5:
                    mStatus[Status.STRENGTH] = int.Parse(value);
                    mCount++;
                    break;
                case 6:
                    mStatus[Status.AGILITY] = int.Parse(value);
                    mCount++;
                    break;
                case 7:
                    mStatus[Status.INTELLIGENCE] = int.Parse(value);
                    mCount++;
                    break;
                case 8:
                    mStatus[Status.CHARISMA] = int.Parse(value);
                    mCount++;
                    break;
                case 9:
                    mStatus[Status.HEALTH] = int.Parse(value);
                    mCount++;
                    break;
                case 10:
                    mStatus[Status.WISDOM] = int.Parse(value);
                    mCount++;
                    break;
                default:
                    mInventory.AddItem(ItemManager.Instance.ItemFind(value));
                    break;
            }
        }

        public void AddStatus(Status target, int value)
        {
            if (mStatus.ContainsKey(target))
            {
                mStatus[target] += value;
            }
        }
        public void RemoveStatus(Status target, int value)
        {
            if (mStatus.ContainsKey(target))
            {
                mStatus[target] -= value;
            }
        }
        public int GetStatus(Status key)
        {
            return mStatus[key];
        }

        public void ItemChange()
        {

        }

        public void LeftHandEquip(Item item)
        {
            if (mLeftHandEquipItem != null)
            {
                if (item.ItemType.Equals(ItemType.LEFTHAND))
                {
                    mInventory.AddItem(mLeftHandEquipItem);
                    mLeftHandEquipItem = item;
                }
                else if (item.ItemType.Equals(ItemType.TWOHANDED))
                {
                    mLeftHandEquipItem = item;
                    mInventory.AddItem(mRightHandEquipItem);
                    mRightHandEquipItem = null;
                }
            }
        }

        public Dictionary<Status, int> Stat
        {
            get { return mStatus; }
            set { mStatus = value; }
        }
        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }
        public Inventory PlayerInventory
        {
            get { return mInventory; }
            set { mInventory = value; }
        }
        public Item LeftHandEquipItem
        {
            get { return mLeftHandEquipItem; }
            set { mLeftHandEquipItem = value; }
        }
        public Item RightHandEquipItem
        {
            get { return mRightHandEquipItem; }
            set { mRightHandEquipItem = value; }
        }
        public Item ArmorEquipItem
        {
            get { return mArmorEquipItem; }
            set { mArmorEquipItem = value; }
        }
        public string CurrentEventName
        {
            get { return mCurrentEventName; }
            set { mCurrentEventName = value; }
        }
    }
}
