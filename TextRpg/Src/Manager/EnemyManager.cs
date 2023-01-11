using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg.Src
{
    internal class EnemyManager
    {
        private static EnemyManager instance = new EnemyManager();
        private Dictionary<string, Enemy> mEnemys;

        private EnemyManager()
        {
            mEnemys = new Dictionary<string, Enemy>();
        }

        public void EnemyAdd(string key, Enemy enemy)
        {
            mEnemys.Add(key, enemy);
        }
        
        public Enemy EnemyFind(string key)
        {
            if (mEnemys.ContainsKey(key))
            {
                return mEnemys[key];
            }
            else
            {
                return null;
            }
        }


        public static EnemyManager Instance
        {
            get
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
}
