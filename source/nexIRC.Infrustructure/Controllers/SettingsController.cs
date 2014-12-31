using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nexIRC.Infrustructure.Models;
namespace nexIRC.Infrustructure.Controllers {
    public static class SettingsController {
        private static IsolatedStorageSettings storageSettings = IsolatedStorageSettings.ApplicationSettings;
        private static string _quitMessage = "nexIRC for Windows Phone team-nexgen.org";
        private static string _nickname = "guide_X";
        private static string _altNickname = "guide__X";
        private static string _username = "guideX";
        private static string _password = "";
        private static string _server = "irc.freenode.org";
        private static int _port = 6667;
        private static string _network = "Freenode";
        /// <summary>
        /// Get Irc Settings
        /// </summary>
        /// <returns></returns>
        public static IrcSettings GetIrcSettings() {
            try {
                var model = new IrcSettings();
                if (storageSettings["nickname"] != null && !string.IsNullOrEmpty(storageSettings["nickname"].ToString())) {
                    model.Nickname = storageSettings["nickname"].ToString();
                } else {
                    model.Nickname = _nickname;
                }
                if (storageSettings["altnickname"] != null && !string.IsNullOrEmpty(storageSettings["altnickname"].ToString())) {
                    model.AltNickname = storageSettings["altnickname"].ToString();
                } else {
                    model.AltNickname = _altNickname;
                }
                if (storageSettings["password"] != null && !string.IsNullOrEmpty(storageSettings["password"].ToString())) {
                    model.Password = storageSettings["password"].ToString();
                } else {
                    model.Password  = _password;
                }
                if (storageSettings["username"] != null && !string.IsNullOrEmpty(storageSettings["username"].ToString())) {
                    model.Username = storageSettings["username"].ToString();
                } else {
                    model.Username = _username;
                }
                if (storageSettings["quitmessage"] != null && !string.IsNullOrEmpty(storageSettings["quitmessage"].ToString())) {
                    model.QuitMessage = storageSettings["quitmessage"].ToString();
                } else {
                    model.QuitMessage = _quitMessage;
                }
                return model;
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Save Irc Settings
        /// </summary>
        /// <param name="model"></param>
        public static void SaveIrcSettings(IrcSettings model) {
            try {
                storageSettings["nickname"] = model.Nickname;
                storageSettings["altnickname"] = model.AltNickname;
                storageSettings["password"] = model.Password;
                storageSettings["username"] = model.Username;
                storageSettings["quitmessage"] = model.QuitMessage;
                storageSettings.Save();
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Get Irc Info Model
        /// </summary>
        public List<IrcServerInfoModel> GetIrcServerInfoModels() {
            try {
                var models = new List<IrcServerInfoModel>();
                var saved = (List<IrcServerInfoModel>)storageSettings["servers"];
                if (saved == null) {
                    models.Add(new IrcServerInfoModel() { Server = "irc.freenode.org", Port = 6667, Network = "Freenode", ImagePath = "/Assets/freenode.jpg" });
                    models.Add(new IrcServerInfoModel() { Server = "us.undernet.org", Port = 6667, Network = "Undernet" });
                    models.Add(new IrcServerInfoModel() { Server = "irc.gamesurge.net", Port = 6667, Network = "GameSurge" });
                    models.Add(new IrcServerInfoModel() { Server = "irc.rizon.net", Port = 6667, Network = "Rizon" });
                    models.Add(new IrcServerInfoModel() { Server = "irc.dal.net", Port = 6667, Network = "DALnet" });
                    models.Add(new IrcServerInfoModel() { Server = "irc.quakenet.org", Port = 6667, Network = "Quakenet" });
                    models.Add(new IrcServerInfoModel() { Server = "irc.efnet.org", Port = 6667, Network = "EFnet" });
                } else {
                    models = saved;
                }
                return models;
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Save Irc Server Info Models
        /// </summary>
        /// <param name="models"></param>
        public void SaveIrcServerInfoModels(List<IrcServerInfoModel> models) {
            try {
                storageSettings["servers"] = models;
                storageSettings.Save();
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}