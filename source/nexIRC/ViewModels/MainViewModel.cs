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
            //this.Items.Add(new IrcServerInfoModel() { Server = "irc.freenode.org", Port = 6667, Network = "Freenode", ImagePath = "/Assets/freenode.jpg" });
            //this.Items.Add(new IrcServerInfoModel() { Server = "us.undernet.org", Port = 6667, Network = "Undernet" });
            //this.Items.Add(new IrcServerInfoModel() { Server = "irc.gamesurge.net", Port = 6667, Network = "GameSurge" });
            //this.Items.Add(new IrcServerInfoModel() { Server = "irc.rizon.net", Port = 6667, Network = "Rizon" });
            //this.Items.Add(new IrcServerInfoModel() { Server = "irc.dal.net", Port = 6667, Network = "DALnet" });
            //this.Items.Add(new IrcServerInfoModel() { Server = "irc.quakenet.org", Port = 6667, Network = "Quakenet" });
            //this.Items.Add(new IrcServerInfoModel() { Server = "irc.efnet.org", Port = 6667, Network = "EFnet" });
            foreach (var item in SettingsController.GetIrcServerInfoModels()) {
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