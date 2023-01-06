using System;
using System.Collections.Generic;
using System.Linq;
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

        public void ItemChange()
        {

        }

        public void LeftHandEquip(Item item)
        {
            if (mLeftHandEquipItem != null)
            {
                if (item.ItemType.Equals(ItemType.LEFTHAND))
                {
                    mInventory.AddItem(mLeftHandEquipItem.Name, mLeftHandEquipItem);
                    mLeftHandEquipItem = item;
                }
                else if (item.ItemType.Equals(ItemType.TWOHANDED))
                {
                    mLeftHandEquipItem = item;
                    mInventory.AddItem(mRightHandEquipItem.Name, mRightHandEquipItem);
                    mRightHandEquipItem = null;
                }
            }
        }

        public Dictionary<Status, int> Stat
        {
            get { return mStatus; }
            private set { mStatus = value; }
        }
        public string Name
        {
            get { return mName; }
            private set { mName = value; }
        }
        public Inventory PlayerInventory
        {
            get { return mInventory; }
            private set { mInventory = value; }
        }
        public Item LeftHandEquipItem
        {
            get { return mLeftHandEquipItem; }
            private set { mLeftHandEquipItem = value; }
        }
        public Item RightHandEquipItem
        {
            get { return mRightHandEquipItem; }
            private set { mRightHandEquipItem = value; }
        }
        public Item ArmorEquipItem
        {
            get { return mArmorEquipItem; }
            private set { mArmorEquipItem = value; }
        }
    }
}
