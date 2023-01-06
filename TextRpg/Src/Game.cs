using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRpg.Src.Manager;
using TextRpg.Src.Manager.InputKey;

namespace TextRpg.Src
{
    internal class Game
    {
        public Game()
        {
            FileIoManager.Instance.ItemLoad();
            FileIoManager.Instance.EventLoad();
            FileIoManager.Instance.EnemyLoad();
            Player player = new Player();

            //FileIoManager.Instance.PlayerDataSave(player);

            //if (InputKeyManager.Instance.userInput().Equals(InputKey_F1.Instance))
            //{
            //    Console.WriteLine("TEST");
            //}
            //Enemy enemy = EnemyManager.Instance.EnemyFind("리자드");
            //Console.WriteLine("{0}{1}",enemy.Name,enemy.CombatPower);

            //Item item = ItemManager.Instance.ItemFind("TESTITEM2");
            //Console.WriteLine("{0}{1}", item.Name, item.BaseCombatPower);

            //Event _event = EventManager.Instance.EventFind("TESTEVENT2");
            //Enemy enemy2 = EnemyManager.Instance.EnemyFind(_event.EnemyKey);
            //Console.WriteLine("{0} {1}", enemy2.Name,enemy2.CombatPower);

            ////Console.WriteLine(ItemManager.Instance.ItemFind("TESTITEM").Name);
            ////Console.WriteLine(ItemManager.Instance.ItemFind("TESTITEM2").Name);
            ////Console.WriteLine(EventManager.Instance.EventFind("TESTEVENT").Optional[0]);
            ////string itemkey = EventManager.Instance.EventFind("TESTEVENT2").RewardItemKey[0];
            ////Console.WriteLine(ItemManager.Instance.ItemFind(itemkey).Name);

            InputKeyManager.Instance.userInput().Action();
        }
    }
}
