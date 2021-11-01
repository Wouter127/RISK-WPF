using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using RISK.View;

namespace RISK.Extensions
{
    public class DialogService
    {

        Window selectPlayers = null;
        Window changeSettings = null;
        Window mainGame = null;
        Window winner = null;
        Window gameInfo = null;
        public DialogService() { }

        public void ShowSelectPlayersDialog()
        {
            selectPlayers = new SelectPlayers();
            selectPlayers.ShowDialog();
        }

        public void ClosePlayerDetailDialog()
        {
            if (selectPlayers != null)
            {
                selectPlayers.Close();
            }

        }

        public void ShowChangeSettingsDialog()
        {
            changeSettings = new ChangeSettings();
            changeSettings.ShowDialog();
        }
        public void CloseChangeSettingsDialog()
        {
            if (changeSettings != null)
            {
                changeSettings.Close();
            }

        }

        public void ShowMainGameDialog()
        {
            mainGame = new MainGame();
            mainGame.ShowDialog();
        }

        public void CloseMainGameDialog()
        {
            if (mainGame != null)
            {
                mainGame.Close();
            }
        }
        public void CloseViewsDialog()
        {
            if (changeSettings != null)
            {
                changeSettings.Close();
            }

            if (selectPlayers != null)
            {
                selectPlayers.Close();
            }

            if (mainGame != null)
            {
                mainGame.Close();
            }

            if (winner != null)
            {
                winner.Close();
            }
            if (gameInfo != null)
            {
                gameInfo.Close();
            }


        }
        public void ShowWinnerDialog()
        {
            winner = new Winner();
            winner.ShowDialog();
        }

        public void CloseWinnerDialog()
        {
            if (winner != null)
            {
                winner.Close();
            }
        }
        public void ShowGameInfoDialog()
        {
            gameInfo = new GameInfo();
            gameInfo.ShowDialog();
        }

        public void CloseGameInfoDialog()
        {
            if (gameInfo != null)
            {
                gameInfo.Close();
            }
        }
    }
}
