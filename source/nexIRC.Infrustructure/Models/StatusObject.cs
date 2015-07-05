using System;
using System.Text;
using System.Threading.Tasks;
using nexIRC.Infrustructure.Controllers;
using nexIRC.Infrustructure.Models;
namespace nexIRC.Infrustructure.Models {
    public class StatusObject {
        #region "events"
        public delegate void OnConnectedEvent(int id);
        public event OnConnectedEvent ConnectedEvent;
        public delegate void OnDisconnectedEvent(int id);
        public event OnDisconnectedEvent DisconnectedEvent;
        public delegate void DoStatusText(int id, string data);
        public event DoStatusText OnDoStatusText;
        #endregion
        #region "public properties"
        public IrcServerInfoModel IrcInfo { get; set; }
        public int MyId { get; set; }
        public UserSettingsModel UserSettings { get; set; }
        public StatusController Controller { get; set; }
        public CommandController CommandController { get; set; }
        public bool IsConnected { get; set; }
        public StringBuilder StatusTextBackup { get; set; }
        public StringBuilder RawTextBackup { get; set; }
        #endregion
        #region "private variables"
        private SocketController _socket;
        private CachedIrcMessages _cachedIrcMessages;
        #endregion
        /// <summary>
        /// Status Object
        /// </summary>
        /// <param name="userSettings"></param>
        public StatusObject(UserSettingsModel userSettings, IrcServerInfoModel ircInfo) {
            try {
                IrcInfo = ircInfo;
                UserSettings = userSettings;
                Controller = new StatusController();
                CommandController = new CommandController();
                _socket = new SocketController();
                _cachedIrcMessages = new CachedIrcMessages();
                StatusTextBackup = new StringBuilder();
                RawTextBackup = new StringBuilder();
                WindUp();
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// On Do Status Text
        /// </summary>
        /// <param name="data"></param>
        private void Controller_OnDoStatusText(string data) {
            try {
                StatusTextBackup.AppendLine(data);
                if (OnDoStatusText != null) {
                    OnDoStatusText(MyId, data);
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Wind Up
        /// </summary>
        private void WindUp() {
            try {
                _socket.DataArrival += Socket_DataArrival;
                _socket.ConnectedEvt += Socket_ConnectedEvt;
                _socket.DisconnectedEvt += Socket_DisonnectedEvt;
                Controller.OnDoStatusText += Controller_OnDoStatusText;
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Connected Event
        /// </summary>
        private void Socket_ConnectedEvt() {
            try {
                Controller.SendIdentity(UserSettings);
                if (ConnectedEvent != null) {
                    ConnectedEvent(MyId);
                    IsConnected = true;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Disconnected Event
        /// </summary>
        private void Socket_DisonnectedEvt() {
            try {
                if (DisconnectedEvent != null) {
                    DisconnectedEvent(MyId);
                    IsConnected = false;
                    IrcInfo.IsConnected = IsConnected;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Data Arrival
        /// </summary>
        /// <param name="data"></param>
        private void Socket_DataArrival(string data) {
            try {
                if (!string.IsNullOrEmpty(data)) {
                    Controller.Status_DataArrival(data, _cachedIrcMessages);
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Connect
        /// </summary>
        public void Connect() {
            try {
                var task = Task.Run(async () => { await _socket.Connect(IrcInfo.Server, IrcInfo.Port.ToString()); });
                task.Wait();
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Disconnect
        /// </summary>
        public void Disconnect() {
            try {
                _socket.Close();
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
                _socket.SendData(data);
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Incoming Raw Text
        /// </summary>
        /// <param name="data"></param>
        private void _controller_RawEvt(string data) {
            try {
                RawTextBackup.AppendLine(data);
                UserSettings.RawText.Add(data);
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}