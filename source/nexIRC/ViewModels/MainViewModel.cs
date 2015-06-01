using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using nexIRC.Resources;
using nexIRC.Infrustructure;
using nexIRC.Infrustructure.Models;
using nexIRC.Infrustructure.Controllers;
namespace nexIRC.ViewModels {
    public class MainViewModel : INotifyPropertyChanged {
        public ObservableCollection<IrcServerInfoModel> Items { get; private set; }
        public MainViewModel() {
            this.Items = new ObservableCollection<IrcServerInfoModel>();
        }
        public bool IsDataLoaded { get; private set; }
        public void LoadData() {
            foreach (var item in UserSettingsController.GetIrcServerInfoModels()) {
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