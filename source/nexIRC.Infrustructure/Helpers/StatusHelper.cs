using System.Collections.Generic;
using nexIRC.Infrustructure.Models;
using System;
using System.Linq;
using nexIRC.Infrustructure.Controllers;
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
                var _settings = SettingsController.GetIrcSettings();
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
                    var s = SettingsController.GetIrcSettings();
                    IrcSettings.Add(s);
                    return s;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}