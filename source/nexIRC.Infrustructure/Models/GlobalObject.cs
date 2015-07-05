using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using nexIRC.Infrustructure.Controllers;
using System.Text;
namespace nexIRC.Infrustructure.Models {
    public class GlobalObject {
        #region "events"
        public event OnConnectedEvent ConnectedEvent;
        public delegate void OnConnectedEvent(int id);
        public delegate void DoStatusText(int id, string data);
        public event DoStatusText OnDoStatusText;
        /// <summary>
        /// On Do Status Text
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        private void GlobalObject_OnDoStatusText(int id, string data) {
            if (OnDoStatusText != null) {
                OnDoStatusText(id, data);
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
        #endregion
        #region "private variables"
        private List<StatusObject> _statusObjects = new List<StatusObject>();
        #endregion
        /// <summary>
        /// Raw Text Backup
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StringBuilder RawTextBackup(int id) {
            try {
                return _statusObjects[id].RawTextBackup;
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Status Text Backup
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StringBuilder StatusTextBackup(int id) {
            try {
                return _statusObjects[id].StatusTextBackup;
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
            try {
                _statusObjects[id].Disconnect();
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Controller
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StatusController Controller(int id) {
            try {
                return _statusObjects[id].Controller;
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Command Controller
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CommandController CommandController(int id) {
            try {
                return _statusObjects[id].CommandController;
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Get Id
        /// </summary>
        /// <param name="userSettings"></param>
        /// <param name="ircServerInfoModel"></param>
        /// <returns></returns>
        public int GetId(UserSettingsModel userSettings, IrcServerInfoModel ircServerInfoModel) {
            try {
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
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="userSettings"></param>
        /// <param name="ircInfo"></param>
        /// <returns></returns>
        public int Create(UserSettingsModel userSettings, IrcServerInfoModel ircInfo) {
            try {
                var newStatus = new StatusObject(userSettings, ircInfo);
                _statusObjects.Add(newStatus);
                newStatus.ConnectedEvent += GlobalObject_ConnectedEvent;
                newStatus.OnDoStatusText += GlobalObject_OnDoStatusText;
                return GetId(userSettings, ircInfo);
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}