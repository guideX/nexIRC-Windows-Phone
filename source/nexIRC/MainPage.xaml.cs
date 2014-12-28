using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using nexIRC.Infrustructure;
using nexIRC.Infrustructure.Models;
namespace nexIRC {
    public partial class MainPage : PhoneApplicationPage {
        public MainPage() {
            InitializeComponent();
            DataContext = App.ViewModel;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e) {
            if (!App.ViewModel.IsDataLoaded) {
                App.ViewModel.LoadData();
            }
        }
        private void Panorama_Loaded(object sender, RoutedEventArgs e) {
        }
        private void lstNetwork_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            try {
                if (lstNetwork.SelectedItem == null) {
                    return;
                }
                var infoModel = (IrcServerInfoModel)lstNetwork.SelectedItem;
                var selector = (Microsoft.Phone.Controls.LongListSelector)sender;
                var _settings = new IrcSettings();
                _settings.QuitMessage = "nexIRC for Windows Phone team-nexgen.org";
                _settings.Nickname = "guide_X";
                _settings.Password = "";
                _settings.Username = "guideX";
                _settings.IrcServerInfoModel = new IrcServerInfoModel();
                _settings.IrcServerInfoModel.Server = infoModel.Server;
                _settings.IrcServerInfoModel.Port = infoModel.Port;
                _settings.IrcServerInfoModel.Network = infoModel.Network;
                var status = new StatusWindow(_settings);
                this.Content = status;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        private void Button_Clicked(object sender, RoutedEventArgs e) {
            //var s = sender as FrameworkElement;
            //((IrcServerInfoModel)s.DataContext).DoYourCommand();
        }
    }
}