using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg.Src
{
    internal class EnemyManager : ISingelton<EnemyManager>
    {
        private static EnemyManager instance = new EnemyManager();
        private Dictionary<string, Enemy> mEnemys;

        private EnemyManager()
        {
            mEnemys = new Dictionary<string, Enemy>();
        }

        public EnemyManager getInstance()
        {
            if (instance == null)
            {
                instance = new EnemyManager();
                return instance;
            }
            else
            {
                return instance;
            }
        }
    }
}
