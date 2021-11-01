using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISK.Model
{
    class Game : BaseModel
    {
        private int id;
        private DateTime startTijd;
        private DateTime stopTijd;
        private int aantalTroepenGeplaatst;
        private int aantalTroepenGesneuveld;
        private int settingId;
        private Setting setting;
        private ICollection<Country> countries;
        private ICollection<Player> players;
        private string winnaar;

        public Game()
        {

        }
        public Game(int SettingId)
        {
            SettingId = settingId;
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

        public DateTime StartTijd
        {
            get
            {
                return startTijd;
            }
            set
            {
                startTijd = value;
                NotifyPropertyChanged();
            }
        }

        public DateTime StopTijd
        {
            get
            {
                return stopTijd;
            }
            set
            {
                stopTijd = value;
                NotifyPropertyChanged();
            }
        }

        public int AantalTroepenGeplaatst
        {
            get
            {
                return aantalTroepenGeplaatst;
            }
            set
            {
                aantalTroepenGeplaatst = value;
                NotifyPropertyChanged();
            }
        }
        public int AantalTroepenGesneuveld
        {
            get
            {
                return aantalTroepenGesneuveld;
            }
            set
            {
                aantalTroepenGesneuveld = value;
                NotifyPropertyChanged();
            }
        }

        public int SettingId
        {
            get { return settingId; }
            set
            {
                settingId = value;
                NotifyPropertyChanged();
            }
        }
        public Setting Setting
        {
            get { return setting; }
            set
            {
                setting = value;
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
        public ICollection<Player> Players
        {
            get { return players; }
            set
            {
                players = value;
                NotifyPropertyChanged();
            }
        }
        public string Winnaar
        {
            get
            {
                return winnaar;
            }
            set
            {
                winnaar = value;
                NotifyPropertyChanged();
            }
        }
    }
}
