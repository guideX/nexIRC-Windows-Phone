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
        private StatusModel _model;
        private StatusController _controller;
        private CommandController _commandController;
        /// <summary>
        /// Status Window Entry Point
        /// </summary>
        /// <param name="settings"></param>
        public StatusWindow(IrcSettings settings) {
            try {
                InitializeComponent();
                pvtStatus.Title = settings.IrcServerInfoModel.Network;
                txtOutgoing.KeyUp += txtOutgoing_KeyUp;
                txtRawOutgoing.KeyUp += txtRawOutgoing_KeyUp;
                _controller = new StatusController(settings);
                _controller.OnDoStatusText += _controller_OnDoStatusText;
                _controller.SendData += _controller_SendData;
                _controller.RawEvt += _controller_RawEvt;
                _controller.DisconnectedEvt += _controller_DisconnectedEvt;
                _commandController = new CommandController();
                _model = new StatusModel(settings, _controller);
                _model.Connect();
            } catch (Exception ex) {
                //MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Raw Event
        /// </summary>
        /// <param name="data"></param>
        void _controller_RawEvt(string data) {
            try {
                this.Dispatcher.BeginInvoke(new Action(() => txtRawIncoming.Text = txtRawIncoming.Text + Environment.NewLine + data));
            } catch (Exception ex) {
                //MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// On Do Status Text
        /// </summary>
        /// <param name="data"></param>
        void _controller_OnDoStatusText(string data) {
            try {
                this.Dispatcher.BeginInvoke(new Action(() => txtIncoming.Text = txtIncoming.Text + Environment.NewLine + data));
            } catch (Exception ex) {
                //MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// On Disconnected Event
        /// </summary>
        void _controller_DisconnectedEvt() {
            try {
                _model.Socket.Close();
            } catch (Exception ex) {
                //MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// SendData Event
        /// </summary>
        /// <param name="data"></param>
        void _controller_SendData(string data) {
            try {
                _model.SendData(data);
            } catch (Exception ex) {
                //MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Outgoing TextBox KeyUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void txtOutgoing_KeyUp(object sender, System.Windows.Input.KeyEventArgs e) {
            try {
                TextBox_KeyUp(sender, e);                
            } catch (Exception ex) {
                //MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Outgoing TextBox KeyUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void txtRawOutgoing_KeyUp(object sender, System.Windows.Input.KeyEventArgs e) {
            try {
                TextBox_KeyUp(sender, e);
            } catch (Exception ex) {
                //MessageBox.Show(ex.Message);
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
                //MessageBox.Show(ex.Message);
            }
        }
    }
}