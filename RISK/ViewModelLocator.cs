using RISK.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISK
{
    class ViewModelLocator
    {
        private static ChangeSettingsViewModel changeSettingsViewModel = new ChangeSettingsViewModel();
        private static PlayerViewModel playerViewModel = new PlayerViewModel();
        private static SplashScreenViewModel splashScreenViewModel = new SplashScreenViewModel();
        private static MainGameViewModel mainGameViewModel = new MainGameViewModel();
        private static WinnerViewModel winnerViewModel = new WinnerViewModel();
        private static GameInfoViewModel gameInfoViewModel = new GameInfoViewModel();
        public static MainGameViewModel MainGameViewModel
        {
            get
            {
                return mainGameViewModel;
            }
        }
        public static ChangeSettingsViewModel ChangeSettingsViewModel
        {
            get
            {
                return changeSettingsViewModel;
            }
        }
        public static PlayerViewModel PlayerViewModel
        {
            get
            {
                return playerViewModel;
            }
        }
        public static SplashScreenViewModel SplashScreenViewModel
        {
            get
            {
                return splashScreenViewModel;
            }
        }
        public static WinnerViewModel WinnerViewModel
        {
            get
            {
                return winnerViewModel;
            }
        }
        public static GameInfoViewModel GameInfoViewModel
        {
            get
            {
                return gameInfoViewModel;
            }
        }
    }
}
