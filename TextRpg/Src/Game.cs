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
            currentScene = new TitleScene();

            player = new Player();

            Update();
        }

        public void Update()
        {
            while (true)
            {
                Console.Clear();
                ScreenOutPut();
                switch (currentScene)
                {
                    case TitleScene:
                        KeyInput();
                        break;
                    case MainScene:
                        EventOptionalChoice();
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
            }

        }

        internal void SceneChange(Scene scene)
        {
            currentScene = scene;
        }

        public void EventOptionalChoice()
        {
            ConsoleKeyInfo consoleKeyInfo;
            while (true)
            {
                consoleKeyInfo = Console.ReadKey();
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.D1:
                        if (_event.NextContentKey[0] == "RANDOM")
                        {
                            _event = EventManager.Instance.EventRandomFind();
                        }
                        else
                        {
                            _event = EventManager.Instance.EventFind(_event.NextContentKey[0]);
                        }
                        return;
                    case ConsoleKey.D2:
                        if (_event.NextContentKey[1] == "RANDOM")
                        {
                            _event = EventManager.Instance.EventRandomFind();
                        }
                        else
                        {
                            _event = EventManager.Instance.EventFind(_event.NextContentKey[1]);
                        }
                        return;
                    case ConsoleKey.D3:
                        if (_event.NextContentKey[2] == "RANDOM")
                        {
                            _event = EventManager.Instance.EventRandomFind();
                        }
                        else
                        {
                            _event = EventManager.Instance.EventFind(_event.NextContentKey[2]);
                        }
                        return;
                    case ConsoleKey.D4:
                        if (_event.NextContentKey[3] == "RANDOM")
                        {
                            _event = EventManager.Instance.EventRandomFind();
                        }
                        else
                        {
                            _event = EventManager.Instance.EventFind(_event.NextContentKey[3]);
                        }
                        return;
                    case ConsoleKey.F1:
                        FileIoManager.Instance.PlayerDataSave(player);
                        break;
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

    }
}