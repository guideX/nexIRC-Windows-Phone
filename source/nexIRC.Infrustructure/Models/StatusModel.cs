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
        public StatusModel(IrcSettings settings, StatusController controller) {
            try {
                _controller = controller;
                _settings = settings;
                Socket = new SocketController(settings.IrcServerInfoModel);
                Socket.DataArrival += Socket_DataArrival;
                Socket.ConnectedEvt += Socket_ConnectedEvt;
            } catch (Exception ex) {
                throw ex;
            }
        }
        void Socket_ConnectedEvt() {
            try {
                _controller.SendIdentity(_settings);
            } catch (Exception ex) {
                throw ex;
            }
        }
        void Socket_DataArrival(string data) {
            if (!string.IsNullOrEmpty(data)) {
                _controller.Status_DataArrival(data);
                //if (DataArrival != null) {
                    //DataArrival(data);
                //}
            }
        }
        public void Connect() {
            try {
                var task = Task.Run(async () => { await Socket.Connect(); });
                task.Wait();
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void SendData(string data) {
            try {
                Socket.SendData(data);
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}