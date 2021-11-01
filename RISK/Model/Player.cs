using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISK.Model
{
    class Player : BaseModel
    {
        private int id;
        private string name;
        private string color;
        private int stars;
        private int aantalTroepen;
        private ICollection<Country> countries;
        private Game game;
        private int gameId;

        public Player()
        {

        }

        public Player(int id, string name, string color, int stars, int aantalTroepen, int gameId)
        {
            Id = id;
            Name = name;
            Color = color;
            Stars = stars;
            AantalTroepen = aantalTroepen;
            GameId = gameId;
        }

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                NotifyPropertyChanged();
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged();
            }
        }
        public string Color
        {
            get { return color; }
            set
            {
                color = value;
                NotifyPropertyChanged();
            }
        }
        public int Stars
        {
            get { return stars; }
            set
            {
                stars = value;
                NotifyPropertyChanged();
            }
        }
        public int AantalTroepen
        {
            get { return aantalTroepen; }
            set
            {
                aantalTroepen = value;
                NotifyPropertyChanged();
            }
        }

        public ICollection<Country> Countries
        {
            get { return countries; }
            set
            {
                countries = value;
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

        public int GameId
        {
            get { return gameId; }
            set
            {
                gameId = value;
                NotifyPropertyChanged();
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
