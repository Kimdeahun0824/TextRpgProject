using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg.Src
{
    internal class UI
    {
        Player mPlayer;
        private string mPlayerStatus;

        public UI(Player player)
        {
            this.mPlayer = player;
            mPlayerStatus = player.Name + "         골드 : " + player.Gold + " 경험치 : " + player.GetStatus(Status.EXP) + " 레벨 : " + player.GetStatus(Status.LEVEL) + "\n"
                + "체력 : " + player.GetStatus(Status.HP) + "          힘 : " + player.GetStatus(Status.STRENGTH) + " 민첩 : " + player.GetStatus(Status.AGILITY) + " 지능 : " + player.GetStatus(Status.INTELLIGENCE) + "\n"
                + "마나 : " + player.GetStatus(Status.MP) + "    카리스마 : " + player.GetStatus(Status.CHARISMA) + " 건강 : " + player.GetStatus(Status.HEALTH) + " 지혜 : " + player.GetStatus(Status.WISDOM);
        }

        public void PlayerInfoUpdate(Player player)
        {
            mPlayer = player;
            mPlayerStatus = player.Name + "         골드 : " + player.Gold + " 경험치 : " + player.GetStatus(Status.EXP) + " 레벨 : " + player.GetStatus(Status.LEVEL) + "\n"
                + "체력 : " + player.GetStatus(Status.HP) + "          힘 : " + player.GetStatus(Status.STRENGTH) + " 민첩 : " + player.GetStatus(Status.AGILITY) + " 지능 : " + player.GetStatus(Status.INTELLIGENCE) + "\n"
                + "마나 : " + player.GetStatus(Status.MP) + "    카리스마 : " + player.GetStatus(Status.CHARISMA) + " 건강 : " + player.GetStatus(Status.HEALTH) + " 지혜 : " + player.GetStatus(Status.WISDOM);
        }

        public string PlayerStatus
        {
            get { return mPlayerStatus; }
            set { mPlayerStatus = value; }
        }
    }
}
