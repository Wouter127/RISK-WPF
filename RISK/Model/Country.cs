using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RISK.Model
{
    class Country : BaseModel
    {
        private int id;
        private string countryName;
        private int positionLeft;
        private int positionTop;
        private int numberOfSoldiers;
        private string continent;
        private Player player;
        private int playerId;
        private Game game;
        private int gameId;


        public Country()
        {

        }
        public Country(int gameId, string countryName, int positionLeft, int positionTop, int numberOfSoldiers, string continent)
        {
            GameId = gameId;
            CountryName = countryName;
            PositionLeft = positionLeft;
            PositionTop = positionTop;
            NumberOfSoldiers = numberOfSoldiers;
            Continent = continent;
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                NotifyPropertyChanged();
            }
        }
        public int GameId
        {
            get
            {
                return gameId;
            }
            set
            {
                gameId = value;
                NotifyPropertyChanged();
            }
        }

        public string CountryName
        {
            get
            {
                return countryName;
            }
            set
            {
                countryName = value;
                NotifyPropertyChanged();
            }
        }
        public int PositionLeft
        {
            get
            {
                return positionLeft;
            }
            set
            {
                positionLeft = value;
                NotifyPropertyChanged();
            }
        }

        public int PositionTop
        {
            get
            {
                return positionTop;
            }
            set
            {
                positionTop = value;
                NotifyPropertyChanged();
            }
        }
        public int NumberOfSoldiers
        {
            get
            {
                return numberOfSoldiers;
            }
            set
            {
                numberOfSoldiers = value;
                NotifyPropertyChanged();
            }
        }
        public string Continent
        {
            get
            {
                return continent;
            }
            set
            {
                continent = value;
                NotifyPropertyChanged();
            }
        }
        public int PlayerId
        {
            get
            {
                return playerId;
            }
            set
            {
                playerId = value;
                NotifyPropertyChanged();
            }
        }
        public Player Player
        {
            get { return player; }
            set
            {
                player = value;
                NotifyPropertyChanged();
            }
        }
        public Game Game
        {
            get { return game; }
            set
            {
                game = value;
                NotifyPropertyChanged();
            }
        }

        public string Afbeelding
        {
            get
            {
                return "/Images/Landen/" + CountryName + ".jpg";
            }
        }
    }
}
