using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nexIRC.Infrustructure.Controllers;
/*
namespace nexIRC.Infrustructure.Models {
    public class StatusModel {
        public delegate void OnConnectedEvent();
        public event OnConnectedEvent ConnectedEvent;
        public SocketController Socket { get; set; }
        //private UserSettingsModel _userSettings { get; set; }
        //private StatusController _controller;
        /// <summary>
        /// Status Model Entry Point
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="controller"></param>
        public StatusModel(UserSettingsModel userSettings, StatusController controller) {
            try {
                //_controller = controller;
                //_userSettings = userSettings;
                //Socket = new SocketController(_userSettings.IrcServerInfoModel);
                Socket = new SocketController();
                Socket.DataArrival += Socket_DataArrival;
                Socket.ConnectedEvt += Socket_ConnectedEvt;
                //Socket.DisconnectedEvt += Socket_DisconnectedEvt;
                //_controller.RawEvt += _controller_RawEvt;
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Disconnect event for future implementation
        /// </summary>
        //private void Socket_DisconnectedEvt() {
            //try {
                // Doesn't work anyways
            //} catch (Exception ex) {
                //throw ex;
            //}
        //}
        /// <summary>
        /// Collect Raw Data
        /// </summary>
        /// <param name="data"></param>
        /// <summary>
        /// Connected Event
        /// </summary>
        void Socket_ConnectedEvt() {
            try {
                _controller.SendIdentity(_userSettings);
                if (ConnectedEvent != null) {
                    ConnectedEvent();
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Socket DataArrival
        /// </summary>
        /// <param name="data"></param>
        void Socket_DataArrival(string data) {
            if (!string.IsNullOrEmpty(data)) {
                _controller.Status_DataArrival(data);
                //if (DataArrival != null) {
                //DataArrival(data);
                //}
            }
        }
        /// <summary>
        /// Connect Function
        /// </summary>
        public void Connect() {
            try {
                var task = Task.Run(async () => { await Socket.Connect(); });
                task.Wait();
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Send Data
        /// </summary>
        /// <param name="data"></param>
        public void SendData(string data) {
            try {
                Socket.SendData(data);
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
*/