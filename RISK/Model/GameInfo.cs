using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISK.Model
{
    class GameInfo : BaseModel
    {
        private string gespeeldeTijd;
        private int aantalTroepenIngezet;
        private int aantalTroepenGesneuveld;
        private int aantalLandenVeroverd;
        private Player winnaar;
        public GameInfo()
        {

        }

        public string GespeeldeTijd
        {
            get
            {
                return gespeeldeTijd;
            }
            set
            {
                gespeeldeTijd = value;
                NotifyPropertyChanged();
            }
        }
        public int AantalTroepenIngezet
        {
            get
            {
                return aantalTroepenIngezet;
            }
            set
            {
                aantalTroepenIngezet = value;
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
        public int AantalLandenVeroverd
        {
            get
            {
                return aantalLandenVeroverd;
            }
            set
            {
                aantalLandenVeroverd = value;
                NotifyPropertyChanged();
            }
        }
        public Player Winnaar
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
