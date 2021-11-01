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
    class ChangeSettingsViewModel : BaseViewModel
    {
        public ChangeSettingsViewModel()
        {
            LeesSettings();
            KoppelenCommands();
        }



        private ObservableCollection<Setting> settings;
        public ObservableCollection<Setting> Settings
        {
            get { return settings; }
            set
            {
                settings = value;
                NotifyPropertyChanged();
            }
        }
        private Setting selectedSetting;
        public Setting SelectedSetting
        {
            get
            {
                if (selectedSetting == null)
                {
                    selectedSetting = new Setting();
                }
                return selectedSetting;
            }
            set
            {
                selectedSetting = value;
                NotifyPropertyChanged();
            }
        }

        private void LeesSettings()
        {
            // instantiëren dataservice
            SettingDataService contactDS = new SettingDataService();
            Settings = new ObservableCollection<Setting>(contactDS.GetSettings());
        }

        private void KoppelenCommands()
        {
            WijzigenCommand = new BaseCommand(WijzigenSettings);
            NavigateToSplashScreenCommand = new BaseCommand(NavigateToSplashScreen);
        }
        public ICommand WijzigenCommand { get; set; }
        public ICommand NavigateToSplashScreenCommand { get; set; }

        private void WijzigenSettings()
        {
            if (SelectedSetting != null)
            {
                SettingDataService contactDS = new SettingDataService();
                contactDS.UpdateSettings(SelectedSetting);

                //sluit window
                NavigateToSplashScreen();
            }
        }
        public void NavigateToSplashScreen()
        {
            Messenger.Default.Send<CloseViewsMessage>(new CloseViewsMessage());
        }

    }
}
