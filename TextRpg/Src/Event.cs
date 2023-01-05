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




    }
}
