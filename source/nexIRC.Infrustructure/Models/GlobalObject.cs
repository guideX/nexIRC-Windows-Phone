using nexIRC.Infrustructure.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace nexIRC.Infrustructure.Models {
    public class GlobalObject {
        #region "events"
        /// <summary>
        /// Connected Event
        /// </summary>
        public event OnConnectedEvent ConnectedEvent;
        /// <summary>
        /// On Connected Event
        /// </summary>
        /// <param name="id"></param>
        public delegate void OnConnectedEvent(int id);
        #endregion
        #region "private variables"
        /// <summary>
        /// Status Objects
        /// </summary>
        private List<StatusObject> _statusObjects = new List<StatusObject>();
        #endregion
        /// <summary>
        /// Entry Point
        /// </summary>
        public GlobalObject() {
            try {
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Connected Event
        /// </summary>
        /// <param name="id"></param>
        private void GlobalObject_ConnectedEvent(int id) {
            try {
                if (ConnectedEvent != null) {
                    ConnectedEvent(id);
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Connected
        /// </summary>
        /// <param name="id"></param>
        public void Connect(int id) {
            try {
                _statusObjects[id].Connect();
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Send Data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        public void SendData(int id, string data) {
            _statusObjects[id].SendData(data);
        }
        /// <summary>
        /// Disconnect
        /// </summary>
        /// <param name="id"></param>
        public void Disconnect(int id) {
            _statusObjects[id].Disconnect();
        }
        /// <summary>
        /// Controller
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StatusController Controller(int id) {
            return _statusObjects[id].Controller;
        }
        /// <summary>
        /// User Settings
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserSettingsModel UserSettings(int id) {
            return _statusObjects[id].UserSettings;
        }
        /// <summary>
        /// Command Controller
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CommandController CommandController(int id) {
            return _statusObjects[id].CommandController;
        }
        /// <summary>
        /// Get Id
        /// </summary>
        /// <param name="userSettings"></param>
        /// <param name="ircServerInfoModel"></param>
        /// <returns></returns>
        public int GetId(UserSettingsModel userSettings, IrcServerInfoModel ircServerInfoModel) {
            var objs = _statusObjects.Where(so =>
                so.UserSettings.Nickname == userSettings.Nickname &&
                so.IrcServerInfoModel.Network == ircServerInfoModel.Network &&
                so.IrcServerInfoModel.Port == ircServerInfoModel.Port &&
                so.IrcServerInfoModel.Server == ircServerInfoModel.Server).ToList();
            if (objs.Count() != 0) {
                return _statusObjects.FindIndex(so =>
                so.UserSettings.Nickname == userSettings.Nickname &&
                so.IrcServerInfoModel.Network == ircServerInfoModel.Network &&
                so.IrcServerInfoModel.Port == ircServerInfoModel.Port &&
                so.IrcServerInfoModel.Server == ircServerInfoModel.Server);
            } else {
                return -1;
            }
        }
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="userSettings"></param>
        /// <param name="ircInfo"></param>
        /// <returns></returns>
        public int Create(UserSettingsModel userSettings, IrcServerInfoModel ircInfo) {
            var newStatus = new StatusObject(userSettings, ircInfo);
            _statusObjects.Add(newStatus);
            newStatus.ConnectedEvent += GlobalObject_ConnectedEvent;
            return GetId(userSettings, ircInfo);
        }
    }
    public class StatusObject {
        public IrcServerInfoModel IrcServerInfoModel { get; set; }
        /// <summary>
        /// This Status Objects Id
        /// </summary>
        public int MyId { get; set; }
        /// <summary>
        /// On Connected Event Delegate
        /// </summary>
        /// <param name="id"></param>
        public delegate void OnConnectedEvent(int id);
        /// <summary>
        /// Connected Event
        /// </summary>
        public event OnConnectedEvent ConnectedEvent;
        /// <summary>
        /// Socket
        /// </summary>
        private SocketController Socket { get; set; }
        /// <summary>
        /// User Settings
        /// </summary>
        public UserSettingsModel UserSettings { get; set; }
        /// <summary>
        /// Controller
        /// </summary>
        public StatusController Controller { get; set; }
        /// <summary>
        /// Command Controller
        /// </summary>
        public CommandController CommandController { get; set; }
        /// <summary>
        /// Status Object
        /// </summary>
        /// <param name="userSettings"></param>
        public StatusObject(UserSettingsModel userSettings, IrcServerInfoModel ircInfo) {
            IrcServerInfoModel = ircInfo;
            UserSettings = userSettings;
            Controller = new StatusController();
            CommandController = new CommandController();
            Socket = new SocketController();
            Socket.DataArrival += Socket_DataArrival;
            Socket.ConnectedEvt += Socket_ConnectedEvt;
        }
        /// <summary>
        /// Connected Event
        /// </summary>
        void Socket_ConnectedEvt() {
            Controller.SendIdentity(UserSettings);
            if (ConnectedEvent != null) {
                ConnectedEvent(MyId);
            }
        }
        /// <summary>
        /// Data Arrival
        /// </summary>
        /// <param name="data"></param>
        void Socket_DataArrival(string data) {
            if (!string.IsNullOrEmpty(data)) {
                Controller.Status_DataArrival(data);
                //if (DataArrival != null) {
                //DataArrival(data);
                //}
            }
        }
        /// <summary>
        /// Connect
        /// </summary>
        public void Connect() {
            var task = Task.Run(async () => { await Socket.Connect(IrcServerInfoModel.Server, IrcServerInfoModel.Port.ToString()); });
            task.Wait();
        }
        /// <summary>
        /// Disconnect
        /// </summary>
        public void Disconnect() {
            Socket.Close();
        }
        /// <summary>
        /// Send Data
        /// </summary>
        /// <param name="data"></param>
        public void SendData(string data) {
            Socket.SendData(data);
        }
        /// <summary>
        /// Incoming Raw Text
        /// </summary>
        /// <param name="data"></param>
        void _controller_RawEvt(string data) {
            UserSettings.RawText.Add(data);
        }
    }
}