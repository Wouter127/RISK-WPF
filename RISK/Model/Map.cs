using RISK.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISK.Model
{
    class Map : ObservableCollection<Country>
    {
        Random random = new Random();
        public Map()
        {
            CreateMap();
            
            StartTijd = DateTime.Now;
        }
        //public ObservableCollection<Setting> Settings;
        public ObservableCollection<Game> Games;
        public ObservableCollection<Player> Players;
        public ObservableCollection<Country> Countries;
        public Game Game;
        public GameInfo GameInfo;
        public DateTime StartTijd;
        public DateTime StopTijd;

        private void CreateMap()
        {
            //Get en Drop de countries van de vorige game
            GetCountries();
            DropCountries();

            //Ophalen Game met settings
            GetGame();

            //ophalen Players, geef startTroepen, update naar database en refresh
            GetPlayers();
            UpdateStartTroepen();

            //maak nieuwe Countries en refresh countries, voeg playerId toe aan countries en update naar database, verdeel countries over Players
            AddCountries();
            UpdatePlayerIdToCountries();
            GetCountriesJoined();
            AddCountriesToPlayers();

            //Maak countries en players zichtbaar aan viewmodel
            DisplayCountries();
            GameInfo Info = new GameInfo();
            GameInfo = Info;
        }


        private void GetCountries()
        {
            CountryDataService contactDS = new CountryDataService();
            Countries = new ObservableCollection<Country>(contactDS.GetCountries());

        }
        private void DropCountries()
        {
            CountryDataService contactDS = new CountryDataService();
            foreach (Country country in Countries)
            {
                contactDS.DeleteCountry(country);
            }
        }
        private void GetGame()
        {
            GameDataService contactDS = new GameDataService();
            Games = new ObservableCollection<Game>(contactDS.GetGameSettings());
            Game = Games[0];
        }
        private void GetPlayers()
        {
            PlayerDataService contactDS = new PlayerDataService();
            Players = new ObservableCollection<Player>(contactDS.GetPlayers());

        }
        private void UpdateStartTroepen()
        {
            foreach (Player player in Players)
            {
                PlayerDataService contactDS = new PlayerDataService();
                player.AantalTroepen = Game.Setting.AantalStartTroepen;
                contactDS.UpdateAantalStartTroepen(player);
            }
            // refresh
            GetPlayers();
        }
        private void AddCountries()
        {
            CountryDataService contactDS = new CountryDataService();
            contactDS.InsertCountry(new Country(1, "Alaska", 66, 100, 0, "Amerika"));
            contactDS.InsertCountry(new Country(1, "Noordwestelijke staten", 172, 100, 0, "Amerika"));
            contactDS.InsertCountry(new Country(1, "Alberta", 160, 160, 0, "Amerika"));
            contactDS.InsertCountry(new Country(1, "Ontario", 240, 170, 0, "Amerika"));
            contactDS.InsertCountry(new Country(1, "Verenigde Staten (West)", 160, 240, 0, "Amerika"));
            contactDS.InsertCountry(new Country(1, "Centraal Amerika", 178, 350, 0, "Amerika"));
            contactDS.InsertCountry(new Country(1, "Groenland", 373, 60, 0, "Amerika"));
            contactDS.InsertCountry(new Country(1, "Oost-Canada", 306, 173, 0, "Amerika"));
            contactDS.InsertCountry(new Country(1, "Verenigde Staten (Oost)", 242, 267, 0, "Amerika"));

            contactDS.InsertCountry(new Country(1, "Ijsland", 463, 137, 0, "Europa"));
            contactDS.InsertCountry(new Country(1, "Groot-Britannië", 447, 226, 0, "Europa"));
            contactDS.InsertCountry(new Country(1, "Scandinavië", 551, 140, 0, "Europa"));
            contactDS.InsertCountry(new Country(1, "Noord-Europa", 538, 232, 0, "Europa"));
            contactDS.InsertCountry(new Country(1, "West-Europa", 466, 322, 0, "Europa"));
            contactDS.InsertCountry(new Country(1, "Zuid-Europa", 550, 310, 0, "Europa"));
            contactDS.InsertCountry(new Country(1, "Rusland", 645, 194, 0, "Europa"));

            contactDS.InsertCountry(new Country(1, "Oeral", 750, 173, 0, "Azië"));
            contactDS.InsertCountry(new Country(1, "Siberië", 812, 123, 0, "Azië"));
            contactDS.InsertCountry(new Country(1, "Kamtsjatka", 971, 100, 0, "Azië"));
            contactDS.InsertCountry(new Country(1, "Midden-Oosten", 676, 384, 0, "Azië"));
            contactDS.InsertCountry(new Country(1, "Irkoetsk", 877, 180, 0, "Azië"));
            contactDS.InsertCountry(new Country(1, "Zuidoost-Azië", 882, 409, 0, "Azië"));
            contactDS.InsertCountry(new Country(1, "Mongolië", 897, 245, 0, "Azië"));
            contactDS.InsertCountry(new Country(1, "Japan", 1000, 250, 0, "Azië"));
            contactDS.InsertCountry(new Country(1, "Jakoetsk", 891, 82, 0, "Azië"));
            contactDS.InsertCountry(new Country(1, "Afghanistan", 733, 267, 0, "Azië"));
            contactDS.InsertCountry(new Country(1, "India", 796, 379, 0, "Azië"));
            contactDS.InsertCountry(new Country(1, "China", 867, 318, 0, "Azië"));

            contactDS.InsertCountry(new Country(1, "Brazilië", 330, 475, 0, "Zuid-Amerika"));
            contactDS.InsertCountry(new Country(1, "Peru", 252, 501, 0, "Zuid-Amerika"));
            contactDS.InsertCountry(new Country(1, "Argentinië", 270, 589, 0, "Zuid-Amerika"));
            contactDS.InsertCountry(new Country(1, "Venezuela", 242, 403, 0, "Zuid-Amerika"));

            contactDS.InsertCountry(new Country(1, "West-Australië", 940, 638, 0, "Australië"));
            contactDS.InsertCountry(new Country(1, "Nieuw-Guinea", 997, 501, 0, "Australië"));
            contactDS.InsertCountry(new Country(1, "Indonesië", 900, 536, 0, "Australië"));
            contactDS.InsertCountry(new Country(1, "Oost-Australië", 1022, 600, 0, "Australië"));

            contactDS.InsertCountry(new Country(1, "Centraal-Afrika", 590, 541, 0, "Afrika"));
            contactDS.InsertCountry(new Country(1, "Zuid-Afrika", 594, 638, 0, "Afrika"));
            contactDS.InsertCountry(new Country(1, "Madagascar", 688, 641, 0, "Afrika"));
            contactDS.InsertCountry(new Country(1, "Oost-Afrika", 637, 494, 0, "Afrika"));
            contactDS.InsertCountry(new Country(1, "Egypte", 586, 415, 0, "Afrika"));
            contactDS.InsertCountry(new Country(1, "Noord-Afrika", 505, 463, 0, "Afrika"));

            //Refresh
            GetCountries();


        }


        private void UpdatePlayerIdToCountries()
        {
            int i = 0;
            foreach (Country country in Countries)
            {
                country.PlayerId = Players[i].Id;

                if (i + 1 == Players.Count)
                {
                    i = 0;
                }
                else
                {
                    i++;
                }
                CountryDataService contactDS = new CountryDataService();
                contactDS.UpdateCountry(country);
            }
        }
        private void GetCountriesJoined()
        {
            CountryDataService contactDS = new CountryDataService();
            Countries = new ObservableCollection<Country>(contactDS.GetCountriesJoined());
        }
        private void AddCountriesToPlayers()
        {
            int i = 0;
            foreach (Player player in Players)
            {

                ObservableCollection<Country> fooCollection = new ObservableCollection<Country>();
                for (int j = i; j < Countries.Count(); j += Players.Count)
                {

                    fooCollection.Add(Countries[j]);

                }
                i++;
                player.Countries = fooCollection;
            }
        }

        private void DisplayCountries()
        {
            foreach (Country country in Countries)
            {
                //DEBUG ONLY
                country.NumberOfSoldiers += 1;
                //DEBUG ONLY


                this.Add(country);
            }
        }

        public Country GetSelectedCountry(int countryId)
        {
            var selectedCountry = Countries.FirstOrDefault(s => s.Id == countryId);
            return selectedCountry;
        }
        public Player GetSelectedPlayer(int countryId)
        {
            var selectedCountry = Countries.FirstOrDefault(s => s.Id == countryId);
            var selectedPlayer = Players.FirstOrDefault(s => s.Id == selectedCountry.PlayerId);
            return selectedPlayer;
        }
        public void AddArmy(int countryId, int playerId)
        {
            var country = Countries.FirstOrDefault(s => s.Id == countryId);
            var player = Players.FirstOrDefault(s => s.Id == playerId);
            if (country != null && player != null)
            {
                country.NumberOfSoldiers += 1;
                player.AantalTroepen -= 1;
                country.NotifyPropertyChanged("numberOfSoldiers");
                player.NotifyPropertyChanged("AantalTroepen");
                GameInfo.AantalTroepenIngezet += 1;
            }
        }
        public void DeleteArmy(int countryId, int playerId)
        {
            var country = Countries.FirstOrDefault(s => s.Id == countryId);
            var player = Players.FirstOrDefault(s => s.Id == playerId);
            if (country != null && player != null)
            {
                country.NumberOfSoldiers -= 1;
                player.AantalTroepen += 1;
                country.NotifyPropertyChanged("numberOfSoldiers");
                player.NotifyPropertyChanged("AantalTroepen");
                GameInfo.AantalTroepenIngezet -= 1;
            }
        }

        public string Check()
        {
            //Kijk na of alle troepen van alle spelers zijn ingezet en elk land minstens 1 troep heeft
            foreach (Player player in Players)
            {
                if (player.AantalTroepen != 0)
                {
                    return player.ToString() + " heeft nog niet alle troepen op het bord geplaatst.";
                }
            }
            foreach (Country country in Countries)
            {
                if (country.NumberOfSoldiers == 0)
                {
                    return country.CountryName + " heeft nog geen troepen.";
                }
            }
            return null;
        }

        public int GetAantalTroepen(Player player)
        {
            //Aantal troepen die aan het begin van de ronde aan de speler worden gegeven.
            int aantal = 0;
            //Aantal troepen per beurt uit settings:
            aantal += Game.Setting.AantalTroepenPerBeurt;
            //Aantal troepen voor het aantal landen die de speler bezit.
            aantal += player.Countries.Count() / 3;
            //Aantal troepen voor volledige continenten
            aantal += CheckForFullContinents(player);
            return aantal;
        }

        private int CheckForFullContinents(Player player)
        {
            int totaal = 0;
            int Amerika = 0;
            int Europa = 0;
            int Azië = 0;
            int ZuidAmerika = 0;
            int Australië = 0;
            int Afrika = 0;
            foreach (Country country in player.Countries)
            {
                switch (country.Continent)
                {
                    case "Amerika":
                        Amerika += 1;
                        break;
                    case "Europa":
                        Europa += 1;
                        break;
                    case "Azië":
                        Azië += 1;
                        break;
                    case "Zuid-Amerika":
                        ZuidAmerika += 1;
                        break;
                    case "Australië":
                        Australië += 1;
                        break;
                    case "Afrika":
                        Afrika += 1;
                        break;
                }

            }
            if (Amerika == 9) { totaal += 5; };
            if (Europa == 7) { totaal += 5; };
            if (Azië == 12) { totaal += 7; };
            if (ZuidAmerika == 4) { totaal += 2; };
            if (Australië == 4) { totaal += 2; };
            if (Afrika == 6) { totaal += 3; };
            return totaal;
        }
        public List<Player> GetPlayersList()
        {
            List<Player> list = new List<Player>();
            foreach (Player player in Players)
            {
                list.Add(player);
            }
            return list;
        }

        public string ValAan(Country attackingCountry, Country defendingCountry)
        {
            string message;
            int aanvaldobbelstenen;
            int verdedigdobbelstenen;
            int aanvaltroepen = 0;
            int verdedigtroepen = 0;
            List<int> aanvalList = new List<int>();
            List<int> verdedigList = new List<int>();
            switch (attackingCountry.NumberOfSoldiers)
            {
                case 2:
                    aanvaldobbelstenen = 1;
                    break;
                case 3:
                    aanvaldobbelstenen = 2;
                    break;
                default:
                    aanvaldobbelstenen = 3;
                    break;
            }
            switch (defendingCountry.NumberOfSoldiers)
            {
                case 1:
                    verdedigdobbelstenen = 1;
                    break;
                default:
                    verdedigdobbelstenen = 2;
                    break;
            }
            if (aanvaldobbelstenen < verdedigdobbelstenen)
            {
                verdedigdobbelstenen = aanvaldobbelstenen;
            }
            for (int i = 0; i < aanvaldobbelstenen; i++)
            {
                aanvalList.Add(Gooi());
            }
            for (int i = 0; i < verdedigdobbelstenen; i++)
            {
                verdedigList.Add(Gooi());
            }
            var aanvalString = string.Join(", ", aanvalList);
            var verdedigString = string.Join(", ", verdedigList);
            aanvalList.Sort();
            aanvalList.Reverse();
            verdedigList.Sort();
            verdedigList.Reverse();
            for (int i = 0; i < verdedigList.Count(); i++)
            {
                if (aanvalList[i] > verdedigList[i])
                {
                    defendingCountry.NumberOfSoldiers -= 1;
                    verdedigtroepen += 1;
                    GameInfo.AantalTroepenGesneuveld += 1;
                }
                else
                {
                    attackingCountry.NumberOfSoldiers -= 1;
                    aanvaltroepen += 1;
                    GameInfo.AantalTroepenGesneuveld += 1;
                }
            }
            if (defendingCountry.NumberOfSoldiers == 0)
            {
                message = attackingCountry.Player.Name + " gooit " + aanvalString + "\n" +
                     defendingCountry.Player.Name + " gooit " + verdedigString + "\n" +
                     attackingCountry.CountryName + " -" + aanvaltroepen + ", " + defendingCountry.CountryName + " -" + verdedigtroepen + "\n" +
                     attackingCountry.CountryName + " verovert " + defendingCountry.CountryName;
                
                var aanvallerId = attackingCountry.Player.Id;
                var aanvaller = Players.FirstOrDefault(s => s.Id == aanvallerId);
                aanvaller.Countries.Add(defendingCountry);
                var verdedigerId = defendingCountry.Player.Id;
                var verdediger = Players.FirstOrDefault(s => s.Id == verdedigerId);
                verdediger.Countries.Remove(defendingCountry);

                defendingCountry.Player = attackingCountry.Player;
                defendingCountry.PlayerId = attackingCountry.PlayerId;
                defendingCountry.NumberOfSoldiers += aanvaldobbelstenen;
                attackingCountry.NumberOfSoldiers -= aanvaldobbelstenen;
                GameInfo.AantalLandenVeroverd += 1;
                return message;
            }
            message = attackingCountry.Player.Name + " gooit " + string.Join(", ", aanvalList) + "\n" +
                      defendingCountry.Player.Name + " gooit " + string.Join(", ", verdedigList) + "\n" +
                      attackingCountry.CountryName + " -" + aanvaltroepen + ", " + defendingCountry.CountryName + " -" + verdedigtroepen;
            return message;
        }

        public int Gooi()
        {
            return random.Next(1, 7);
        }
        public bool CheckWinner()
        {
            foreach(Player player in Players)
            {
                if(player.Countries.Count == 42)
                {
                    /*StopTijd = DateTime.Now;
                    TimeSpan span = StopTijd.Subtract(StartTijd);
                    var seconden = span.Seconds;
                    var minuten = span.Minutes;
                    var uren = span.Hours;
                    GameInfo.GespeeldeTijd = uren + " uur, " + minuten + " minuten en " + seconden + " seconden";
                    GameInfo.Winnaar = player;
                    Messenger.Default.Send<GameInfo>(GameInfo);*/
                    
                    return true;
                }
            }
            // DEBUGGING ONLY
            StopTijd = DateTime.Now;
            TimeSpan span = StopTijd.Subtract(StartTijd);
            var seconden = span.Seconds;
            var minuten = span.Minutes;
            var uren = span.Hours;
            GameInfo.GespeeldeTijd = uren + " uur, " + minuten + " minuten en " + seconden + " seconden";
            GameInfo.Winnaar = Players[0];
            Messenger.Default.Send<GameInfo>(GameInfo);
            return true;
            // DEBUGGING ONLY

            //return false;
        }
    }
}
