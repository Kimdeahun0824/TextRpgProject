using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg.Src
{

    internal class Scene
    {
        public string mContent;
        public virtual Scene GetScene() { return this; }
        public virtual void EventProgress(Event _event) {}


        public string Content
        {
            get { return mContent; }
            set { mContent = value; }
        }
    }
    internal class TitleScene : Scene
    {
        public TitleScene()
        {
            mContent = "=========================================================\n                       모험가 이야기\n=========================================================\n\n\n\n                       Prees To Enter";
        }

        public Scene GetScene()
        {
            return this;
        }

        public string Content
        {
            get { return mContent; }
            set { mContent = value; }
        }
    }

    internal class MainScene : Scene
    {
        Random random;
        UI ui;
        public MainScene(Player player)
        {
            ui = new UI(player);
            Random random = new Random();
            ui = new UI(player);
            mContent = ui.PlayerStatus + "\n=============================================\n";
            //    + _event.Content + "\n=============================================\n";
            //mContent += "획득! : " + _event.RewardItemKey[random.Next(0, _event.RewardItemKey.Count)] + "\n";

            //mContent += "획득! : " + _event.RewardGold + "GOLD\n"
            //    + "획득! : " + _event.RewardExp + "EXP\n";
            //mContent += "=============================================\n";
            //foreach (var i in _event.Optional)
            //{
            //    mContent += i + "\n";
            //}
        }

        public override void EventProgress(Event _event)
        {
            mContent = ui.PlayerStatus;
            mContent += "\n=============================================\n";
            mContent += _event.Content;
            mContent += "\n=============================================\n";
            foreach (var i in _event.Optional)
            {
                mContent += i + "\n";
            }

        }

        public void EventSuccess(Event _event)
        {
            mContent += "획득! : " + _event.RewardGold + "GOLD\n"
                + "획득! : " + _event.RewardExp + "EXP\n";
            mContent += "=============================================\n";
            foreach (var i in _event.Optional)
            {
                mContent += i + "\n";
            }
        }

        public void InventoryOpen()
        {

        }

        public void InventoryClose()
        {

        }

        public MainScene GetScene()
        {
            return this;
        }
    }
}
