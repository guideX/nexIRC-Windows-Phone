//using System.Collections.Generic;
//using nexIRC.Infrustructure.Models;
//using System;
//using System.Linq;
//using nexIRC.Infrustructure.Controllers;
//namespace nexIRC.Infrustructure.Helpers {
    //public static class StatusHelper {
        /// <summary>
        /// Irc Settings Collection
        /// </summary>
        //public static List<UserSettingsModel> UserSettings = new List<UserSettingsModel>();
        /// <summary>
        /// Create Status Window
        /// </summary>
        /// <param name="ircServerInfoModel"></param>
        /// <returns></returns>
        //public static UserSettingsModel CreateStatusWindow(IrcServerInfoModel ircServerInfoModel) {
            //try {
                //var _settings = UserSettingsController.GetUserSettings();
                //_settings.IrcServerInfoModel = new IrcServerInfoModel();
                //_settings.IrcServerInfoModel.Server = ircServerInfoModel.Server;
                //_settings.IrcServerInfoModel.Port = ircServerInfoModel.Port;
                //_settings.IrcServerInfoModel.Network = ircServerInfoModel.Network;
                //UserSettings.Add(_settings);
                //return _settings;
            //} catch (Exception ex) {
                //throw ex;
            //}
        //}
        //public static UserSettingsModel GetUserSettings() {
            //try {
                //if (UserSettings.Count != 0) {
                    //return UserSettings.Last();
                //} else {
                    //var s = UserSettingsController.GetUserSettings();
                    //UserSettings.Add(s);
                    //return s;
                //}
            //} catch (Exception ex) {
                //throw ex;
            //}
        //}
    //}
//}