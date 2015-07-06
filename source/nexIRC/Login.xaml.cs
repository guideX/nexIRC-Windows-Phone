using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
namespace nexIRC {
    public partial class Login : PhoneApplicationPage {
        private string _emailAddress { get; set; }
        private string _password { get; set; }
        public Login() {
            InitializeComponent();
            if (IsolatedStorageSettings.ApplicationSettings.Contains("email_address")) {
                txtEmailAddress.Text = (string)IsolatedStorageSettings.ApplicationSettings["email_address"];
            }
            if (IsolatedStorageSettings.ApplicationSettings.Contains("password")) {
                txtPassword.Password = (string)IsolatedStorageSettings.ApplicationSettings["password"];
            }
        }
        private void cmdLogin_Click(object sender, RoutedEventArgs e) {
            try {
                IsolatedStorageSettings.ApplicationSettings["email_address"] = txtEmailAddress.Text;
                IsolatedStorageSettings.ApplicationSettings["password"] = txtPassword.Password;
                var mainPage = new MainPage();
                this.Content = mainPage;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}