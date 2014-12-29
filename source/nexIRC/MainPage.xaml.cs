using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using nexIRC.Infrustructure.Helpers;
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
                var status = new StatusWindow(StatusHelper.CreateStatusWindow((IrcServerInfoModel)lstNetwork.SelectedItem));
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