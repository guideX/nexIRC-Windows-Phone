using System;
using System.Windows;
using Microsoft.Phone.Controls;
using nexIRC.Infrustructure.Controllers;
using nexIRC.Infrustructure.Models;
namespace nexIRC {
    public partial class Customize : PhoneApplicationPage {
        //private UserSettingsModel _userSettings;
        //private GlobalObject _obj;
        /// <summary>
        /// Customize
        /// </summary>
        /// <param name="obj"></param>
        public Customize(GlobalObject obj) {
            try {
                //if (obj == null) {
                    //_obj = new GlobalObject();
                //} else {
                    //_obj = obj;
                //}
                //InitializeComponent();
                //_userSettings = UserSettingsController.GetUserSettingsModel();
                //txtNickname.Text = _userSettings.Nickname;
                //txtAltNickname.Text = _userSettings.AltNickname;
                //txtPassword.Text = _userSettings.Password;
                //txtQuitMessage.Text = _userSettings.QuitMessage;
                //txtUserName.Text = _userSettings.Username;
                //cmdSave.Click += cmdSave_Click;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Save 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void cmdSave_Click(object sender, RoutedEventArgs e) {
            try {
                //_userSettings.Nickname = txtNickname.Text;
                //_userSettings.AltNickname = txtAltNickname.Text;
                //_userSettings.Password = txtPassword.Text;
                //_userSettings.Username = txtUserName.Text;
                //_userSettings.QuitMessage = txtQuitMessage.Text;
                //UserSettingsController.SaveUserSettings(_userSettings);
                //var mainPage = new MainPage();
                //mainPage.Obj = _obj;
                //this.Content = mainPage;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}