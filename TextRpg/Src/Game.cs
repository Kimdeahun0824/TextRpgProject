using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TextRpg.Src
{
    public class Game
    {
        Player player;
        Combat combat;
        internal Scene currentScene;
        Event _event;

        public Game()
        {
            Init();
        }

        public void Init()
        {
            FileIoManager.Instance.ItemLoad();
            FileIoManager.Instance.EnemyLoad();
            FileIoManager.Instance.EventLoad();
            EventManager.Instance.EventNameListAdd();
            combat = new Combat();
            currentScene = new TitleScene();
            player = new Player();

            Update();
        }

        public void Update()
        {
            while (true)
            {
                Console.Clear();
                player.CombatPowerUpdate();
                if(player.GetStatus(Status.HP) < 1)
                {
                    SceneChange(new PlayerDeadScene());
                }
                if (4 < player.GetStatus(Status.EXP))
                {
                    player.StatPoint += 5;
                    player.Stat[Status.LEVEL] += 1;
                    player.Stat[Status.EXP] -= 5;
                    SceneChange(new LevelUpScene(player));
                }
                currentScene.SceneUpdate(player);
                ScreenOutPut();
                switch (currentScene)
                {
                    case TitleScene:
                        KeyInput();
                        break;
                    case MainScene:
                        MainSceneKeyInPut();
                        break;
                    case InventoryScene:
                        InventorySceneKeyInput();
                        break;
                    case LevelUpScene:
                        LevelUpSceneKeyInput();
                        break;
                    case PlayerDeadScene:

                        break;
                }
                Thread.Sleep(10);
            }
        }

        public void ScreenOutPut()
        {
            switch (currentScene)
            {
                case TitleScene:
                    Console.WriteLine(currentScene.Content);
                    break;
                case MainScene:
                    currentScene.EventProgress(_event);
                    player.CurrentEventName = _event.Name;
                    Console.WriteLine(currentScene.Content);
                    break;
                case InventoryScene:
                    Console.Write(currentScene.Content);
                    break;
                case LevelUpScene:
                    Console.Write(currentScene.Content);
                    break;
                case PlayerDeadScene:
                    Console.Write(currentScene.Content);
                    break;
            }

        }

        internal void SceneChange(Scene scene)
        {
            currentScene = scene;
        }

        public void DeadSceneKeyInput()
        {
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            SceneChange(new TitleScene());
        }

        public void LevelUpSceneKeyInput()
        {
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.D1:
                    player.StatPoint -= 1;
                    player.AddStatus(Status.STRENGTH, 1);
                    break;
                case ConsoleKey.D2:
                    player.StatPoint -= 1;
                    player.AddStatus(Status.AGILITY, 1);
                    break;
                case ConsoleKey.D3:
                    player.StatPoint -= 1;
                    player.AddStatus(Status.INTELLIGENCE, 1);
                    break;
                case ConsoleKey.D4:
                    player.StatPoint -= 1;
                    player.AddStatus(Status.CHARISMA, 1);
                    break;
                case ConsoleKey.D5:
                    player.StatPoint -= 1;
                    player.AddStatus(Status.HEALTH, 1);
                    break;
                case ConsoleKey.D6:
                    player.StatPoint -= 1;
                    player.AddStatus(Status.WISDOM, 1);
                    break;
                default:
                    break;
            }

            if (player.StatPoint < 1)
            {
                SceneChange(new MainScene(player));
            }
        }

        public void MainSceneKeyInPut()
        {
            ConsoleKeyInfo consoleKeyInfo;
            while (true)
            {
                consoleKeyInfo = Console.ReadKey();
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.D1:
                        if (_event.EventEnd)
                        {
                            currentScene.EventSuccess(_event);
                            _event.EventEnd = false;

                            PlayerEventReward();

                            Console.Clear();
                            Console.WriteLine(currentScene.Content);
                            break;
                        }
                        else if (_event.NextContentKey[0] == "RANDOM")
                        {
                            _event.EventEnd = true;
                            _event = EventManager.Instance.EventRandomFind();
                            return;
                        }
                        else
                        {
                            _event = EventManager.Instance.EventFind(_event.NextContentKey[0]);
                            return;
                        }
                    case ConsoleKey.D2:
                        if (1 < _event.NextContentKey.Count)
                        {
                            _event = EventManager.Instance.EventFind(_event.NextContentKey[1]);
                            return;
                        }
                        else
                        {
                            break;
                        }
                    case ConsoleKey.D3:
                        if (2 < _event.NextContentKey.Count)
                        {
                            _event = EventManager.Instance.EventFind(_event.NextContentKey[2]);
                            return;
                        }
                        else
                        {
                            break;
                        }
                    case ConsoleKey.D4:
                        if (3 < _event.NextContentKey.Count)
                        {
                            _event = EventManager.Instance.EventFind(_event.NextContentKey[3]);
                            return;
                        }
                        else
                        {
                            break;
                        }
                    case ConsoleKey.Enter:
                        if (_event.Combat)
                        {
                            CombatPlayer combatPlayer = new CombatPlayer(player.Name, player.CombatPower);
                            combat.SetPlayer(combatPlayer);
                            combat.SetEnemy(EnemyManager.Instance.EnemyFind(_event.EnemyKey));
                            if (combat.CombatStart())
                            {
                                EnemyManager.Instance.EnemyFind(_event.EnemyKey).HP = 5;
                                _event = EventManager.Instance.EventFind(_event.NextContentKey[0]);
                                return;
                            }
                            else
                            {
                                EnemyManager.Instance.EnemyFind(_event.EnemyKey).HP = 5;
                                _event = EventManager.Instance.EventFind(_event.NextContentKey[1]);
                                return;
                            }
                        }
                        if (_event.NextContentKey.Count < 2)
                        {
                            if (_event.EventEnd)
                            {
                                currentScene.EventSuccess(_event);
                                _event.EventEnd = false;

                                PlayerEventReward();

                                Console.Clear();
                                Console.WriteLine(currentScene.Content);
                                break;
                            }
                            else
                            {
                                _event.EventEnd = true;
                                _event = EventManager.Instance.EventRandomFind();
                                return;
                            }
                        }
                        else
                        {
                            break;
                        }
                    case ConsoleKey.I:
                        currentScene = new InventoryScene(player);
                        return;
                    case ConsoleKey.F1:
                        FileIoManager.Instance.PlayerDataSave(player);
                        return;
                    case ConsoleKey.F2:
                        player = FileIoManager.Instance.PlayerDataLoad();
                        _event = EventManager.Instance.EventFind(player.CurrentEventName);
                        return;
                    default:
                        break;
                }
            }
        }

        public void KeyInput()
        {
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.Enter:
                    if (FileIoManager.Instance.PlayerDataCheck())
                    {
                        player = FileIoManager.Instance.PlayerDataLoad();
                        SceneChange(new MainScene(player));
                        _event = EventManager.Instance.EventFind(player.CurrentEventName);
                    }
                    else
                    {
                        SceneChange(new MainScene(player));
                        _event = EventManager.Instance.EventFind("<위대한 모험가를 꿈꾸는>");
                    }
                    break;
            }
        }

        public void InventorySceneKeyInput()
        {
            if (currentScene.IsOpen)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.Enter:
                        player.ItemChange(ItemManager.Instance.SelectItem);
                        break;
                    case ConsoleKey.Escape:
                        break;
                    default:
                        break;
                }
                currentScene.IsOpen = false;
                currentScene.SceneOpen(player);
            }
            else
            {
                string strUserInput = string.Empty;
                bool IsEnter = false;
                while (!IsEnter)
                {
                    ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                    switch (consoleKeyInfo.Key)
                    {
                        case ConsoleKey.Enter:
                            IsEnter = true;
                            break;
                        case ConsoleKey.Escape:
                            SceneChange(new MainScene(player));
                            return;
                        case ConsoleKey.D0:
                            strUserInput += "0";
                            break;
                        case ConsoleKey.D1:
                            strUserInput += "1";
                            break;
                        case ConsoleKey.D2:
                            strUserInput += "2";
                            break;
                        case ConsoleKey.D3:
                            strUserInput += "3";
                            break;
                        case ConsoleKey.D4:
                            strUserInput += "4";
                            break;
                        case ConsoleKey.D5:
                            strUserInput += "5";
                            break;
                        case ConsoleKey.D6:
                            strUserInput += "6";
                            break;
                        case ConsoleKey.D7:
                            strUserInput += "7";
                            break;
                        case ConsoleKey.D8:
                            strUserInput += "8";
                            break;
                        case ConsoleKey.D9:
                            strUserInput += "9";
                            break;
                        default:
                            break;
                    }
                }
                if (!strUserInput.Equals(string.Empty))
                {
                    int userInput;
                    userInput = int.Parse(strUserInput);
                    if (currentScene.ItemInfo(userInput))
                    {
                        Item item = player.PlayerInventory.Items[userInput];
                        ItemManager.Instance.ItemSelect(item);
                    }
                }
            }
        }

        public void PlayerEventReward()
        {
            if (0 < _event.RewardGold)
            {
                player.AddGold(_event.RewardGold);
            }
            else if (_event.RewardGold > 0)
            {
                player.AddGold(_event.RewardGold);
            }
            if (0 < _event.RewardExp)
            {
                player.AddStatus(Status.EXP, _event.RewardExp);
            }
            else if (_event.RewardExp < 0)
            {
                player.AddStatus(Status.EXP, _event.RewardExp);
            }
            if (0 < _event.RewardItemKey.Count)
            {
                foreach (var i in _event.RewardItemKey)
                {
                    Item item = ItemManager.Instance.ItemFind(i);
                    player.PlayerInventory.AddItem(item);
                }
            }
            if (0 < _event.RewardStatValue)
            {
                Status target;
                Enum.TryParse(_event.RewardStat, out target);
                player.AddStatus(target, _event.RewardStatValue);
            }
            else if (_event.RewardStatValue < 0)
            {
                Status target;
                Enum.TryParse(_event.RewardStat, out target);
                player.AddStatus(target, _event.RewardStatValue);
            }
        }
    }
}