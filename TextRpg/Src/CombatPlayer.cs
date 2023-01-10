using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg.Src
{
    internal class CombatPlayer
    {
        private string mName;
        private int mHp;
        private int mCombatPower;

        public CombatPlayer(string Name, int CombatPower)
        {
            this.mName = Name;
            this.mHp = 5;
            this.mCombatPower = CombatPower;
        }

        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }
        public int HP
        {
            get { return mHp; }
            set { mHp = value; }
        }
        public int CombatPower
        {
            get { return mCombatPower; }
            set { mCombatPower = value; }
        }
    }
}
