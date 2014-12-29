using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using nexIRC.Infrustructure.Models;

namespace nexIRC {
    public partial class Customize : PhoneApplicationPage {
        private IrcSettings _settings;
        public Customize(IrcSettings settings) {
            InitializeComponent();
            _settings = settings;
            txtNickname.Text = _settings.Nickname;
            txtAltNickname.Text = _settings.AltNickname;
            txtPassword.Text = _settings.Password;
            txtQuitMessage.Text = _settings.QuitMessage;
            txtUserName.Text = _settings.Username;
            cmdSave.Click += cmdSave_Click;
        }
        void cmdSave_Click(object sender, RoutedEventArgs e) {
            _settings.Nickname = txtNickname.Text;
            _settings.AltNickname = txtAltNickname.Text;
            _settings.Password = txtPassword.Text;
            _settings.Username = txtUserName.Text;
            _settings.QuitMessage = txtQuitMessage.Text;
        }
    }
}