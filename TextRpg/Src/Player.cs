using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
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

        private float mCombatPower;

        private int mCount;
        private string mCurrentEventName;
        private int mGold;

        private bool mIs_First;

        private int mStatPoint;

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
            mStatus.Add(Status.NONE, 0);

            mInventory = new Inventory();

            mLeftHandEquipItem = null;
            mRightHandEquipItem = null;
            mArmorEquipItem = null;

            mCurrentEventName = "<위대한 모험가를 꿈꾸는>";

            mCount = 0;
            mGold = 0;
            mStatPoint = 0;
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
            mGold = player.Gold;
            mStatPoint = player.StatPoint;
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
                case 11:
                    mGold = int.Parse(value);
                    mCount++;
                    break;
                default:
                    mInventory.AddItem(ItemManager.Instance.ItemFind(value));
                    break;
            }
        }
        public void AddGold(int gold)
        {
            mGold += gold;
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

        public void ItemChange(Item item)
        {
            switch (item.ItemType)
            {
                case ItemType.NONE:
                    break;
                case ItemType.LEFTHAND:
                    LeftHandEquip(item);
                    break;
                case ItemType.RIGHTHAND:
                    RightHandEquip(item);
                    break;
                case ItemType.TWOHANDED:
                    LeftHandEquip(item);
                    break;
                case ItemType.ARMOR:
                    ArmorEquip(item);
                    break;
                default:
                    break;
            }
        }

        public void LeftHandEquip(Item item)
        {
            if (mLeftHandEquipItem != null)
            {
                mInventory.AddItem(mLeftHandEquipItem);
                mLeftHandEquipItem = item;
            }
            else
            {
                mLeftHandEquipItem = item;
            }
            mInventory.RemoveItem(item);
        }

        public void RightHandEquip(Item item)
        {
            if (mRightHandEquipItem != null)
            {
                mInventory.AddItem(mRightHandEquipItem);
                mRightHandEquipItem = item;
            }
            else
            {
                mRightHandEquipItem = item;
            }
            mInventory.RemoveItem(item);
        }

        public void ArmorEquip(Item item)
        {
            if (mArmorEquipItem != null)
            {
                mInventory.AddItem(mArmorEquipItem);
                mArmorEquipItem = item;
            }
            else
            {
                mArmorEquipItem = item;
            }
            mInventory.RemoveItem(item);
        }

        public void TwoHandedEquip(Item item)
        {
            if (mLeftHandEquipItem != null && mRightHandEquipItem != null)
            {
                mInventory.AddItem(mLeftHandEquipItem);
                mInventory.AddItem(mRightHandEquipItem);
                mLeftHandEquipItem = item;
                mRightHandEquipItem = null;
            }
            else if (mLeftHandEquipItem != null)
            {
                mInventory.AddItem(mLeftHandEquipItem);
                mLeftHandEquipItem = item;
            }
            else if (mRightHandEquipItem != null)
            {
                mInventory.AddItem(mRightHandEquipItem);
                mLeftHandEquipItem = item;
                mRightHandEquipItem = null;
            }
            else
            {
                mLeftHandEquipItem = item;
            }
            mInventory.RemoveItem(item);
        }

        public void CombatPowerUpdate()
        {
            mCombatPower = 0;
            if (mLeftHandEquipItem != null)
            {
                if (mLeftHandEquipItem.TargetStatus_2 != Status.NONE)
                {
                    mCombatPower += GetStatus(mLeftHandEquipItem.TargetStatus_1) * mLeftHandEquipItem.MultiPlyValue
                        + GetStatus(mLeftHandEquipItem.TargetStatus_2) * mLeftHandEquipItem.MultiPlyValue;
                }
                else
                {
                    mCombatPower += GetStatus(mLeftHandEquipItem.TargetStatus_1) * mLeftHandEquipItem.MultiPlyValue;
                }
            }
            if (mRightHandEquipItem != null)
            {
                if (mRightHandEquipItem.TargetStatus_2 != Status.NONE)
                {
                    mCombatPower += GetStatus(mRightHandEquipItem.TargetStatus_1) * mRightHandEquipItem.MultiPlyValue
                        + GetStatus(mRightHandEquipItem.TargetStatus_2) * mRightHandEquipItem.MultiPlyValue;
                }
                else
                {
                    mCombatPower += GetStatus(mRightHandEquipItem.TargetStatus_1) * mRightHandEquipItem.MultiPlyValue;
                }
            }
            if (mArmorEquipItem != null)
            {
                if (mArmorEquipItem.TargetStatus_2 != Status.NONE)
                {
                    mCombatPower += GetStatus(mArmorEquipItem.TargetStatus_1) * mArmorEquipItem.MultiPlyValue
                        + GetStatus(mArmorEquipItem.TargetStatus_2) * mArmorEquipItem.MultiPlyValue;
                }
                else
                {
                    mCombatPower += GetStatus(mArmorEquipItem.TargetStatus_1) * mArmorEquipItem.MultiPlyValue;
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
        public float CombatPower
        {
            get { return mCombatPower; }
            set { mCombatPower = value; }
        }
        public int Gold
        {
            get { return mGold; }
            set { mGold = value; }
        }
        public int StatPoint
        {
            get { return mStatPoint; }
            set { mStatPoint = value; }
        }
    }
}
