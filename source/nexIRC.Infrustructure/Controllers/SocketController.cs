using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
using nexIRC.Infrustructure.Models;
using System.Windows;
namespace nexIRC.Infrustructure.Controllers {
    public class SocketController {
        #region "events"
        /// <summary>
        /// Data Arrival Event
        /// </summary>
        /// <param name="data"></param>
        public delegate void DataArrivalEvent(string data);
        /// <summary>
        /// Data Arrival Event
        /// </summary>
        public event DataArrivalEvent DataArrival;
        /// <summary>
        /// Connected Event
        /// </summary>
        public delegate void ConnectedEvent();
        /// <summary>
        /// Connected Evt
        /// </summary>
        public event ConnectedEvent ConnectedEvt;
        /// <summary>
        /// Disconnected Evt
        /// </summary>
        public delegate void DisconnectedEvent();
        /// <summary>
        /// Disconnected Event
        /// </summary>
        public event DisconnectedEvent DisconnectedEvt;
        #endregion
        #region "public properties"
        /// <summary>
        /// Closing
        /// </summary>
        public bool Closing { get; set; }
        /// <summary>
        /// Connecting
        /// </summary>
        public bool Connecting { get; set; }
        /// <summary>
        /// Connected
        /// </summary>
        public bool Connected { get; set; }
        #endregion
        #region "private properties"
        /// <summary>
        /// Client Socket
        /// </summary>
        private readonly StreamSocket _clientSocket;
        /// <summary>
        /// Data Reader
        /// </summary>
        private DataReader _dataReader;
        #endregion
        /// <summary>
        /// Entry Point
        /// </summary>
        /// <param name="settings"></param>
        public SocketController() {
            try {
                Connecting = true;
                _clientSocket = new StreamSocket();
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Connect Function
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Connect(string server, string port) {
            try {
                if (Connected) return false;
                var hostname = new HostName(server);
                await _clientSocket.ConnectAsync(hostname, port);
                Connected = true;
                if (ConnectedEvt != null) {
                    ConnectedEvt();
                }
                Connecting = false;
                _dataReader = new DataReader(_clientSocket.InputStream) {
                    InputStreamOptions = InputStreamOptions.Partial
                };
                ReadData();
                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Read Data Function
        /// </summary>
        async private void ReadData() {
            try {
                if (!Connected || _clientSocket == null) return;
                uint s = await _dataReader.LoadAsync(2048);
                string data = _dataReader.ReadString(s);
                if (!string.IsNullOrEmpty(data)) {
                    if (DataArrival != null) {
                        DataArrival(data);
                    }
                }
                ReadData();
            } catch (Exception ex) {
                if (DisconnectedEvt != null) {
                    DisconnectedEvt();
                }
                throw ex;
            }
        }
        /// <summary>
        /// Send Data
        /// </summary>
        /// <param name="message"></param>
        async public void SendData(string message) {
            try {
                var writer = new DataWriter(_clientSocket.OutputStream);
                writer.WriteString(message + "\r\n");
                await writer.StoreAsync();
                await writer.FlushAsync();
                writer.DetachStream();
                if (Closing) {
                    _clientSocket.Dispose();
                    Connected = false;
                }
            } catch (Exception ex) {
                if (DisconnectedEvt != null) {
                    DisconnectedEvt();
                }
                throw ex;
            }
        }
        /// <summary>
        /// Close
        /// </summary>
        public void Close() {
            try {
                Closing = false;
                Connected = false;
                _clientSocket.Dispose();
                if (DisconnectedEvt != null) {
                    DisconnectedEvt();
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}