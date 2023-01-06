using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg.Src
{
    internal class Item
    {
        private string mName;

        private ItemType mItemType;

        private Status mTargetStatus_1;
        private Status mTargetStatus_2;

        private int mBaseCombatPower;
        private int mCombatPower;

        private int mCount;

        public Item()
        {
            mName = string.Empty;
            mItemType = ItemType.NONE;
            mTargetStatus_1 = Status.NONE;
            mTargetStatus_2 = Status.NONE;
            mBaseCombatPower = 0;
            mCombatPower = 0;
            mCount = 0;
        }

        public Item(string Name, ItemType itemType, Status TargetStatus_1, Status TargetStatus_2, int BaseCombatPower)
        {
            mName = Name;
            mItemType = itemType;
            mTargetStatus_1 = TargetStatus_1;
            mTargetStatus_2 = TargetStatus_2;
            mBaseCombatPower = BaseCombatPower;
            mCount = 0;
        }

        public bool ItemCreate(string value)
        {
            return ItemCreateSelect(value);
        }

        public bool ItemCreateSelect(string value)
        {
            switch (mCount)
            {
                case 0:
                    mName = value;
                    mCount++;
                    break;
                case 1:
                    ItemTypeSelect(value);
                    mCount++;
                    break;
                case 2:
                    StatusTypeSelecet(mTargetStatus_1, value);
                    mCount++;
                    break;
                case 3:
                    StatusTypeSelecet(mTargetStatus_2, value);
                    mCount++;
                    break;
                case 4:
                    mBaseCombatPower = Convert.ToInt32(value);
                    mCount++;
                    break;
                default:
                    break;
            }
            if (4 < mCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ItemTypeSelect(string value)
        {
            switch (ItemTypeParse(value))
            {
                case ItemType.NONE:
                    mItemType = ItemType.NONE;
                    break;
                case ItemType.LEFTHAND:
                    mItemType = ItemType.LEFTHAND;
                    break;
                case ItemType.RIGHTHAND:
                    mItemType = ItemType.RIGHTHAND;
                    break;
                case ItemType.TWOHANDED:
                    mItemType = ItemType.TWOHANDED;
                    break;
                case ItemType.ARMOR:
                    mItemType = ItemType.ARMOR;
                    break;
                default:
                    break;
            }
        }
        public void StatusTypeSelecet(Status target, string value)
        {
            switch (StatusParse(value))
            {
                case Status.STRENGTH:
                    target = Status.STRENGTH;
                    break;
                case Status.AGILITY:
                    target = Status.AGILITY;
                    break;
                case Status.INTELLIGENCE:
                    target = Status.INTELLIGENCE;
                    break;
                case Status.CHARISMA:
                    target = Status.CHARISMA;
                    break;
                case Status.HEALTH:
                    target = Status.HEALTH;
                    break;
                case Status.WISDOM:
                    target = Status.WISDOM;
                    break;
                default:
                    target = Status.NONE;
                    break;
            }
        }

        public ItemType ItemTypeParse(string value)
        {
            ItemType result;
            Enum.TryParse(value, out result);
            return result;
        }
        public Status StatusParse(string value)
        {
            Status result;
            Enum.TryParse(value, out result);
            return result;
        }


        public ItemType ItemType
        {
            get { return mItemType; }
            private set { mItemType = value; }
        }

        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }
        public Status TargetStatus_1
        {
            get { return mTargetStatus_1; }
            private set { mTargetStatus_1 = value; }
        }
        public Status TargetStatus_2
        {
            get { return mTargetStatus_2; }
            private set { mTargetStatus_2 = value; }
        }
        public int BaseCombatPower
        {
            get { return mBaseCombatPower; }
            private set { mBaseCombatPower = value; }
        }
        public int CombatPower
        {
            get { return mCombatPower; }
            set { mCombatPower = value; }
        }
    }
}