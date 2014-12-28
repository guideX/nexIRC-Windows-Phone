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
using nexIRC.Infrustructure.Controllers;
namespace nexIRC {
    public partial class MainPage : PhoneApplicationPage {
        private StatusController _controller = new StatusController();
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
                var status = new StatusWindow(_controller.CreateStatusWindow((IrcServerInfoModel)lstNetwork.SelectedItem));
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