using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace nexIRC.Infrustructure.Models {
    public class IrcServerInfoModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _server;
        private int _port;
        private string _network;
        /// <summary>
        /// Server
        /// </summary>
        /// <returns></returns>
        public string Server {
            get {
                return _server;
            }
            set {
                if (value != _server) {
                    _server = value;
                    NotifyPropertyChanged("Server");
                }
            }
        }
        /// <summary>
        /// Port
        /// </summary>
        /// <returns></returns>
        public int Port {
            get {
                return _port;
            }
            set {
                if (value != _port) {
                    _port = value;
                    NotifyPropertyChanged("Port");
                }
            }
        }
        /// <summary>
        /// Network Description
        /// </summary>
        /// <returns></returns>
        public string Network {
            get {
                return _network;
            }
            set {
                if (value != _network) {
                    _network = value;
                    NotifyPropertyChanged("Network");
                }
            }
        }
        private void NotifyPropertyChanged(String propertyName) {
            var handler = PropertyChanged;
            if (null != handler) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
