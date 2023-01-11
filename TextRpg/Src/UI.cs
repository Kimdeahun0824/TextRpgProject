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
        private string mUi;

        public UI(Player player)
        {
            this.mPlayer = player;
            mUi = " " + player.Name + "           골드 : " + player.Gold + " 전투력 : " + player.CombatPower + " 경험치 : " + player.GetStatus(Status.EXP) + " 레벨 : " + player.GetStatus(Status.LEVEL) + "\n"
                + "체력 : " + player.GetStatus(Status.HP) + "          힘 : " + player.GetStatus(Status.STRENGTH) + " 민첩 : " + player.GetStatus(Status.AGILITY) + " 지능 : " + player.GetStatus(Status.INTELLIGENCE) + "\n"
                + "마나 : " + player.GetStatus(Status.MP) + "    카리스마 : " + player.GetStatus(Status.CHARISMA) + " 건강 : " + player.GetStatus(Status.HEALTH) + " 지혜 : " + player.GetStatus(Status.WISDOM);
        }

        public void DataUpdate(Player player)
        {
            mPlayer = player;
        }

        public void PlayerInfoUpdate(Player player)
        {
            mPlayer = player;
            this.mPlayer = player;
            mUi = " " + player.Name + "           골드 : " + player.Gold + " 전투력 : " + player.CombatPower + " 경험치 : " + player.GetStatus(Status.EXP) + " 레벨 : " + player.GetStatus(Status.LEVEL) + "\n"
                + "체력 : " + player.GetStatus(Status.HP) + "          힘 : " + player.GetStatus(Status.STRENGTH) + " 민첩 : " + player.GetStatus(Status.AGILITY) + " 지능 : " + player.GetStatus(Status.INTELLIGENCE) + "\n"
                + "마나 : " + player.GetStatus(Status.MP) + "    카리스마 : " + player.GetStatus(Status.CHARISMA) + " 건강 : " + player.GetStatus(Status.HEALTH) + " 지혜 : " + player.GetStatus(Status.WISDOM);
        }

        public void PlayerLevelUp(Player player)
        {
            mPlayer = player;
            mUi = "=============================================\n" +
                "                LevelUp\n" +
                "=============================================\n" +
                "1. 힘 : " + mPlayer.GetStatus(Status.STRENGTH) + "\n"
                + "2. 민첩 : " + mPlayer.GetStatus(Status.AGILITY) + "\n"
                 + "3. 지능 : " + mPlayer.GetStatus(Status.INTELLIGENCE) + "\n"
                + "4. 카리스마 : " + mPlayer.GetStatus(Status.CHARISMA) + "\n"
                 + "5. 건강 : " + mPlayer.GetStatus(Status.HEALTH) + "\n"
                + "6. 지혜 : " + mPlayer.GetStatus(Status.WISDOM) + "\n" +
                "=============================================\n" +
                +mPlayer.StatPoint + " - 남은 포인트 / 올릴 스탯 입력 : ";
        }

        public string GetUI
        {
            get { return mUi; }
            set { mUi = value; }
        }
    }
}
