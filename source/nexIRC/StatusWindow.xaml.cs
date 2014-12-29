using System;
using Microsoft.Phone.Controls;
using nexIRC.Infrustructure.Controllers;
using nexIRC.Infrustructure.Models;
using Windows.Phone.UI.Input;
using System.Windows;
namespace nexIRC {
    public partial class StatusWindow : PhoneApplicationPage {
        private StatusModel _model;
        private StatusController _controller;
        public StatusWindow(IrcSettings settings) {
            try {
                InitializeComponent();
                _controller = new StatusController(settings);
                _model = new StatusModel(settings, _controller);
                _model.Connect();
                //_statusModel.DataArrival += _statusModel_DataArrival;
                _controller.SendData += _statusController_SendData;
                _controller.DisconnectedEvt += _controller_DisconnectedEvt;
                txtOutgoing.KeyUp += txtOutgoing_KeyUp;
                _controller.OnDoStatusText += _controller_OnDoStatusText;
                pvtStatus.Title = settings.IrcServerInfoModel.Network;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        void _controller_OnDoStatusText(string data) {
            try {
                this.Dispatcher.BeginInvoke(new Action(() => txtIncoming.Text = txtIncoming.Text + Environment.NewLine + data));
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        void _controller_DisconnectedEvt() {
            try {
                _model.Socket.Close();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        void _statusController_SendData(string data) {
            try {
                _model.SendData(data);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        void txtOutgoing_KeyUp(object sender, System.Windows.Input.KeyEventArgs e) {
            try {
                switch (e.Key) {
                    case System.Windows.Input.Key.Enter:
                        if (txtOutgoing.Text.Length != 0) {
                            var msg = txtOutgoing.Text.Remove(0, 1);
                            txtOutgoing.Text = "";
                            _controller.Status_Command(msg);
                            e.Handled = true;
                        }
                        break;
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        //void _statusModel_DataArrival(string data) {
            //try {
                //var controller = new StatusController();
                //controller.Status_DataArrival(data);
                //this.Dispatcher.BeginInvoke(new Action(() => txtIncoming.Text = txtIncoming.Text + Environment.NewLine + data));
            //} catch (Exception ex) {
                //throw ex;
            //}
        //}
        //private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e) {
            //e.Handled = true;
        //}
    }
}