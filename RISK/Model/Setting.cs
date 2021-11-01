using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISK.Model
{
    class Setting : BaseModel
    {
        private int id;
        private int aantalRondes;
        private int geluidBool;
        private int aantalStartTroepen;
        private int aantalTroepenPerBeurt;
        private ICollection<Game> games;
        public Setting()
        {

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
        public int AantalRondes
        {
            get
            {
                return aantalRondes;
            }
            set
            {
                aantalRondes = value;
                NotifyPropertyChanged();
            }
        }
        public int GeluidBool
        {
            get
            {
                return geluidBool;
            }
            set
            {
                geluidBool = value;
                NotifyPropertyChanged();
            }
        }
        public int AantalStartTroepen
        {
            get
            {
                return aantalStartTroepen;
            }
            set
            {
                aantalStartTroepen = value;
                NotifyPropertyChanged();
            }
        }
        public int AantalTroepenPerBeurt
        {
            get
            {
                return aantalTroepenPerBeurt;
            }
            set
            {
                aantalTroepenPerBeurt = value;
                NotifyPropertyChanged();
            }
        }
        public ICollection<Game> Games
        {
            get { return games; }
            set
            {
                games = value;
                NotifyPropertyChanged();
            }
        }
    }
}
