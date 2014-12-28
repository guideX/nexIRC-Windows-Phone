﻿using System;
using Microsoft.Phone.Controls;
using nexIRC.Infrustructure.Controllers;
using nexIRC.Infrustructure.Models;
namespace nexIRC {
    public partial class StatusWindow : PhoneApplicationPage {
        private StatusModel _statusModel;
        private StatusController _statusController;
        public StatusWindow(IrcSettings settings) {
            InitializeComponent();
            _statusController = new StatusController();
            _statusModel = new StatusModel(settings, _statusController);
            _statusModel.Connect();
            //_statusModel.DataArrival += _statusModel_DataArrival;
            _statusController.SendData += _statusController_SendData;
            txtOutgoing.KeyUp += txtOutgoing_KeyUp;
            pvtStatus.Title = settings.IrcServerInfoModel.Network;
        }
        void _statusController_SendData(string data) {
            _statusModel.SendData(data);
        }
        void txtOutgoing_KeyUp(object sender, System.Windows.Input.KeyEventArgs e) {
            var controller = new StatusController();
            switch (e.Key) {
                case System.Windows.Input.Key.Enter :
                    if (txtOutgoing.Text.Length != 0) {
                        var msg = txtOutgoing.Text.Remove(0, 1);
                        txtOutgoing.Text = "";
                        controller.Status_Command(msg);
                        e.Handled = true;
                    }
                    break;
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
    }
}