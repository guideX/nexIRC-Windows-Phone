using System.Collections.Generic;
using nexIRC.Infrustructure.Models;
using System;
using System.Linq;
namespace nexIRC.Infrustructure.Helpers {
    public static class StatusHelper {
        /// <summary>
        /// Irc Settings Collection
        /// </summary>
        public static List<IrcSettings> IrcSettings = new List<IrcSettings>();
        /// <summary>
        /// Create Status Window
        /// </summary>
        /// <param name="ircServerInfoModel"></param>
        /// <returns></returns>
        public static string QuitMessage = "nexIRC for Windows Phone team-nexgen.org";
        public static string Nickname = "guide_X";
        public static string Username = "guideX";
        public static string Password = "";
        public static string Server = "irc.freenode.org";
        public static int Port = 6667;
        public static string Network = "Freenode";
        public static IrcSettings CreateStatusWindow(IrcServerInfoModel ircServerInfoModel) {
            try {
                var _settings = new IrcSettings();
                _settings.QuitMessage = QuitMessage;
                _settings.Nickname = Nickname;
                _settings.Password = Password;
                _settings.Username = Username;
                _settings.IrcServerInfoModel = new IrcServerInfoModel();
                _settings.IrcServerInfoModel.Server = ircServerInfoModel.Server;
                _settings.IrcServerInfoModel.Port = ircServerInfoModel.Port;
                _settings.IrcServerInfoModel.Network = ircServerInfoModel.Network;
                IrcSettings.Add(_settings);
                return _settings;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static IrcSettings GetSettings() {
            try {
                if (IrcSettings.Count != 0) {
                    return IrcSettings.Last();
                } else {
                    var s = new IrcSettings() {
                        QuitMessage = QuitMessage,
                        Nickname = Nickname,
                        Password = Password,
                        Username = Username,
                        IrcServerInfoModel = new IrcServerInfoModel {
                            Server = Server, 
                            Network = Network,
                            Port = Port
                        }
                    };
                    IrcSettings.Add(s);
                    return s;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}