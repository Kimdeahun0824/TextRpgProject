using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRpg.Src.Manager;
using TextRpg.Src.Manager.InputKey;

namespace TextRpg.Src
{
    public class Game
    {
        public Game()
        {
            FileIoManager.Instance.ItemLoad();
            FileIoManager.Instance.EventLoad();
            FileIoManager.Instance.EnemyLoad();
            Player player = new Player();
            //string test = "test\nass";
            //Console.WriteLine(test);
            //Console.WriteLine(EventManager.Instance.EventFind("<위대한 모험가를 꿈꾸는>").Content);
            //EventManager.Instance.EventNameListAdd();

        }

    }
    
    

}
