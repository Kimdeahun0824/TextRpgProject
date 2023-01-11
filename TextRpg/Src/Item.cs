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

        private float mMultiplyValue;
        private int mCombatPower;

        private int mCount;

        public Item()
        {
            mName = string.Empty;
            mItemType = ItemType.NONE;
            mTargetStatus_1 = Status.NONE;
            mTargetStatus_2 = Status.NONE;
            mMultiplyValue = 0;
            mCombatPower = 0;
            mCount = 0;
        }

        public Item(string Name, ItemType itemType, Status TargetStatus_1, Status TargetStatus_2, int BaseCombatPower)
        {
            mName = Name;
            mItemType = itemType;
            mTargetStatus_1 = TargetStatus_1;
            mTargetStatus_2 = TargetStatus_2;
            mMultiplyValue = BaseCombatPower;
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
                    mName = string.Format(mName.Replace("\r\n", ""));
                    mCount++;
                    break;
                case 1:
                    mItemType = ItemTypeParse(value);
                    mCount++;
                    break;
                case 2:
                    mTargetStatus_1 = StatusParse(value);
                    mCount++;
                    break;
                case 3:
                    mTargetStatus_2 = StatusParse(value);
                    mCount++;
                    break;
                case 4:
                    mMultiplyValue = float.Parse(value);
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
        public float MultiPlyValue
        {
            get { return mMultiplyValue; }
            private set { mMultiplyValue = value; }
        }
        public int CombatPower
        {
            get { return mCombatPower; }
            set { mCombatPower = value; }
        }
    }
}