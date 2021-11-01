using RISK.Extensions;
using RISK.Messages;
using RISK.Model;
using RISK.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace RISK.ViewModel
{
    class SplashScreenViewModel : BaseViewModel
    {
        private DialogService dialogService;
        public SplashScreenViewModel()
        {
            //Instantiëren dialogservice als singleton
            dialogService = new DialogService();
            KoppelenCommands();
            
            //Luisteren naar updates vanuit select players view
            Messenger.Default.Register<CloseViewsMessage>(this, CloseViews);
        }

        //Commands
        public ICommand NavigateToSelectPlayersCommand { get; set; }
        public ICommand NavigateToChangeSettingsCommand { get; set; }
        public ICommand NavigateToMainGameCommand { get; set; }

        private void KoppelenCommands()
        {
            NavigateToSelectPlayersCommand = new BaseCommand(NavigateToSelectPlayers);
            NavigateToChangeSettingsCommand = new BaseCommand(NavigateToChangeSettings);
            NavigateToMainGameCommand = new BaseCommand(NavigateToMainGame);
        }
        private void CloseViews(CloseViewsMessage message)
        {
            dialogService.CloseViewsDialog();
        }
        public void NavigateToSelectPlayers()
        {
            dialogService.ShowSelectPlayersDialog();

        }
        public void NavigateToChangeSettings()
        {
            dialogService.ShowChangeSettingsDialog();

        }
        public void NavigateToMainGame()
        {
            dialogService.ShowMainGameDialog();
        }
    }
}
