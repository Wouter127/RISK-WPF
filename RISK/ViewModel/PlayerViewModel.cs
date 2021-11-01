using RISK.Extensions;
using RISK.Messages;
using RISK.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RISK.ViewModel
{
    class PlayerViewModel : BaseViewModel
    {
        public PlayerViewModel()
        {
            LeesPlayers();
            KoppelenCommands();
        }

        private ObservableCollection<Player> players;
        public ObservableCollection<Player> Players
        {
            get { return players; }
            set 
            { 
                players = value;
                NotifyPropertyChanged();
            }
        }
        private Player selectedPlayer;
        public Player SelectedPlayer
        {
            get 
            {
                if(selectedPlayer == null)
                {
                    selectedPlayer = new Player();
                }
                return selectedPlayer; 
            }
            set
            {
                selectedPlayer = value;
                NotifyPropertyChanged();
            }
        }

        private void KoppelenCommands()
        {
            WijzigenCommand = new BaseCommand(WijzigenPlayer);
            VerwijderenCommand = new BaseCommand(VerwijderenPlayer);
            ToevoegenCommand = new BaseCommand(ToevoegenPlayer);
            NavigateToSplashScreenCommand = new BaseCommand(NavigateToSplashScreen);
    }

        public ICommand WijzigenCommand { get; set; }
        public ICommand VerwijderenCommand { get; set; }
        public ICommand ToevoegenCommand { get; set; }
        public ICommand NavigateToSplashScreenCommand { get; set; }
        

        private void LeesPlayers()
        {
            // instantiëren dataservice
            PlayerDataService contactDS = new PlayerDataService();
            Players = new ObservableCollection<Player>(contactDS.GetPlayers());
        }

        public void WijzigenPlayer()
        {
            if (SelectedPlayer != null)
            {
                PlayerDataService contactDS = new PlayerDataService();
                contactDS.UpdatePlayer(SelectedPlayer);

                //refresh
                LeesPlayers();
            }
        }
        public void ToevoegenPlayer()
        {
            
                PlayerDataService contactDS = new PlayerDataService();
            selectedPlayer.GameId = 1;
                contactDS.InsertPlayer(SelectedPlayer);

                //refresh
                LeesPlayers();
            
        }
        public void VerwijderenPlayer()
        {

                PlayerDataService contactDS = new PlayerDataService();
                contactDS.DeletePlayer(SelectedPlayer);

                //refresh
                LeesPlayers();
            
        }
        public void NavigateToSplashScreen()
        {
            Messenger.Default.Send<CloseViewsMessage>(new CloseViewsMessage());
        }


    }
}
