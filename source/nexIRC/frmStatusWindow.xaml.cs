﻿using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Phone.Controls;
using Windows.Phone.UI.Input;
using Windows.UI.Core;
using Windows.Storage.Streams;
using nexIRC.ViewModels;
using nexIRC.Infrustructure.Controllers;
using nexIRC.Infrustructure.Models;
namespace nexIRC {
    /// <summary>
    /// Status Window
    /// </summary>
    public partial class StatusWindow : PhoneApplicationPage {
        #region "private variables"
        private StatusWindowViewModel _viewModel;
        #endregion
        /// <summary>
        /// Status Window Entry Point
        /// </summary>
        /// <param name="settings"></param>
        public StatusWindow(GlobalObject obj, IrcServerInfoModel ircInfo) {
            try {
                InitializeComponent();
                _viewModel = new StatusWindowViewModel();
                var userSettings = UserSettingsController.GetUserSettingsModel();
                if (obj == null) {
                    _viewModel.Obj = new GlobalObject();
                } else {
                    _viewModel.Obj = obj;
                }
                _viewModel.StatusIndex = _viewModel.Obj.GetId(userSettings, ircInfo);
                if (_viewModel.StatusIndex == -1) {
                    _viewModel.StatusIndex = _viewModel.Obj.Create(userSettings, ircInfo);
                } else {
                    txtIncoming.Text = _viewModel.Obj.StatusTextBackup(_viewModel.StatusIndex).ToString();
                    txtRawIncoming.Text = _viewModel.Obj.RawTextBackup(_viewModel.StatusIndex).ToString();
                }
                var bitmapImage = new BitmapImage();
                bitmapImage.UriSource = new Uri("ms-appx:" + ircInfo.ImagePath);
                imgNetwork.Source = bitmapImage;
                pvtStatus.Title = ircInfo.Network;
                WindUp();
                lblServer.Text = "Server: " + ircInfo.Server;
                lblNickname.Text = "Nickname: " + userSettings.Nickname;
                if (_viewModel.Obj.IsConnected(_viewModel.StatusIndex)) {
                    cmdDisconnect.IsEnabled = true;
                    cmdConnect.IsEnabled = false;
                    lblConnectionStatus.Text = "Connection Information: Connected";
                } else {
                    cmdDisconnect.IsEnabled = false;
                    cmdConnect.IsEnabled = true;
                    lblConnectionStatus.Text = "Connection Information: Not Connected";
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Connected Event
        /// </summary>
        /// <param name="id"></param>
        private void _obj_ConnectedEvent(int id) {
            if (_viewModel.StatusIndex == id) {
                this.Dispatcher.BeginInvoke(new Action(() => cmdConnect.IsEnabled = false));
                this.Dispatcher.BeginInvoke(new Action(() => cmdDisconnect.IsEnabled = true));
                this.Dispatcher.BeginInvoke(new Action(() => lblConnectionStatus.Text = "Connection Information: Connected"));
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
                mainPage.Obj = _viewModel.Obj;
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
                _viewModel.Obj.Connect(_viewModel.StatusIndex);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
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
        /// On Disconnected Event
        /// </summary>
        private void _controller_DisconnectedEvt() {
            try {
                this.Dispatcher.BeginInvoke(new Action(() => _viewModel.Obj.Disconnect(_viewModel.StatusIndex)));
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
                this.Dispatcher.BeginInvoke(new Action(() => _viewModel.Obj.SendData(_viewModel.StatusIndex, data)));
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
                            _viewModel.Obj.CommandController(_viewModel.StatusIndex).StatusCommand(msg);
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
                _viewModel.Obj.Controller(_viewModel.StatusIndex).SendData += _controller_SendData;
                _viewModel.Obj.Controller(_viewModel.StatusIndex).RawEvt += _controller_RawEvt;
                _viewModel.Obj.Controller(_viewModel.StatusIndex).DisconnectedEvt += _controller_DisconnectedEvt;
                _viewModel.Obj.ConnectedEvent += _obj_ConnectedEvent;
                _viewModel.Obj.OnDoStatusText += Obj_OnDoStatusText;
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// On Do Status Text
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        private void Obj_OnDoStatusText(int id, string data) {
            try {
                TextBoxText(txtIncoming, data);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}