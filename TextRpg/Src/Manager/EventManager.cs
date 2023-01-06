using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRpg.Src.Manager;

namespace TextRpg.Src
{
    internal class EventManager
    {
        private static EventManager instance = new EventManager();
        private Dictionary<string, Event> mEvents;

        private EventManager()
        {
            mEvents = new Dictionary<string, Event>();
        }

        public void EventAdd(string key, Event _event)
        {
            mEvents.Add(key, _event);
        }

        public Event EventFind(string key)
        {
            if (mEvents.ContainsKey(key))
            {
                Event _event = mEvents[key];
                return _event;
            }
            else
            {
                return null;
            }
                
        }

        public static EventManager Instance
        {
            get
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
}
