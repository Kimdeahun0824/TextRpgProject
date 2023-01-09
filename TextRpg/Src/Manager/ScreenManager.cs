using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg.Src
{
    internal class ScreenManager
    {
        private static ScreenManager instance = new ScreenManager();

        private ScreenManager() { }

        public void ScreenOutPut(string value)
        {
            Console.Write(value);
        }

        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ScreenManager();
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
