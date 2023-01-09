using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace TextRpg.Src
{
    internal class FileIoManager
    {
        private static FileIoManager instance = new FileIoManager();
        private Player playerData;

        public void jsonWriteTest()
        {
            string filePath = @"";
        }

        public void jsonReadTest()
        {

        }

        private FileIoManager()
        {

        }
        public bool PlayerDataCheck()
        {
            FileInfo fi = new FileInfo("Save.csv");
            return fi.Exists;
        }
        public void PlayerDataSave(Player player)
        {
            FileStream fs = File.Create("Save.csv");
            StreamWriter sw = new StreamWriter(fs);
            sw.Write("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}"
                , player.Name
                , player.Stat[Status.LEVEL]
                , player.Stat[Status.EXP]
                , player.Stat[Status.HP]
                , player.Stat[Status.MP]
                , player.Stat[Status.STRENGTH]
                , player.Stat[Status.AGILITY]
                , player.Stat[Status.INTELLIGENCE]
                , player.Stat[Status.CHARISMA]
                , player.Stat[Status.HEALTH]
                , player.Stat[Status.WISDOM]
                , player.CurrentEventName);
            if (0 < player.PlayerInventory.Items.Count)
            {
                foreach (var i in player.PlayerInventory.Items)
                {
                    sw.WriteLine(",{0}", i.Name);
                }
            }
            sw.Close();
            fs.Close();
        }

        public Player PlayerDataLoad()
        {
            FileStream fs = File.OpenRead("Save.csv");
            StreamReader sr = new StreamReader(fs);
            string s;
            string[] sArray = null;
            while (!sr.EndOfStream)
            {
                s = sr.ReadLine();
                sArray = s.Split(',');
            }
            sr.Close();
            fs.Close();

            Player player = new Player();
            foreach (var i in sArray)
            {
                player.DataLoad(i);
            }
            return player;
        }

        public void ItemLoad()
        {
            FileStream fs = File.OpenRead("Items.csv");
            StreamReader sr = new StreamReader(fs);
            string s;
            string[] sArray = null;
            while (!sr.EndOfStream)
            {
                s = sr.ReadLine();
                sArray = s.Split(',');
            }
            sr.Close();
            fs.Close();
            Item item = new Item();
            bool fileEnd = false;
            foreach (var i in sArray)
            {
                if (!fileEnd)
                {
                    if (i == "")
                    {
                        continue;
                    }
                    fileEnd = item.ItemCreate(i);
                    if (fileEnd)
                    {
                        ItemManager.Instance.ItemAdd(item.Name, item);
                        item = null;
                        item = new Item();
                        fileEnd = false;
                    }
                }
            }
        }

        public void EventLoad()
        {
            FileStream fs = File.OpenRead("Events.csv");
            StreamReader sr = new StreamReader(fs);
            string s;
            string[] sArray = null;
            while (!sr.EndOfStream)
            {
                s = sr.ReadToEnd();
                s = string.Format(s.Replace("\\n", "\n"));
                sArray = s.Split(',');
            }
            sr.Close();
            fs.Close();

            Event _event = new Event();
            List<string> list = new List<string>();
            List<string> itemList = new List<string>();
            bool fileEnd = false;
            bool listAdd = false;
            bool itemListAdd = false;
            foreach (var i in sArray)
            {
                //Console.WriteLine(i);
                if (!fileEnd)
                {
                    if (i == "")
                    {
                        continue;
                    }
                    if (i == "START")
                    {
                        listAdd = true;
                        continue;
                    }
                    else if (i == "END")
                    {
                        listAdd = false;
                        fileEnd = _event.EventCreate(list);
                        list.Clear();
                        continue;
                    }
                    if (i == "ITEMSTART")
                    {
                        itemListAdd = true;
                        continue;
                    }
                    else if (i == "ITEMEND")
                    {
                        itemListAdd = false;
                        fileEnd = _event.EventCreate(itemList);
                        itemList.Clear();
                        continue;
                    }
                    if (itemListAdd)
                    {
                        itemList.Add(i);
                        continue;
                    }
                    if (listAdd)
                    {
                        list.Add(i);
                        continue;
                    }
                    fileEnd = _event.EventCreate(i);
                    if (fileEnd)
                    {
                        EventManager.Instance.EventAdd(_event.Name, _event);
                        _event = null;
                        _event = new Event();
                        fileEnd = false;
                        listAdd = false;
                        itemListAdd = false;
                    }
                }
            }
        }

        public void EnemyLoad()
        {
            FileStream fs = File.OpenRead("Enemys.csv");
            StreamReader sr = new StreamReader(fs);
            string s;
            string[] sArray = null;
            while (!sr.EndOfStream)
            {
                s = sr.ReadLine();
                sArray = s.Split(',');
            }
            sr.Close();
            fs.Close();

            Enemy enemy = new Enemy();
            bool fileEnd = false;
            foreach (var i in sArray)
            {
                if (!fileEnd)
                {
                    if (i == "")
                    {
                        continue;
                    }
                    fileEnd = enemy.EnemyCreate(i);
                    if (fileEnd)
                    {
                        EnemyManager.Instance.EnemyAdd(enemy.Name, enemy);
                        enemy = null;
                        enemy = new Enemy();
                        fileEnd = false;
                    }
                }
            }
        }



        public static FileIoManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FileIoManager();
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
