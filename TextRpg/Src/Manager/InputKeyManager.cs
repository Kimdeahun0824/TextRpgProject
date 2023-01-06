using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRpg.Src.Manager.InputKey;


namespace TextRpg.Src.Manager
{
    internal class InputKeyManager
    {
        private static InputKeyManager instance = new InputKeyManager();
        private ConsoleKeyInfo consoleKeyInfo;

        

        private InputKeyManager()
        {

        }
        public IinputKeyAction userInput()
        {
            consoleKeyInfo = Console.ReadKey();
            IinputKeyAction inputKey = null;
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.D0:
                    //inputKey = InputKey_0.Instance;
                    break;
                case ConsoleKey.F1:
                    inputKey = InputKey_F1.Instance;
                    break;
                default:
                    inputKey = null;
                    break;
            }
            return inputKey;
        }


        public static InputKeyManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new InputKeyManager();
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
