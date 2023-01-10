using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg.Src
{
    internal class Event
    {
        private string mName;
        private string mContent;

        private List<string> mOptional;
        private List<string> mNextContentKey;

        private List<string> mRewardItemKey;
        private int mRewardGold;
        private int mRewardExp;

        private int mDelay;

        private bool mCombat;
        private string mEnemyKey;

        private int mCount;
        private bool mEventEnd;

        private string mRewardStat;
        private int mRewardStatValue;
        public Event()
        {
            mName = string.Empty;
            mContent = string.Empty;
            mOptional = new List<string>();
            mNextContentKey = new List<string>();
            mRewardItemKey = new List<string>();
            mRewardGold = 0;
            mRewardExp = 0;
            mDelay = 0;
            mCombat = false;
            mEnemyKey = string.Empty;
            mCount = 0;
            mEventEnd = false;
            mRewardStat = string.Empty;
            mRewardStatValue = 0;
        }

        public bool EventCreate(Object value)
        {
            return EventCreateSelect(value);
        }

        public bool EventCreateSelect(Object value)
        {
            switch (mCount)
            {
                case 0:
                    mName = (string)value;
                    mName = string.Format(mName.Replace("\r\n", ""));
                    mCount++;
                    break;
                case 1:
                    mContent = (string)value;
                    mCount++;
                    break;
                case 2:
                    foreach (var i in (List<string>)value)
                    {
                        mOptional.Add(i);
                    }
                    mCount++;
                    break;
                case 3:
                    foreach (var i in (List<string>)value)
                    {
                        if (i.Equals("RANDOM"))
                        {
                            mEventEnd = true;
                        }
                        mNextContentKey.Add(i);
                    }
                    mCount++;
                    break;
                case 4:
                    foreach (var i in (List<string>)value)
                    {
                        mRewardItemKey.Add(i);
                    }
                    mCount++;
                    break;
                case 5:
                    mRewardGold = int.Parse((string)value);
                    mCount++;
                    break;
                case 6:
                    mRewardExp = int.Parse((string)value);
                    mCount++;
                    break;
                case 7:
                    mDelay = int.Parse((string)value);
                    mCount++;
                    break;
                case 8:
                    if ((string)value == "TRUE")
                    {
                        mCombat = true;
                    }
                    else
                    {
                        mCombat = false;
                    }
                    mCount++;
                    break;
                case 9:
                    mEnemyKey = (string)value;
                    mCount++;
                    break;
                case 10:
                    mRewardStat = (string)value;
                    mCount++;
                    break;
                case 11:
                    mRewardStatValue = int.Parse((string)value);
                    mCount++;
                    break;
                default:
                    break;
            }
            if (11 < mCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }
        public string Content
        {
            get { return mContent; }
            set { mContent = value; }
        }
        public List<string> Optional
        {
            get { return mOptional; }
            set { mOptional = value; }
        }
        public List<string> NextContentKey
        {
            get { return mNextContentKey; }
            set { mNextContentKey = value; }
        }
        public List<string> RewardItemKey
        {
            get { return mRewardItemKey; }
            set { mRewardItemKey = value; }
        }
        public int RewardGold
        {
            get { return mRewardGold; }
            set { mRewardGold = value; }
        }
        public int RewardExp
        {
            get { return mRewardExp; }
            set { mRewardExp = value; }
        }
        public int Delay
        {
            get { return mDelay; }
            set { mDelay = value; }
        }
        public bool Combat
        {
            get { return mCombat; }
            set { mCombat = value; }
        }
        public string EnemyKey
        {
            get { return mEnemyKey; }
            set { mEnemyKey = value; }
        }
        public bool EventEnd
        {
            get { return mEventEnd; }
            set { mEventEnd = value; }
        }
        public string RewardStat
        {
            get { return mRewardStat; }
            set { mRewardStat = value; }
        }
        public int RewardStatValue
        {
            get { return mRewardStatValue; }
            set { mRewardStatValue = value; }
        }

    }
}
