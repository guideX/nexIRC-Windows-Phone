using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using nexIRC.Infrustructure.Helpers;
using nexIRC.Infrustructure.Models;
using System.ComponentModel;
namespace nexIRC {
    public partial class MainPage : PhoneApplicationPage {
        /// <summary>
        /// Main Page Entry Point
        /// </summary>
        public MainPage() {
            try {
                InitializeComponent();
                DataContext = App.ViewModel;
                btnUser.MouseLeftButtonDown += btnUser_MouseLeftButtonDown;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Settings Mouse Left Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnUser_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            try {
                var status = new Customize();
                this.Content = status;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// On Navigated to
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e) {
            try {
                if (!App.ViewModel.IsDataLoaded) {
                    App.ViewModel.LoadData();
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        private void Panorama_Loaded(object sender, RoutedEventArgs e) {
        }
        /// <summary>
        /// lstNetwork Selected Index Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
    }
}