using nexIRC.Infrustructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
namespace nexIRC.Infrustructure.Controllers {
    public class SocketController {
        public delegate void DataArrivalEvent(string data);
        public event DataArrivalEvent DataArrival;
        public delegate void ConnectedEvent();
        public event ConnectedEvent ConnectedEvt;
        public bool Closing { get; set; }
        public bool Connecting { get; set; }
        public bool Connected { get; set; }
        private IrcSettings _settings { get; set; }
        private readonly StreamSocket _clientSocket;
        private DataReader _dataReader;
        public SocketController(IrcSettings settings) {
            try {
                Connecting = true;
                _clientSocket = new StreamSocket();
                _settings = settings;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public async Task<bool> Connect() {
            try {
                if (Connected) return false;
                var hostname = new HostName(_settings.IrcServerInfoModel.Server);
                await _clientSocket.ConnectAsync(hostname, _settings.IrcServerInfoModel.Port.ToString());
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
        async public void SendData(string message) {
            try {
                var writer = new DataWriter(_clientSocket.OutputStream);
                writer.WriteString(message + "\r\n");
                await writer.StoreAsync();
                await writer.FlushAsync();
                writer.DetachStream();
                if (!Closing) return;
                _clientSocket.Dispose();
                Connected = false;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}