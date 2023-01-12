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
        private bool mPlayerTurn;
        private bool mEnemyTurn;

        public Combat()
        {
            random = new Random();
            mPlayerTurn = true;
            mEnemyTurn = false;
        }

        public void SetPlayer(CombatPlayer player)
        {
            mPlayer = player;
        }

        public void SetEnemy(Enemy enemy)
        {
            mEnemy = enemy;
        }

        public bool CombatStart()
        {
            while (true)
            {
                if (mEnemy.HP <= 0)
                {
                    return true;
                }
                else if (mPlayer.HP <= 0)
                {
                    return false;
                }
                Console.Clear();
                Console.WriteLine("=========================================================");
                Console.WriteLine("{0}의 전투력 : {1}        ||       {2}의 전투력 : {3}", mPlayer.Name, mPlayer.CombatPower, mEnemy.Name, mEnemy.CombatPower);
                Console.WriteLine("=========================================================");

                Action();

                Console.WriteLine("{0}남은 체력 : {1}     {2}남은 체력 : {3}", mPlayer.Name, mPlayer.HP, mEnemy.Name, mEnemy.HP);
                Thread.Sleep(1000);
            }
        }

        public void Action()
        {
            Attack();
            if (mPlayerTurn && !mEnemyTurn)
            {
                mPlayerTurn = false;
                mEnemyTurn = true;
            }
            else if (!mPlayerTurn && mEnemyTurn)
            {
                mPlayerTurn = true;
                mEnemyTurn = false;
            }
        }

        public void Attack()
        {
            int randNum = 0;
            float probality = 0;
            if (mPlayer.CombatPower < mEnemy.CombatPower)
            {
                probality = (mEnemy.CombatPower - mPlayer.CombatPower) * 0.01f;
            }
            else
            {
                probality = (mPlayer.CombatPower - mEnemy.CombatPower) * 0.01f;
            }
            if(0.8f <= probality)
            {
                probality = 0.8f;
            }
            randNum = random.Next(1, 101);
            if (mPlayerTurn && !mEnemyTurn)      // 플레이어 턴
            {
                Console.WriteLine("{0}의 공격!", mPlayer.Name);
                Thread.Sleep(1000);
                if (mPlayer.CombatPower < mEnemy.CombatPower)
                {
                    if (0 < randNum && randNum <= 50 - 50 * probality)
                    {
                        Hit();
                    }
                    else if (50 - 50 * probality < randNum && randNum <= 100)
                    {
                        Dodge();
                    }
                }
                else if (mPlayer.CombatPower == mEnemy.CombatPower)
                {
                    if (0 < randNum && randNum <= 50)
                    {
                        Hit();
                    }
                    else if (50 < randNum && randNum <= 100)
                    {
                        Dodge();
                    }
                }
                else
                {
                    if (0 < randNum && randNum <= 50 + 50 * probality)
                    {
                        Hit();
                    }
                    else if (50 + 50 * probality < randNum && randNum <= 100)
                    {
                        Dodge();
                    }
                }
            }
            else if (!mPlayerTurn && mEnemyTurn) // 적 턴
            {
                Console.WriteLine("{0}의 공격!", mEnemy.Name);
                Thread.Sleep(1000);
                if (mPlayer.CombatPower < mEnemy.CombatPower)
                {
                    if (0 < randNum && randNum <= 50 + 50 * probality)
                    {
                        Hit();
                    }
                    else if (50 + 50 * probality < randNum && randNum <= 100)
                    {
                        Dodge();
                    }
                }
                else if (mPlayer.CombatPower == mEnemy.CombatPower)
                {
                    if (0 < randNum && randNum <= 50)
                    {
                        Hit();
                    }
                    else if (50 < randNum && randNum <= 100)
                    {
                        Dodge();
                    }
                }
                else if (mPlayer.CombatPower > mEnemy.CombatPower)
                {
                    if (0 < randNum && randNum <= 50 - 50 * probality)
                    {
                        Hit();
                    }
                    else if (50 - 50 * probality < randNum && randNum <= 100)
                    {
                        Dodge();
                    }
                }
            }
            
        }

        public void Dodge()
        {
            if (mPlayerTurn && !mEnemyTurn)      // 플레이어 턴 상대의 행동
            {
                Console.WriteLine("{0}의 회피!", mEnemy.Name);
            }
            else if (!mPlayerTurn && mEnemyTurn) // 적 턴 상대의 행동
            {
                Console.WriteLine("{0}의 회피!", mPlayer.Name);
            }
        }

        public void Hit()
        {
            if (mPlayerTurn && !mEnemyTurn)      // 플레이어 턴 상대의 행동
            {
                Console.WriteLine("{0}의 체력 감소!", mEnemy.Name);
                mEnemy.HP -= 1;
            }
            else if (!mPlayerTurn && mEnemyTurn) // 적 턴 상대의 행동
            {
                Console.WriteLine("{0}의 체력감소!", mPlayer.Name);
                mPlayer.HP -= 1;
            }
        }


    }
}
