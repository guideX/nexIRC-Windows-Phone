using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using nexIRC.Resources;
using nexIRC.Infrustructure;
using nexIRC.Infrustructure.Models;
using nexIRC.Infrustructure.Controllers;
namespace nexIRC.ViewModels {
    public class MainViewModel : INotifyPropertyChanged {
        private SettingsController _settingsController;
        public MainViewModel() {
            this.Items = new ObservableCollection<IrcServerInfoModel>();
        }
        public ObservableCollection<IrcServerInfoModel> Items { get; private set; }
        public bool IsDataLoaded {
            get;
            private set;
        }
        public void LoadData() {
            foreach (var item in _settingsController.GetIrcServerInfoModels()) {
                this.Items.Add(item);
            }
            this.IsDataLoaded = true;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}