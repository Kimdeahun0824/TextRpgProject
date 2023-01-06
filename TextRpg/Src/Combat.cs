using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg.Src
{
    internal class Combat
    {
        private CombatPlayer mPlayer;
        private Enemy mEnemy;
        private Random random;

        public Combat()
        {
            random = new Random();
        }

        public void SetPlayer(CombatPlayer player)
        {
            mPlayer = player;
        }

        public void SetEnemy(Enemy enemy)
        {
            mEnemy = enemy;
        }


        public void Action()
        {

        }

        public void Attack()
        {

        }

        public void Defense()
        {

        }

        public void Dodge()
        {

        }


    }
}
