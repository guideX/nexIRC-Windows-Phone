using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nexIRC.Infrustructure.Controllers;
namespace nexIRC.Infrustructure.Models {
    public class StatusModel {
        //public delegate void DataArrivalEvent(string data);
        //public event DataArrivalEvent DataArrival;
        public SocketController Socket { get; set; }
        private IrcSettings _settings { get; set; }
        private StatusController _controller;
        /// <summary>
        /// Status Model Entry Point
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="controller"></param>
        public StatusModel(IrcSettings settings, StatusController controller) {
            try {
                _controller = controller;
                _settings = settings;
                Socket = new SocketController(settings.IrcServerInfoModel);
                Socket.DataArrival += Socket_DataArrival;
                Socket.ConnectedEvt += Socket_ConnectedEvt;
                _controller.RawEvt += _controller_RawEvt;
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Collect Raw Data
        /// </summary>
        /// <param name="data"></param>
        void _controller_RawEvt(string data) {
            try {
                _settings.RawText.Add(data);
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Connected Event
        /// </summary>
        void Socket_ConnectedEvt() {
            try {
                _controller.SendIdentity(_settings);
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