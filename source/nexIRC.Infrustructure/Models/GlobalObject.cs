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
        /// Is Connected
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool IsConnected(int id) {
            try {
                return _statusObjects[id].IsConnected;
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
        //private UserSettingsModel _userSettings(int id) {
            //return _statusObjects[id].UserSettings;
        //}
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
                so.IrcInfo.Network == ircServerInfoModel.Network &&
                so.IrcInfo.Port == ircServerInfoModel.Port &&
                so.IrcInfo.Server == ircServerInfoModel.Server).ToList();
            if (objs.Count() != 0) {
                return _statusObjects.FindIndex(so =>
                so.UserSettings.Nickname == userSettings.Nickname &&
                so.IrcInfo.Network == ircServerInfoModel.Network &&
                so.IrcInfo.Port == ircServerInfoModel.Port &&
                so.IrcInfo.Server == ircServerInfoModel.Server);
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
}