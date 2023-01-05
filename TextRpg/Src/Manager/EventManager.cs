using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg.Src
{
    internal class EventManager : ISingelton<EventManager>
    {
        private static EventManager instance = new EventManager();
        private Dictionary<string, Event> mEvents;

        private EventManager()
        {
            mEvents = new Dictionary<string, Event>();
        }

        public EventManager getInstance()
        {
            if (instance == null)
            {
                instance = new EventManager();
                return instance;
            }
            else
            {
                return instance;
            }
        }
    }
}
