using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg.Src
{

    internal class Scene
    {
        private string mContent;
        private bool mIsOpen;
        public virtual Scene GetScene() { return this; }
        public virtual void EventProgress(Event _event) { }
        public virtual void EventSuccess(Event _event) { }
        public virtual void SceneUpdate(Player player) { }
        public virtual void SceneUpdate() { }
        public virtual bool ItemInfo(int select) { return false; }
        public virtual void SceneOpen(Player player) { }

        public string Content
        {
            get { return mContent; }
            set { mContent = value; }
        }
        public bool IsOpen
        {
            get { return mIsOpen; }
            set { mIsOpen = value; }
        }
    }
    internal class TitleScene : Scene
    {
        public TitleScene()
        {
            Content = "=========================================================\n                       모험가 이야기\n=========================================================\n\n\n\n                       Prees To Enter";
        }

        public Scene GetScene()
        {
            return this;
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
            Content = ui.GetUI + "\n=============================================\n";
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

        public override void SceneUpdate(Player player)
        {
            ui.PlayerInfoUpdate(player);
        }

        public override void EventProgress(Event _event)
        {
            Content = ui.GetUI;
            Content += "\n=============================================\n";
            Content += _event.Content;
            Content += "\n=============================================\n";
            foreach (var i in _event.Optional)
            {
                Content += i + "\n";
            }
        }

        public override void EventSuccess(Event _event)
        {
            Content = ui.GetUI;
            Content += "\n=============================================\n";
            Content += _event.Content;
            Content += "\n=============================================\n";
            if (0 < _event.RewardGold)
            {
                Content += "+ " + _event.RewardGold + " GOLD\n";
            }
            else if (_event.RewardGold < 0)
            {
                Content += "- " + _event.RewardGold + " GOLD\n";
            }
            if (0 < _event.RewardExp)
            {
                Content += "+ " + _event.RewardExp + " EXP\n";
            }
            else if (_event.RewardExp < 0)
            {
                Content += "- " + _event.RewardExp + " EXP\n";
            }
            if (0 < _event.RewardStatValue)
            {
                Content += "+ " + _event.RewardStat + " : " + _event.RewardStatValue + "\n";
            }
            else if (_event.RewardStatValue < 0)
            {
                Content += "- " + _event.RewardStat + " : " + Math.Abs(_event.RewardStatValue) + "\n";
            }
            if (0 < _event.RewardItemKey.Count)
            {
                foreach (var i in _event.RewardItemKey)
                {
                    Content += "획득! : " + i + "\n";
                }
            }
            Content += "=============================================\n";
            foreach (var i in _event.Optional)
            {
                Content += i + "\n";
            }
            Content += "\n=============================================\n" +
                "Inventory : I\n";

        }

        public MainScene GetScene()
        {
            return this;
        }
    }

    internal class InventoryScene : Scene
    {
        Player mPlayer;
        Inventory mInventory;
        public InventoryScene(Player player)
        {
            mPlayer = player;
            mInventory = player.PlayerInventory;
            Content = "=============================================\n" +
                "Player Inventory 장비중인 아이템\n";
            if(mPlayer.LeftHandEquipItem != null)
            {
                Item item = mPlayer.LeftHandEquipItem;
                if(item.TargetStatus_2 != Status.NONE)
                {
                    Content += item.Name
                        + " / " + item.ItemType
                        + " / " + item.TargetStatus_1
                        + " / " + item.TargetStatus_2
                        + " / 전투력 :" + (mPlayer.GetStatus(item.TargetStatus_1) * item.MultiPlyValue + mPlayer.GetStatus(item.TargetStatus_2) * item.MultiPlyValue)
                        + "\n";
                }
                else
                {
                    Content += item.Name
                        + " / " + item.ItemType
                        + " / " + item.TargetStatus_1
                        + " / 전투력 :" + (mPlayer.GetStatus(item.TargetStatus_1) * item.MultiPlyValue)
                        + "\n";
                }
            }
            if(mPlayer.ArmorEquipItem != null)
            {
                Item item = mPlayer.ArmorEquipItem;
                if (item.TargetStatus_2 != Status.NONE)
                {
                    Content += item.Name
                        + " / " + item.ItemType
                        + " / " + item.TargetStatus_1
                        + " / " + item.TargetStatus_2
                        + " / 전투력 :" + (mPlayer.GetStatus(item.TargetStatus_1) * item.MultiPlyValue + mPlayer.GetStatus(item.TargetStatus_2) * item.MultiPlyValue)
                        + "\n";
                }
                else
                {
                    Content += item.Name
                        + " / " + item.ItemType
                        + " / " + item.TargetStatus_1
                        + " / 전투력 :" + (mPlayer.GetStatus(item.TargetStatus_1) * item.MultiPlyValue)
                        + "\n";
                }
            }
            if (mPlayer.RightHandEquipItem != null)
            {
                Item item = mPlayer.RightHandEquipItem;
                if (item.TargetStatus_2 != Status.NONE)
                {
                    Content += item.Name
                        + " / " + item.ItemType
                        + " / " + item.TargetStatus_1
                        + " / " + item.TargetStatus_2
                        + " / 전투력 :" + (mPlayer.GetStatus(item.TargetStatus_1) * item.MultiPlyValue + mPlayer.GetStatus(item.TargetStatus_2) * item.MultiPlyValue)
                        + "\n";
                }
                else
                {
                    Content += item.Name
                        + " / " + item.ItemType
                        + " / " + item.TargetStatus_1
                        + " / 전투력 : " + (mPlayer.GetStatus(item.TargetStatus_1) * item.MultiPlyValue)
                        + "\n";
                }
            }
            Content += "=============================================\n";
            for (int i = 0; i < mInventory.Items.Count; i++)
            {
                if (i != 0 && i % 3 == 0)
                {
                    Content += "\n";
                }
                Content += i + ". " + mInventory.Items[i].Name + " ";
            }
            Content += "\n=============================================\n설명을 볼 아이템을 선택 : ";
        }

        public override void SceneOpen(Player player)
        {
            mPlayer = player;
            mInventory = player.PlayerInventory;
            Content = "=============================================\n" +
                "Player Inventory 장비중인 아이템\n";
            if (mPlayer.LeftHandEquipItem != null)
            {
                Item item = mPlayer.LeftHandEquipItem;
                if (item.TargetStatus_2 != Status.NONE)
                {
                    Content += item.Name
                        + " / " + item.ItemType
                        + " / " + item.TargetStatus_1
                        + " / " + item.TargetStatus_2
                        + " / 전투력 :" + (mPlayer.GetStatus(item.TargetStatus_1) * item.MultiPlyValue + mPlayer.GetStatus(item.TargetStatus_2) * item.MultiPlyValue)
                        + "\n";
                }
                else
                {
                    Content += item.Name
                        + " / " + item.ItemType
                        + " / " + item.TargetStatus_1
                        + " / 전투력 :" + (mPlayer.GetStatus(item.TargetStatus_1) * item.MultiPlyValue)
                        + "\n";
                }
            }
            if (mPlayer.ArmorEquipItem != null)
            {
                Item item = mPlayer.ArmorEquipItem;
                if (item.TargetStatus_2 != Status.NONE)
                {
                    Content += item.Name
                        + " / " + item.ItemType
                        + " / " + item.TargetStatus_1
                        + " / " + item.TargetStatus_2
                        + " / 전투력 :" + (mPlayer.GetStatus(item.TargetStatus_1) * item.MultiPlyValue + mPlayer.GetStatus(item.TargetStatus_2) * item.MultiPlyValue)
                        + "\n";
                }
                else
                {
                    Content += item.Name
                        + " / " + item.ItemType
                        + " / " + item.TargetStatus_1
                        + " / 전투력 :" + (mPlayer.GetStatus(item.TargetStatus_1) * item.MultiPlyValue)
                        + "\n";
                }
            }
            if (mPlayer.RightHandEquipItem != null)
            {
                Item item = mPlayer.RightHandEquipItem;
                if (item.TargetStatus_2 != Status.NONE)
                {
                    Content += item.Name
                        + " / " + item.ItemType
                        + " / " + item.TargetStatus_1
                        + " / " + item.TargetStatus_2
                        + " / 전투력 :" + (mPlayer.GetStatus(item.TargetStatus_1) * item.MultiPlyValue + mPlayer.GetStatus(item.TargetStatus_2) * item.MultiPlyValue)
                        + "\n";
                }
                else
                {
                    Content += item.Name
                        + " / " + item.ItemType
                        + " / " + item.TargetStatus_1
                        + " / 전투력 : " + (mPlayer.GetStatus(item.TargetStatus_1) * item.MultiPlyValue)
                        + "\n";
                }
            }
            Content += "=============================================\n";
            for (int i = 0; i < mInventory.Items.Count; i++)
            {
                if (i != 0 && i % 3 == 0)
                {
                    Content += "\n";
                }
                Content += i + ". " + mInventory.Items[i].Name + " ";
            }
            Content += "\n=============================================\n설명을 볼 아이템을 선택 : ";
        }

        public override bool ItemInfo(int select)
        {
            if (mInventory.Items.Count - 1 < select || select < 0)
            {
                return false;
            }
            IsOpen = true;
            Item mItem = mInventory.Items[select];
            Content = "=============================================\n" +
                "이름 :" + mItem.Name + "\n" +
                "연관 스탯 : " + mItem.TargetStatus_1 + "\n";
            if (mItem.TargetStatus_2 != Status.NONE)
            {
                Content += "연관 스탯 : " + mItem.TargetStatus_2 + "\n";
                Content += "전투력 : " + (mPlayer.GetStatus(mItem.TargetStatus_2) * mItem.MultiPlyValue
                    + mPlayer.GetStatus(mItem.TargetStatus_1) * mItem.MultiPlyValue) + "\n";
            }
            else
            {
                Content += "전투력 : " + mPlayer.GetStatus(mItem.TargetStatus_1) * mItem.MultiPlyValue + "\n";
            }
            Content += "=============================================\n" +
                "현재 장착중인 아이템\n" +
                "=============================================\n";

            bool playerItemEquip = false;
            switch (mItem.ItemType)
            {
                case ItemType.NONE:
                    break;
                case ItemType.LEFTHAND:
                    if (mPlayer.LeftHandEquipItem != null)
                    {

                    }
                    else
                    {
                        playerItemEquip = false;
                    }
                    break;
                case ItemType.RIGHTHAND:
                    if (mPlayer.RightHandEquipItem != null)
                    {

                    }
                    else
                    {
                        playerItemEquip = false;
                    }
                    break;
                case ItemType.TWOHANDED:
                    if (mPlayer.LeftHandEquipItem == null && mPlayer.RightHandEquipItem == null)
                    {
                        playerItemEquip = false;
                    }
                    if (mPlayer.LeftHandEquipItem != null)
                    {

                    }
                    if (mPlayer.RightHandEquipItem != null)
                    {

                    }
                    break;
                case ItemType.ARMOR:
                    if (mPlayer.ArmorEquipItem != null)
                    {

                    }
                    else
                    {
                        playerItemEquip = false;
                    }
                    break;
                default:
                    break;
            }
            if (!playerItemEquip)
            {
                Content += "없음\n" +
                   "=============================================\n";
            }
            Content += "장착 : ENTER  뒤로 : ESC\n";

            return true;
        }
    }

    internal class LevelUpScene : Scene
    {
        Player mPlayer;
        UI mUi;

        public LevelUpScene(Player player)
        {
            mPlayer = player;
            mUi = new UI(player);
            LevelUpUi();
        }

        public override void SceneUpdate(Player player)
        {
            mPlayer = player;
            mUi.DataUpdate(mPlayer);
            LevelUpUi();
        }

        public void LevelUpUi()
        {
            mUi.PlayerLevelUp(mPlayer);
            Content = mUi.GetUI;
        }

    }
}
