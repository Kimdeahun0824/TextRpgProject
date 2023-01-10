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
        public virtual void EventProgress(Event _event) { }
        public virtual void EventSuccess(Event _event) { }
        public virtual void UiUpdate(Player player) { }
        public virtual void ItemInfo(int select) { }

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

        public override void UiUpdate(Player player)
        {
            ui.PlayerInfoUpdate(player);
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

        public override void EventSuccess(Event _event)
        {
            mContent = ui.PlayerStatus;
            mContent += "\n=============================================\n";
            mContent += _event.Content;
            mContent += "\n=============================================\n";
            if (0 < _event.RewardGold)
            {
                mContent += "+ " + _event.RewardGold + " GOLD\n";
            }
            else if (_event.RewardGold < 0)
            {
                mContent += "- " + _event.RewardGold + " GOLD\n";
            }
            if (0 < _event.RewardExp)
            {
                mContent += "+ " + _event.RewardExp + " EXP\n";
            }
            else if (_event.RewardExp < 0)
            {
                mContent += "- " + _event.RewardExp + " EXP\n";
            }
            if (0 < _event.RewardStatValue)
            {
                mContent += "+ " + _event.RewardStat + " : " + _event.RewardStatValue + "\n";
            }
            else if (_event.RewardStatValue < 0)
            {
                mContent += "- " + _event.RewardStat + " : " + Math.Abs(_event.RewardStatValue) + "\n";
            }
            if (0 < _event.RewardItemKey.Count)
            {
                foreach (var i in _event.RewardItemKey)
                {
                    mContent += "획득! : " + i + "\n";
                }
            }
            mContent += "=============================================\n";
            foreach (var i in _event.Optional)
            {
                mContent += i + "\n";
            }
            mContent += "\n=============================================\n" +
                "Inventory : I\n";

        }

        public MainScene GetScene()
        {
            return this;
        }
    }

    internal class InventoryScene : Scene
    {
        public InventoryScene(Player player)
        {
            mContent = "=============================================\n" +
                "Player Inventory\n" +
                "=============================================\n";
            for (int i = 0; i < player.PlayerInventory.Items.Count; i++)
            {
                mContent += i + ". " + player.PlayerInventory.Items[i].Name + " ";
            }
            mContent += "\n=============================================\n설명을 볼 아이템을 선택 : ";
        }

        public override void ItemInfo(int select)
        {
            
        }
    }
}
