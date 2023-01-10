using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg.Src
{
    internal class Enemy
    {
        private string mName;
        private int mCombatPower;
        private int mHp;
        private int mCount;

        public Enemy()
        {
            mName = string.Empty;
            CombatPower = 0;
            mCount = 0;
            mHp = 5;
        }

        public bool EnemyCreate(Object value)
        {
            switch (mCount)
            {
                case 0:
                    mName = (string)value;
                    mName = string.Format(mName.Replace("\r\n", ""));
                    mCount++;
                    break;
                case 1:
                    mCombatPower = int.Parse((string)value);
                    mCount++;
                    break;
                default:
                    break;
            }
            if (1 < mCount)
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
            private set { mName = value; }
        }
        public int CombatPower
        {
            get { return mCombatPower; }
            private set { mCombatPower = value; }
        }
        public int HP
        {
            get { return mHp; }
            set { mHp = value; }
        }

    }
}
