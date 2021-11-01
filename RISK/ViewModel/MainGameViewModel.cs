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
    class MainGameViewModel : BaseViewModel
    {
        public MainGameViewModel()
        {
            Map = new Map();
            KoppelenCommands();
            playersList = Map.GetPlayersList();
            dialogService = new DialogService();
        }

        private Map map;
        public Map Map
        {
            get
            {
                return map;
            }
            set
            {
                map = value;
                NotifyPropertyChanged();
            }
        }
        private Country selectedCountry;
        public Country SelectedCountry
        {
            get
            {
                return selectedCountry;
            }
            set
            {
                selectedCountry = value;
                NotifyPropertyChanged();
            }
        }
        private Player selectedPlayer;
        public Player SelectedPlayer
        {
            get
            {
                return selectedPlayer;
            }
            set
            {
                selectedPlayer = value;
                NotifyPropertyChanged();
            }
        }
        private string message;
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
                NotifyPropertyChanged();
            }
        }
        private List<Player> playersList;
        private Player playerAanDeBeurt;
        private Country attackingCountry;
        private Country defendingCountry;
        private bool isFirstRound = true;
        private bool vechten = false;
        private bool troepenAfhalen = false;
        private DialogService dialogService;
        public ICommand SelectCountryCommand { get; set; }
        public ICommand AddArmyCommand { get; set; }
        public ICommand DeleteArmyCommand { get; set; }
        public ICommand StartVolgendeRondeCommand { get; set; }
        public ICommand SelectAttackingCountryCommand { get; set; }
        public ICommand SelectDefendingCountryCommand { get; set; }
        public ICommand ValAanCommand { get; set; }
        public ICommand NavigateToSplashScreenCommand { get; set; }
        public ICommand VerplaatsTroepenCommand { get; set; }
        private void KoppelenCommands()
        {
            SelectCountryCommand = new BaseParCommand(GetSelectedCountry);
            AddArmyCommand = new BaseCommand(AddArmy);
            DeleteArmyCommand = new BaseCommand(DeleteArmy);
            StartVolgendeRondeCommand = new BaseCommand(StartVolgendeRonde);
            SelectAttackingCountryCommand = new BaseCommand(SelectAttackingCountry);
            SelectDefendingCountryCommand = new BaseCommand(SelectDefendingCountry);
            ValAanCommand = new BaseCommand(ValAan);
            NavigateToSplashScreenCommand = new BaseCommand(NavigateToSplashScreen);
            VerplaatsTroepenCommand = new BaseCommand(VerplaatsTroepen);
        }
        private void GetSelectedCountry(object countryId)
        {
            SelectedCountry = Map.GetSelectedCountry((int)countryId);
            SelectedPlayer = Map.GetSelectedPlayer((int)countryId);
        }

        private void AddArmy()
        {
            //Spelers mogen zellf kiezen waar en hoeveel troepen ze inzetten onder deze voorwaarden
            // alle troepen moeten ingezet worden, alle landen moeten minimum 1 troep hebben, spelers mogen alleen op hun eigen kleur inzetten.
            if (selectedPlayer == null)
            {
                message = "Er is nog geen land geselecteerd";
                NotifyPropertyChanged("message");
            }
            else if (isFirstRound == true)
            {
                if (selectedPlayer.AantalTroepen <= 0)
                {
                    message = selectedPlayer.Name + " heeft geen troepen meer.";
                    NotifyPropertyChanged("message");
                }
                else
                {
                    Map.AddArmy(selectedCountry.Id, selectedPlayer.Id);
                }
            }
            else if (selectedPlayer.Id != playerAanDeBeurt.Id)
            {
                message = playerAanDeBeurt.Name + " is aan de beurt. Je kan alleen troepeninzetten op je eigen landen.";
                NotifyPropertyChanged("message");
            }
            else if (vechten == true)
            {
                message = "Je kan pas troepen aan je land toevoegen als je gedaan hebt met vechten, klik op \"verplaats troepen\" als je wilt stoppen met vechten";
                NotifyPropertyChanged("message");
            }
            else if (selectedPlayer.AantalTroepen <= 0)
            {
                message = selectedPlayer.Name + " heeft geen troepen meer. Selecteer het land waarmee je wil aanvallen";
                NotifyPropertyChanged("message");
            }
            else
            {
                Map.AddArmy(selectedCountry.Id, selectedPlayer.Id);
                if (selectedPlayer.AantalTroepen == 0)
                {
                    message = "Alle troepen ingezet, selecteer het land waarmee je wil aanvallen";
                    NotifyPropertyChanged("message");
                }
            }

        }
        private void DeleteArmy()
        {
            //Spelers mogen zellf kiezen waar en hoeveel troepen ze inzetten onder deze voorwaarden
            // alle troepen moeten ingezet worden, alle landen moeten minimum 1 troep hebben, spelers mogen alleen op hun eigen kleur inzetten.

            if (selectedPlayer == null)
            {
                message = "Er is nog geen land geselecteerd";
                NotifyPropertyChanged("message");
            }
            else if (isFirstRound == true)
            {
                if (selectedCountry.NumberOfSoldiers <= 0)
                {
                    message = selectedCountry.CountryName + " heeft geen troepen meer.";
                    NotifyPropertyChanged("message");
                }
                else
                {
                    Map.DeleteArmy(selectedCountry.Id, selectedPlayer.Id);
                }
            }
            else if (selectedPlayer.Id != playerAanDeBeurt.Id)
            {
                message = playerAanDeBeurt.Name + " is aan de beurt. Je kan alleen troepen van je eigen landen afhalen.";
                NotifyPropertyChanged("message");
            }
            else if(troepenAfhalen == false)
            {
                message = "Je kan pas troepen verplaatsen aan het einde van de ronde, klik op \"verplaats troepen\" als je troepen wilt verplaatsen";
                NotifyPropertyChanged("message");
            }
            else if (vechten == true)
            {
                message = "Je kan pas troepen van je land afhalen als je gedaan hebt met vechten, klik op \"verplaats troepen\" als je wilt stoppen met vechten";
                NotifyPropertyChanged("message");
            }
            
            else if (selectedCountry.NumberOfSoldiers <= 0)
            {
                message = selectedCountry.CountryName + " heeft geen troepen meer.";
                NotifyPropertyChanged("message");
            }

            else
            {
                Map.DeleteArmy(selectedCountry.Id, selectedPlayer.Id);

            }
        }
        private void StartVolgendeRonde()
        {
            message = Map.Check();
            if (message == null)
            {
                GetNextPlayer();
                GetTroepen(playerAanDeBeurt);
                isFirstRound = false;
                vechten = false;
                troepenAfhalen = false;
            }
            NotifyPropertyChanged("message");

        }
        private void GetTroepen(Player player)
        {
            //Normale speelronde: Geef player start troepen
            player.AantalTroepen += Map.GetAantalTroepen(player);
            message = player + " krijgt " + player.AantalTroepen + " troepen, zet ze in op het spelbord";
        }
        private void GetNextPlayer()
        {
            int index = playersList.IndexOf(playerAanDeBeurt);
            if (playerAanDeBeurt == null || playerAanDeBeurt.Id == playersList[playersList.Count - 1].Id)
            {
                playerAanDeBeurt = playersList[0];
            }
            else if (playersList[index + 1].Countries.Count == 0)
            {
                playerAanDeBeurt = playersList[index + 1];
                GetNextPlayer();
            }
            else
            {
                playerAanDeBeurt = playersList[index + 1];
            }
        }
        private void SelectAttackingCountry()
        {
            defendingCountry = null;
            message = Map.Check();
            if (message != null)
            {
                NotifyPropertyChanged("message");
            }
            else if (playerAanDeBeurt == null)
            {
                message = "Eerst moet iedereen zijn troepen inzetten en de rondes starten";
                NotifyPropertyChanged("message");
            }
            else if(vechten == true && troepenAfhalen == true)
            {
                message = "je kan niet meer aanvallen als je je troepen hebt verplaatst";
                NotifyPropertyChanged("message");
            }
            else if (playerAanDeBeurt.Id != selectedPlayer.Id)
            {
                message = "Het aanvallende land moet van " + playerAanDeBeurt.Name + " zijn.";
                NotifyPropertyChanged("message");
            }
            else if (selectedCountry.NumberOfSoldiers == 1)
            {
                message = "Landen met 1 troep kunnen niet aanvallen.";
                NotifyPropertyChanged("message");
            }
            else
            {
                vechten = true;
                troepenAfhalen = false;
                attackingCountry = selectedCountry;
                message = selectedCountry.CountryName + " geselecteerd als aanvaller. Selecteer het land dat je wilt aanvallen";
                NotifyPropertyChanged("message");

            }
        }
        private void SelectDefendingCountry()
        {
            message = Map.Check();
            if (message != null)
            {
                NotifyPropertyChanged("message");
            }
            else if (playerAanDeBeurt == null)
            {
                message = "Eerst moet iedereen zijn troepen inzetten en de rondes starten";
                NotifyPropertyChanged("message");
            }
            else if (attackingCountry == null)
            {
                message = "Selecteer eerst een aanvallend land.";
                NotifyPropertyChanged("message");
            }
            else if (playerAanDeBeurt.Id == selectedPlayer.Id)
            {
                message = "Het verdedigende land moet van een andere speler zijn.";
                NotifyPropertyChanged("message");
            }
            else if (vechten == false)
            {
                message = "je kan niet meer aanvallen als je je troepen hebt verplaatst";
                NotifyPropertyChanged("message");
            }
            /*            else if (selectedCountry niet grenst aan attackingCountry)
                        {
                            message = "Vechtende landen moeten grenzen aan elkaar.";
                            NotifyPropertyChanged("message");
                        }*/
            else
            {
                defendingCountry = selectedCountry;
                message = attackingCountry.CountryName + " VS " + defendingCountry.CountryName;
                NotifyPropertyChanged("message");
            }
        }

        private void ValAan()
        {
            message = Map.Check();
            if (message != null)
            {
                NotifyPropertyChanged("message");
            }
            else if (playerAanDeBeurt == null)
            {
                message = "Eerst moet iedereen zijn troepen inzetten en de rondes starten";
                NotifyPropertyChanged("message");
            }
            else if (attackingCountry == null)
            {
                message = "Selecteer eerst een aanvallend land.";
                NotifyPropertyChanged("message");
            }
            else if (defendingCountry == null)
            {
                message = "Selecteer eerst het land dat je wilt aanvallen";
                NotifyPropertyChanged("message");
            }
            
            else if (attackingCountry.NumberOfSoldiers <= 1)
            {
                message = attackingCountry.CountryName + " heeft niet genoeg troepen om aan te vallen";
                NotifyPropertyChanged("message");
            }
            else if (defendingCountry.Player == attackingCountry.Player)
            {
                message = "Je hebt " + defendingCountry.CountryName + " al veroverd, selecteer een nieuwe verdediger of start de volgende beurt";
                NotifyPropertyChanged("message");
            }
            else if (vechten == false)
            {
                message = "je kan niet meer aanvallen als je je troepen hebt verplaatst";
                NotifyPropertyChanged("message");
            }
            else
            {
                message = Map.ValAan(attackingCountry, defendingCountry);
                NotifyPropertyChanged("message");
                SelectedPlayer = Map.GetSelectedPlayer((int)defendingCountry.Id);
                if (Map.CheckWinner())
                {
                    Messenger.Default.Send<Player>(playerAanDeBeurt);
                    
                    NavigateToSplashScreen();
                    dialogService.ShowWinnerDialog();
                }
            }
        }

        private void VerplaatsTroepen()
        {
            vechten = false;
            troepenAfhalen = true;
        }
        private void NavigateToSplashScreen()
        {
            Messenger.Default.Send<CloseViewsMessage>(new CloseViewsMessage());
        }

    }
}
