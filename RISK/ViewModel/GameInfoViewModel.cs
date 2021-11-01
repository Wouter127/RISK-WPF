using RISK.Extensions;
using RISK.Messages;
using RISK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RISK.ViewModel
{
    class GameInfoViewModel : BaseViewModel
    {
        private DialogService dialogService;
        private GameInfo gameInfo;
        public GameInfo GameInfo
        {
            get
            {
                return gameInfo;
            }
            set
            {
                gameInfo = value;
                NotifyPropertyChanged();
            }
        }
        public GameInfoViewModel()
        {
            dialogService = new DialogService(); 
            Messenger.Default.Register<GameInfo>(this, OnGameInfoReceived);
            KoppelenCommands();
        }
        public ICommand NavigateToSplashScreenCommand { get; set; }

        private void KoppelenCommands()
        {
            NavigateToSplashScreenCommand = new BaseCommand(NavigateToSplashScreen);
        }
        private void OnGameInfoReceived(GameInfo gameInfo)
        {
            GameInfo = gameInfo;
        }

        private void NavigateToSplashScreen()
        {
            dialogService.CloseMainGameDialog();
            dialogService.CloseWinnerDialog();
            dialogService.CloseGameInfoDialog();
        }

    }
}
