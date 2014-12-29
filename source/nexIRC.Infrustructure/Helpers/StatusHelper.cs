using System.Collections.Generic;
using nexIRC.Infrustructure.Models;
using System;
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
        public static IrcSettings CreateStatusWindow(IrcServerInfoModel ircServerInfoModel) {
            try {
                var _settings = new IrcSettings();
                _settings.QuitMessage = "nexIRC for Windows Phone team-nexgen.org";
                _settings.Nickname = "guide_X";
                _settings.Password = "";
                _settings.Username = "guideX";
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
    }
}