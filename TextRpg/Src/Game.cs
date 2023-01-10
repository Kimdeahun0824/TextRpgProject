using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TextRpg.Src.Manager;
using TextRpg.Src.Manager.InputKey;
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
        bool _eventEnd;
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
            _eventEnd = false;
            player = new Player();

            Update();
        }

        public void Update()
        {
            while (true)
            {
                Console.Clear();
                currentScene.UiUpdate(player);
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
                    Console.WriteLine(currentScene.Content);
                    break;
                case InventoryScene:
                    Console.WriteLine(currentScene.Content);
                    break;
            }

        }

        internal void SceneChange(Scene scene)
        {
            currentScene = scene;
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
                            Console.WriteLine("TEST");
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
                        Player _player = FileIoManager.Instance.PlayerDataLoad();
                        SceneChange(new MainScene(_player));
                        _event = EventManager.Instance.EventFind(_player.CurrentEventName);
                    }
                    else
                    {
                        SceneChange(new MainScene(player));
                    }
                    break;
                case ConsoleKey.F1:
                    FileIoManager.Instance.PlayerDataSave(player);
                    break;
            }
        }

        public void InventorySceneKeyInput()
        {
            int userInput;
            int.TryParse(Console.ReadLine(), out userInput);

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