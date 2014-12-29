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
                try {
                    if (!string.IsNullOrEmpty(_server)) {
                        return _server;
                    } else {
                        return "";
                    }
                } catch (Exception ex) {
                    throw ex;
                }
            }
            set {
                try {
                    if (value != _server) {
                        _server = value;
                        NotifyPropertyChanged("Server");
                    }
                } catch (Exception ex) {
                    throw ex;
                }
            }
        }
        /// <summary>
        /// Port
        /// </summary>
        /// <returns></returns>
        public int Port {
            get {
                try {
                    return _port;
                } catch (Exception ex) {
                    throw ex;
                }
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
                try {
                    if (!string.IsNullOrEmpty(_network)) {
                        return _network;
                    } else {
                        return "";
                    }
                } catch (Exception ex) {
                    throw ex;
                }
            }
            set {
                try {
                    if (value != _network) {
                        _network = value;
                        NotifyPropertyChanged("Network");
                    }
                } catch (Exception ex) {
                    throw ex;
                }
            }
        }
        private void NotifyPropertyChanged(String propertyName) {
            try {
                var handler = PropertyChanged;
                if (null != handler) {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
