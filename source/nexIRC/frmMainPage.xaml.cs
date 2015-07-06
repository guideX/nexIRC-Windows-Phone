using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using nexIRC.Infrustructure.Helpers;
using nexIRC.Infrustructure.Models;
using System.ComponentModel;
using nexIRC.Infrustructure.Controllers;
using System.IO.IsolatedStorage;
namespace nexIRC {
    public partial class MainPage : PhoneApplicationPage {
        private GlobalObject _obj;
        /// <summary>
        /// Main Page Entry Point
        /// </summary>
        public GlobalObject Obj {
            set {
                _obj = value;
            }
        }
        public MainPage() {
            try {
                _obj = new GlobalObject();
                InitializeComponent();
                DataContext = App.ViewModel;
                //btnUser.MouseLeftButtonDown += btnUser_MouseLeftButtonDown;
                tblLogin.MouseLeftButtonDown += tblLogin_MouseLeftButtonDown;
                var emailAddress = "";
                var password = "";
                if (IsolatedStorageSettings.ApplicationSettings.Contains("email_address")) {
                    emailAddress = (string)IsolatedStorageSettings.ApplicationSettings["email_address"];
                }
                if (IsolatedStorageSettings.ApplicationSettings.Contains("password")) {
                    password = (string)IsolatedStorageSettings.ApplicationSettings["password"];
                }
                if (!string.IsNullOrEmpty(emailAddress) && !string.IsNullOrEmpty(password)) {
                    UsersHelper.Authenticate(emailAddress, password);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdLogin_Click(object sender, System.Windows.Input.MouseButtonEventArgs e) {

        }

        private void tblLogin_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            var login = new Login();
            this.Content = login;
        }



        /// <summary>
        /// Settings Mouse Left Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //void btnUser_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            //try {
                //var status = new Customize(_obj);
                //this.Content = status;
            //} catch (Exception ex) {
                //MessageBox.Show(ex.Message);
            //}
        //}
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
                if (lstNetwork.SelectedItem == null) { return; }
                this.Content = new StatusWindow(_obj, (IrcServerInfoModel)lstNetwork.SelectedItem);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}