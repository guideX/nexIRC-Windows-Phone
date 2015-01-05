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
                var b = false;
                if (!IsolatedStorageSettings.ApplicationSettings.Contains("nickname")) {
                    model.Nickname = _nickname;
                    IsolatedStorageSettings.ApplicationSettings["nickname"] = _nickname;
                    b = true;
                } else {
                    model.Nickname = (string)IsolatedStorageSettings.ApplicationSettings["nickname"];
                }
                if (!IsolatedStorageSettings.ApplicationSettings.Contains("altnickname")) {
                    model.AltNickname = _altNickname;
                    IsolatedStorageSettings.ApplicationSettings["altnickname"] = _nickname;
                    b = true;
                } else {
                    model.AltNickname = (string)IsolatedStorageSettings.ApplicationSettings["altnickname"];
                }
                if (!IsolatedStorageSettings.ApplicationSettings.Contains("password")) {
                    model.Password = _password;
                    IsolatedStorageSettings.ApplicationSettings["password"] = _password;
                    b = true;
                } else {
                    model.Password = (string)IsolatedStorageSettings.ApplicationSettings["password"];
                }
                if (!IsolatedStorageSettings.ApplicationSettings.Contains("username")) {
                    model.Username = _username;
                    IsolatedStorageSettings.ApplicationSettings["username"] = _username;
                    b = true;
                } else {
                    model.Username = (string)IsolatedStorageSettings.ApplicationSettings["username"];
                }
                if (!IsolatedStorageSettings.ApplicationSettings.Contains("quitmessage")) {
                    model.QuitMessage = _quitMessage;
                    IsolatedStorageSettings.ApplicationSettings["quitmessage"] = _quitMessage;
                    b = true;
                } else {
                    model.QuitMessage = (string)IsolatedStorageSettings.ApplicationSettings["quitmessage"];
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
                IsolatedStorageSettings.ApplicationSettings["nickname"] = model.Nickname;
                IsolatedStorageSettings.ApplicationSettings["altnickname"] = model.AltNickname;
                IsolatedStorageSettings.ApplicationSettings["password"] = model.Password;
                IsolatedStorageSettings.ApplicationSettings["username"] = model.Username;
                IsolatedStorageSettings.ApplicationSettings["quitmessage"] = model.QuitMessage;
                IsolatedStorageSettings.ApplicationSettings.Save();
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Get Irc Info Model
        /// </summary>
        public static List<IrcServerInfoModel> GetIrcServerInfoModels() {
            var models = new List<IrcServerInfoModel>();
            var b = false;
            try {
                var saved = (List<IrcServerInfoModel>)IsolatedStorageSettings.ApplicationSettings["servers"];
                if (saved != null) {
                    if (saved.Count != 0) {
                        foreach (var item in saved) {
                            models.Add(item);
                            if (!b) { b = true; }
                        }
                    }
                }
            } catch {
                // Do Nothing Special
            }
            try {
                if (!b) {
                    // Nothing existed in the record, add the defaults ;)
                    models.Add(new IrcServerInfoModel() { Server = "irc.freenode.org", Port = 6667, Network = "Freenode", ImagePath = "/Assets/freenode.jpg" });
                    models.Add(new IrcServerInfoModel() { Server = "us.undernet.org", Port = 6667, Network = "Undernet" });
                    models.Add(new IrcServerInfoModel() { Server = "irc.gamesurge.net", Port = 6667, Network = "GameSurge" });
                    models.Add(new IrcServerInfoModel() { Server = "irc.rizon.net", Port = 6667, Network = "Rizon" });
                    models.Add(new IrcServerInfoModel() { Server = "irc.dal.net", Port = 6667, Network = "DALnet" });
                    models.Add(new IrcServerInfoModel() { Server = "irc.quakenet.org", Port = 6667, Network = "Quakenet" });
                    models.Add(new IrcServerInfoModel() { Server = "irc.efnet.org", Port = 6667, Network = "EFnet" });
                    // Start the record keeping process
                    IsolatedStorageSettings.ApplicationSettings["servers"] = models;
                    IsolatedStorageSettings.ApplicationSettings.Save();
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
        public static void SaveIrcServerInfoModels(List<IrcServerInfoModel> models) {
            try {
                storageSettings["servers"] = models;
                storageSettings.Save();
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}