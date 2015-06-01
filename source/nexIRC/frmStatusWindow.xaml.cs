using System;
using Microsoft.Phone.Controls;
using nexIRC.Infrustructure.Controllers;
using nexIRC.Infrustructure.Models;
using Windows.Phone.UI.Input;
using System.Windows;
using Windows.UI.Core;
namespace nexIRC {
    /// <summary>
    /// Status Window
    /// </summary>
    public partial class StatusWindow : PhoneApplicationPage {
        #region "private variables"
        private int _statusIndex;
        private GlobalObject _obj;
        #endregion
        /// <summary>
        /// Status Window Entry Point
        /// </summary>
        /// <param name="settings"></param>
        public StatusWindow(GlobalObject obj, IrcServerInfoModel ircInfo) {
            try {
                InitializeComponent();
                var userSettings = UserSettingsController.GetUserSettingsModel();
                if (obj == null) {
                    _obj = new GlobalObject();
                } else {
                    _obj = obj;
                }
                _statusIndex = _obj.GetId(userSettings, ircInfo);
                if (_statusIndex == -1) {
                    _statusIndex = _obj.Create(userSettings, ircInfo);
                }
                pvtStatus.Title = ircInfo.Network;
                WindUp();
                lblServer.Text = "Server: " + ircInfo.Server;
                lblNickname.Text = "Nickname: " + userSettings.Nickname;
                if (_obj.IsConnected(_statusIndex)) {
                    lblConnectionStatus.Text = "Connection Information: Connected";
                } else {
                    lblConnectionStatus.Text = "Connection Information: Not Connected";
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        void _obj_ConnectedEvent(int id) {
            if (_statusIndex == id) {
                this.Dispatcher.BeginInvoke(new Action(() => cmdConnect.IsEnabled = false));
                this.Dispatcher.BeginInvoke(new Action(() => cmdDisconnect.IsEnabled = true));
            }
        }
        private void pvtStatus_Loaded(object sender, EventArgs e) {
        }
        /// <summary>
        /// go back
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdGoBack_Click(object sender, RoutedEventArgs e) {
            try {
                var mainPage = new MainPage();
                mainPage.Obj = _obj;
                this.Content = mainPage;
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Connected Event
        /// </summary>
        private void _model_ConnectedEvent() {
            try {
                this.Dispatcher.BeginInvoke(new Action(() => OnConnected() ));
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// On Connected Void
        /// </summary>
        private void OnConnected() {
            try {
                cmdConnect.IsEnabled = false;
                cmdDisconnect.IsEnabled = true;
                lblConnectionStatus.Text = "Connection Information: Connected.";
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Disconnect Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDisconnect_Click(object sender, RoutedEventArgs e) {
            try {
                cmdConnect.IsEnabled = true;
                cmdDisconnect.IsEnabled = false;
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// When connect button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdConnect_Click(object sender, RoutedEventArgs e) {
            try {
                cmdConnect.IsEnabled = false;
                lblConnectionStatus.Text = "Connection Information: Connecting to server ... ";
                _obj.Connect(_statusIndex);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// On Status Caption
        /// </summary>
        /// <param name="data"></param>
        //private void _controller_OnStatusCaption(string data) {
            //try {
                //this.Dispatcher.BeginInvoke(new Action(() => pvtStatus.Title = data ));
            //} catch (Exception ex) {
                //throw ex;
            //}
        //}
        /// <summary>
        /// Raw Incoming TextChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRawIncoming_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e) {
            try {
                txtRawIncoming.SelectionStart = int.MaxValue;
                txtRawIncoming.SelectionLength = 0;
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Incoming Text Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtIncoming_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e) {
            try {
                txtIncoming.SelectionStart = int.MaxValue;
                txtIncoming.SelectionLength = 0;
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Raw Event
        /// </summary>
        /// <param name="data"></param>
        private void _controller_RawEvt(string data) {
            try {
                TextBoxText(txtRawIncoming, data);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// On Do Status Text
        /// </summary>
        /// <param name="data"></param>
        private void _controller_OnDoStatusText(string data) {
            try {
                 TextBoxText(txtIncoming, data);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// On Disconnected Event
        /// </summary>
        private void _controller_DisconnectedEvt() {
            try {
                this.Dispatcher.BeginInvoke(new Action(() => _obj.Disconnect(_statusIndex)));
                this.Dispatcher.BeginInvoke(new Action(() => cmdConnect.IsEnabled = true));
                this.Dispatcher.BeginInvoke(new Action(() => cmdDisconnect.IsEnabled = false));
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// SendData Event
        /// </summary>
        /// <param name="data"></param>
        private void _controller_SendData(string data) {
            try {
                this.Dispatcher.BeginInvoke(new Action(() => _obj.SendData(_statusIndex, data)));
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Outgoing TextBox KeyUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOutgoing_KeyUp(object sender, System.Windows.Input.KeyEventArgs e) {
            try {
                TextBox_KeyUp(sender, e);                
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Outgoing TextBox KeyUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRawOutgoing_KeyUp(object sender, System.Windows.Input.KeyEventArgs e) {
            try {
                TextBox_KeyUp(sender, e);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// TextBox KeyUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e) {
            try {
                switch (e.Key) {
                    case System.Windows.Input.Key.Enter:
                        if (txtOutgoing.Text.Length != 0) {
                            var msg = txtOutgoing.Text.Remove(0, 1);
                            txtOutgoing.Text = "";
                            _obj.CommandController(_statusIndex).StatusCommand(msg);
                            e.Handled = true;
                        }
                        break;
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Add Text to a TextBox
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="data"></param>
        private void TextBoxText(System.Windows.Controls.TextBox textBox, string data) {
            try {
                this.Dispatcher.BeginInvoke(new Action(() => textBox.Text = textBox.Text + Environment.NewLine + data));
            } catch (Exception ex) {
                throw ex;
            }
        }
        //public void ShowMainPage() {
            //var mainPage = new MainPage();
            //mainPage.Obj = _obj;
            //this.Content = mainPage;
        //}
        /// <summary>
        /// Wind Up
        /// </summary>
        private void WindUp() {
            try {
                txtIncoming.TextChanged += txtIncoming_TextChanged;
                txtOutgoing.KeyUp += txtOutgoing_KeyUp;
                txtRawIncoming.TextChanged += txtRawIncoming_TextChanged;
                txtRawOutgoing.KeyUp += txtRawOutgoing_KeyUp;
                cmdConnect.Click += cmdConnect_Click;
                cmdDisconnect.Click += cmdDisconnect_Click;
                cmdGoBack.Click += cmdGoBack_Click;
                _obj.Controller(_statusIndex).OnDoStatusText += _controller_OnDoStatusText;
                _obj.Controller(_statusIndex).SendData += _controller_SendData;
                _obj.Controller(_statusIndex).RawEvt += _controller_RawEvt;
                _obj.Controller(_statusIndex).DisconnectedEvt += _controller_DisconnectedEvt;
                //_obj.Controller(_statusIndex).OnStatusCaption += _controller_OnStatusCaption;
                _obj.ConnectedEvent += _obj_ConnectedEvent;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}