using System;
using System.Windows;
using Microsoft.Phone.Controls;
using nexIRC.Infrustructure.Controllers;
using nexIRC.Infrustructure.Models;
namespace nexIRC {
    public partial class Customize : PhoneApplicationPage {
        private IrcSettings _settings;
        public Customize() {
            try {
                InitializeComponent();
                _settings = SettingsController.GetIrcSettings();
                txtNickname.Text = _settings.Nickname;
                txtAltNickname.Text = _settings.AltNickname;
                txtPassword.Text = _settings.Password;
                txtQuitMessage.Text = _settings.QuitMessage;
                txtUserName.Text = _settings.Username;
                cmdSave.Click += cmdSave_Click;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        void cmdSave_Click(object sender, RoutedEventArgs e) {
            try {
                _settings.Nickname = txtNickname.Text;
                _settings.AltNickname = txtAltNickname.Text;
                _settings.Password = txtPassword.Text;
                _settings.Username = txtUserName.Text;
                _settings.QuitMessage = txtQuitMessage.Text;
                SettingsController.SaveIrcSettings(_settings);
                NavigationService.Navigate(new Uri("/frmMainPage.xaml", UriKind.Relative));
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}