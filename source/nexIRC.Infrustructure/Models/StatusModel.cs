using nexIRC.Infrustructure.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nexIRC.Infrustructure.Models {
    public class StatusModel {
        public delegate void DataArrivalEvent(string data);
        public event DataArrivalEvent DataArrival;
        public string Server { get; set; }
        public string Network { get; set; }
        public int Port { get; set; }
        public SocketController Socket { get; set; }
        private IrcSettings _settings { get; set; }
        public StatusModel(IrcSettings settings) {
            try {
                _settings = settings;
                Socket = new SocketController(settings);
                Socket.DataArrival += Socket_DataArrival;
                Socket.ConnectedEvt += Socket_ConnectedEvt;
            } catch (Exception ex) {
                throw ex;
            }
        }
        void Socket_ConnectedEvt() {
            try {
                var controller = new StatusController();
                controller.SendIdentity(_settings);
            } catch (Exception ex) {
                throw ex;
            }
        }
        void Socket_DataArrival(string data) {
            if (!string.IsNullOrEmpty(data)) {
                if (DataArrival != null) {
                    DataArrival(data);
                }
            }
        }
        public void Connect() {
            var task = Task.Run(async () => { await Socket.Connect(); });
            task.Wait();
        }
        public void SendData(string data) {
            Socket.SendData(data);
        }
    }
}
