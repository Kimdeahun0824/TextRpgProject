﻿using System;
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
        private List<string> mEventNameList;
        private Random random;

        private EventManager()
        {
            mEvents = new Dictionary<string, Event>();
            mEventNameList = new List<string>();
            random = new Random();
        }

        public void EventAdd(string key, Event _event)
        {
            mEvents.Add(key, _event);
        }

        public void EventNameListAdd()
        {
            foreach(var _event in mEvents)
            {
                mEventNameList.Add(_event.Key);
            }
        }

        public Event EventRandomFind()
        {
            string randomKey = mEventNameList[random.Next(1,mEventNameList.Count())];
            return EventFind(randomKey);
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

        public Event NextEvent(string key)
        {
            return null;
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
