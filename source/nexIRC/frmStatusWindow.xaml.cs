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
        private StatusModel _model;
        private StatusController _controller;
        private CommandController _commandController;
        #endregion
        /// <summary>
        /// Status Window Entry Point
        /// </summary>
        /// <param name="settings"></param>
        public StatusWindow(IrcSettings settings) {
            try {
                InitializeComponent();
                pvtStatus.Title = settings.IrcServerInfoModel.Network;
                txtIncoming.TextChanged += txtIncoming_TextChanged;
                txtOutgoing.KeyUp += txtOutgoing_KeyUp;
                txtRawIncoming.TextChanged += txtRawIncoming_TextChanged;
                txtRawOutgoing.KeyUp += txtRawOutgoing_KeyUp;
                cmdConnect.Click += cmdConnect_Click;
                cmdDisconnect.Click += cmdDisconnect_Click;
                cmdGoBack.Click += cmdGoBack_Click;
                _commandController = new CommandController();
                _controller = new StatusController(settings);
                _controller.OnDoStatusText += _controller_OnDoStatusText;
                _controller.SendData += _controller_SendData;
                _controller.RawEvt += _controller_RawEvt;
                _controller.DisconnectedEvt += _controller_DisconnectedEvt;
                _controller.OnStatusCaption += _controller_OnStatusCaption;
                _model = new StatusModel(settings, _controller);
                _model.ConnectedEvent += _model_ConnectedEvent;
                lblServer.Text = "Server: " + settings.IrcServerInfoModel.Server;
                lblNickname.Text = "Nickname: " + settings.Nickname;
                lblConnectionStatus.Text = "Connection Information: Not Connected";
                //_model.Connect();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// go back
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdGoBack_Click(object sender, RoutedEventArgs e) {
            try {

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
                _model.Connect();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// On Status Caption
        /// </summary>
        /// <param name="data"></param>
        private void _controller_OnStatusCaption(string data) {
            try {
                this.Dispatcher.BeginInvoke(new Action(() => pvtStatus.Title = data ));
            } catch (Exception ex) {
                throw ex;
            }
        }
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
                this.Dispatcher.BeginInvoke(new Action(() => _model.Socket.Close()));
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
                this.Dispatcher.BeginInvoke(new Action(() => _model.SendData(data)));
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
                            _commandController.StatusCommand(msg);
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
    }
}