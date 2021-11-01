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
    class WinnerViewModel : BaseViewModel
    {
        private DialogService dialogService;
        private Player winner;
        public Player Winner
        {
            get
            {
                return winner;
            }
            set
            {
                winner = value;
                NotifyPropertyChanged();
            }
        }
        public WinnerViewModel()
        {
            dialogService = new DialogService();
            Messenger.Default.Register<Player>(this, OnPlayerRecieved);
            KoppelenCommands();
        }
        private void OnPlayerRecieved(Player player)
        {
            winner = player;
        }
        public ICommand ShowGameInfoCommand { get; set; }
        private void KoppelenCommands()
        {
            ShowGameInfoCommand = new BaseCommand(ShowGameInfo);
        }
        private void ShowGameInfo()
        {
            dialogService.ShowGameInfoDialog();
            NavigateToSplashScreen();
        }
        public void NavigateToSplashScreen()
        {
            Messenger.Default.Send<CloseViewsMessage>(new CloseViewsMessage());
        }
    }
}
