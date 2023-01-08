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

        public ConsoleKey userInput()
        {
            consoleKeyInfo = Console.ReadKey();
            
            return consoleKeyInfo.Key;
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
