using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
using nexIRC.Infrustructure.Models;
namespace nexIRC.Infrustructure.Controllers {
    public class SocketController {
        #region "events"
        /// <summary>
        /// Data Arrival Event
        /// </summary>
        /// <param name="data"></param>
        public delegate void DataArrivalEvent(string data);
        public event DataArrivalEvent DataArrival;
        /// <summary>
        /// Connected Event
        /// </summary>
        public delegate void ConnectedEvent();
        public event ConnectedEvent ConnectedEvt;
        #endregion
        #region "public properties"
        public bool Closing { get; set; }
        public bool Connecting { get; set; }
        public bool Connected { get; set; }
        #endregion
        #region "private properties"
        private IrcServerInfoModel _settings { get; set; }
        private readonly StreamSocket _clientSocket;
        private DataReader _dataReader;
        #endregion
        /// <summary>
        /// Entry Point (requires settings)
        /// </summary>
        /// <param name="settings"></param>
        public SocketController(IrcServerInfoModel settings) {
            try {
                Connecting = true;
                _clientSocket = new StreamSocket();
                _settings = settings;
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Connect Function
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Connect() {
            try {
                if (Connected) return false;
                var hostname = new HostName(_settings.Server);
                await _clientSocket.ConnectAsync(hostname, _settings.Port.ToString());
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
                throw ex;
            }
        }
    }
}