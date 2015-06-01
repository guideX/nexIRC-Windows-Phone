using nexIRC.Infrustructure.Controllers;
using nexIRC.Infrustructure.Models;
using System.Text;
using System.Threading.Tasks;
namespace nexIRC.Infrustructure.Models {
    public class StatusObject {
        #region "events"
        public delegate void OnConnectedEvent(int id);
        public event OnConnectedEvent ConnectedEvent;
        public delegate void OnDisconnectedEvent(int id);
        public event OnDisconnectedEvent DisconnectedEvent;
        public delegate void DoStatusText(int id, string data);
        public event DoStatusText OnDoStatusText;
        private void Controller_OnDoStatusText(string data) {
            StatusTextBackup.AppendLine(data);
            if (OnDoStatusText != null) {
                OnDoStatusText(MyId, data);
            }
        }
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
            IrcInfo = ircInfo;
            UserSettings = userSettings;
            Controller = new StatusController();
            CommandController = new CommandController();
            _socket = new SocketController();
            _cachedIrcMessages = new CachedIrcMessages();
            StatusTextBackup = new StringBuilder();
            RawTextBackup = new StringBuilder();
            WindUp();
        }
        /// <summary>
        /// Wind Up
        /// </summary>
        private void WindUp() {
            _socket.DataArrival += Socket_DataArrival;
            _socket.ConnectedEvt += Socket_ConnectedEvt;
            _socket.DisconnectedEvt += Socket_DisonnectedEvt;
            _cachedIrcMessages = new CachedIrcMessages();
            Controller.OnDoStatusText += Controller_OnDoStatusText;
        }
        /// <summary>
        /// Connected Event
        /// </summary>
        private void Socket_ConnectedEvt() {
            Controller.SendIdentity(UserSettings);
            if (ConnectedEvent != null) {
                ConnectedEvent(MyId);
                IsConnected = true;
            }
        }
        /// <summary>
        /// Disconnected Event
        /// </summary>
        private void Socket_DisonnectedEvt() {
            if (DisconnectedEvent != null) {
                DisconnectedEvent(MyId);
                IsConnected = false;
            }
        }
        /// <summary>
        /// Data Arrival
        /// </summary>
        /// <param name="data"></param>
        private void Socket_DataArrival(string data) {
            if (!string.IsNullOrEmpty(data)) {
                Controller.Status_DataArrival(data, _cachedIrcMessages);
            }
        }
        /// <summary>
        /// Connect
        /// </summary>
        public void Connect() {
            var task = Task.Run(async () => { await _socket.Connect(IrcInfo.Server, IrcInfo.Port.ToString()); });
            task.Wait();
        }
        /// <summary>
        /// Disconnect
        /// </summary>
        public void Disconnect() {
            _socket.Close();
        }
        /// <summary>
        /// Send Data
        /// </summary>
        /// <param name="data"></param>
        public void SendData(string data) {
            _socket.SendData(data);
        }
        /// <summary>
        /// Incoming Raw Text
        /// </summary>
        /// <param name="data"></param>
        private void _controller_RawEvt(string data) {
            RawTextBackup.AppendLine(data);
            UserSettings.RawText.Add(data);
        }
    }
}