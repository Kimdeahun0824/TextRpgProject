using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg.Src
{
    internal class Event
    {
        private string mName;
        private string mContent;

        private List<string> mOptional;

        private bool mIs_Next_Content;
        private List<string> mNextContentKey;

        private Item mRewardItem;
        private int mRewardGold;
        private int mRewardExp;

        private int mDelay;

        public Event()
        {

        }

        public string Name
        {
            get { return mName; }
            private set { mName = value; }
        }
        public string Content
        {
            get { return mContent; }
            private set { mContent = value; }
        }
        public List<string> Optional
        {
            get { return mOptional; }
            private set { mOptional = value; }
        }
        public bool Is_Next_Content
        {
            get { return mIs_Next_Content; }
            private set { mIs_Next_Content = value; }
        }
        public List<string> NextContentKey
        {
            get { return mNextContentKey; }
            private set { mNextContentKey = value; }
        }
        public Item RewardItem
        {
            get { return mRewardItem; }
            private set { mRewardItem = value; }
        }
        public int RewardGold
        {
            get { return mRewardGold; }
            private set { mRewardGold = value; }
        }
        public int RewardExp
        {
            get { return mRewardExp; }
            private set { mRewardExp = value; }
        }
        public int Delay
        {
            get { return mDelay; }
            private set { mDelay = value; }
        }

    }
}
