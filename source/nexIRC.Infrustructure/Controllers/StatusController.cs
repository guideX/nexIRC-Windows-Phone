﻿using System;
using System.Linq;
using nexIRC.Infrustructure.Helpers;
using nexIRC.Infrustructure.Models;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using nexIRC.Infrustructure.Structures;
namespace nexIRC.Infrustructure.Controllers {
    /// <summary>
    /// Cached Irc Messages
    /// </summary>
    public class CachedIrcMessages {
        public string l001 { get; set; }
        public string l002 { get; set; }
        public string l003 { get; set; }
        public string l004 { get; set; }
    }
    /// <summary>
    /// Status Controller
    /// </summary>
    public class StatusController {
        #region "events"
        public delegate void StatusServerName(string data);
        public event StatusServerName OnStatusServerName;
        //public delegate void StatusCaption(string data);
        //public event StatusCaption OnStatusCaption;
        public delegate void DoStatusText(string data);
        public event DoStatusText OnDoStatusText;
        public delegate void SendDataEvent(string data);
        public event SendDataEvent SendData;
        public delegate void RawEvent(string data);
        public event RawEvent RawEvt;
        public delegate void DisconnectedEvent();
        public event DisconnectedEvent DisconnectedEvt;
        #endregion
        #region "private variables"
        #endregion
        /// <summary>
        /// Entry Point
        /// </summary>
        /// <param name="settings"></param>
        public StatusController() {
        }
        /// <summary>
        /// On Do Status Text
        /// </summary>
        /// <param name="data"></param>
        //private void _ircStringHelper_OnDoStatusText(string data) {
            //if (OnDoStatusText != null) {
                //OnDoStatusText(data);
            //}
        //}
        /// <summary>
        /// Data Arrival (parsing function)
        /// </summary>
        /// <param name="data"></param>
        public void Status_DataArrival(string data, CachedIrcMessages _cachedIrcMessages) {
            string currentDataItem = "";
            foreach (var dataItem in data.Split(Environment.NewLine.ToCharArray())) {
                try {
                    if (!string.IsNullOrEmpty(dataItem)) {
                        currentDataItem = dataItem;
                        //if (currentDataItem == ":wolfe.freenode.net 372 guide") {
                            //var mm = "";
                        //}
                        var numeric = 0;
                        RawEvt(dataItem);
                        if (StringHelper.Left(dataItem, 7) == "version") {
                            // CTCP VERSION NOT SUPPORTED YET
                            //return;
                        }
                        // Error Closing Link means disconnect coming
                        if (StringHelper.Left(dataItem.ToLower(), 21) == "error :closing link: ") {
                            if (DisconnectedEvt != null) {
                                DisconnectedEvt();
                                //return;
                            }
                        }
                        // Keepalive
                        if (StringHelper.Left(dataItem.ToLower(), 6) == "ping :") {
                            if (SendData != null) {
                                SendData("PONG :" + StringHelper.Right(dataItem, dataItem.Length - 6));
                                StatusText("[ ping pong ]");
                            }
                        }
                        // Notice Auth command
                        if (dataItem.ToLower().Contains("notice auth :")) {
                            var noticeText = dataItem.Split(':');
                            if (noticeText[1].ToLower().Contains("/QUOTE PASS")) {
                                var ps = noticeText[1].Split('/');
                                var quote = ps[1].Replace("QUOTE PASS", "");
                                SendData("PASS " + quote);
                                StatusText("[ server string quoted ]");
                                //return;
                            }
                            switch (noticeText.Count()) {
                                case 1:
                                    StatusText("[ notice ] " + Environment.NewLine + "> " + noticeText[1]);
                                    break;
                                case 2:
                                    StatusText("[ notice ] " + Environment.NewLine + "> " + noticeText[1] + Environment.NewLine + noticeText[2]);
                                    break;
                            }
                            //return;
                        }
                        // Notice
                        if (StringHelper.Left(dataItem, 10) == "*** notice") {
                            StatusText("[ notice ] " + Environment.NewLine + "> " + dataItem);
                            //return;
                        }
                        if ((dataItem.Contains(" 001 ") && StringHelper.Left(dataItem, 1) == ":") || (data.Contains(" 433 ") && StringHelper.Left(dataItem, 1) == ":")) {
                            if (OnStatusServerName != null) {
                                var _splt = dataItem.Split(' ');
                                OnStatusServerName(_splt[0].Replace(":", ""));
                            }
                        }
                        // Contains the magic :
                        if (StringHelper.Left(dataItem, 1) == ":") {
                            // Split by spaces
                            var splt = dataItem.Split(' ');
                            if (splt.Length > 1) {
                                switch (splt[1].ToLower()) {
                                    case "notice":
                                        var whoText = splt[0].Replace(":", "");
                                        var noticeText = StringHelper.Right(dataItem, dataItem.Length - (splt[0] + splt[1]).Length);
                                        StatusText("[ notice ] " + whoText + ": " + noticeText);
                                        break;
                                    case "nick":
                                        // nick change
                                        var nick = dataItem.Split(':');
                                        nick[2] = nick[2].Replace(":", "");
                                        nick[0] = StringHelper.ParseData(nick[0], ":", "!").Replace(":", "").Replace("!", "");
                                        nick[1] = dataItem;
                                        nick[1] = StringHelper.Left(dataItem, dataItem.Length - (nick[2].Length + 7));
                                        nick[1] = StringHelper.Right(nick[1], nick[1].Length - (nick[0].Length + 2));
                                        StatusText("[ nick change ] " + Environment.NewLine + "> old nickname: " + nick[0] + Environment.NewLine + "> hostname: " + nick[1] + Environment.NewLine + "> new nickname: " + nick[2]);
                                        break;
                                    case "quit":
                                        if (dataItem.Contains(":") && dataItem.Contains("!")) {
                                            var ___nick = StringHelper.ParseData(dataItem, ":", "!");
                                            if (dataItem.Contains(" QUIT: ")) {
                                                var _hostName = StringHelper.ParseData(dataItem, ":" + ___nick + "!", " QUIT: ").Replace(___nick + "!", "");
                                                var _quitMessage = dataItem.Replace(":" + ___nick + "!" + _hostName + " QUIT :", "");
                                                StatusText("[ quit ] " + Environment.NewLine + "> nick: " + ___nick + Environment.NewLine + "> hostname: " + _hostName + Environment.NewLine + "> quit message: " + _quitMessage);
                                            }
                                        }
                                        break;
                                    case "join":
                                        var __nick = StringHelper.ParseData(dataItem, ":", "!");
                                        var __ipAddress = StringHelper.ParseData(dataItem, "~", "JOIN");
                                        var __channel = "";
                                        if (dataItem.ToUpper().Contains(" JOIN :#")) {
                                            __channel = StringHelper.Right(dataItem, dataItem.Length - (StringHelper.Right(dataItem, dataItem.Length - 1) + 1).IndexOf(":"));
                                        } else if (dataItem.Contains("JOIN #")) {
                                            __channel = StringHelper.Right(dataItem, dataItem.Length - StringHelper.Right(dataItem, dataItem.Length - 1).IndexOf(" JOIN ") + 1);
                                            if (__channel.IndexOf("JOIN") != 0) {
                                                __channel = __channel.Replace("JOIN", "").Trim();
                                            }
                                        }
                                        break;
                                    case "part":
                                        if (splt.Count() == 2) {
                                            var _splt2 = splt[0].Split(Convert.ToChar("@"));
                                            if (_splt2.Count() == 1) {
                                                var ___nickname = StringHelper.ParseData(_splt2[0], ":", "!");
                                                var _splt3 = _splt2[0].Split('~');
                                                var __hostname = "";
                                                if (_splt3.Count() > 0) {
                                                    __hostname = _splt3[1] + "@" + _splt2[1];
                                                } else {
                                                    __hostname = _splt3[0];
                                                }
                                                StatusText("[ part ] " + Environment.NewLine + "> hostname: " + __hostname + Environment.NewLine + "> nickname: " + ___nickname);
                                            }
                                        }
                                        break;
                                    case "privmsg":
                                        if (dataItem.Contains(":ACTION ")) {
                                            // Action
                                        }
                                        if (dataItem.ToUpper().Contains("DCC SEND ")) {
                                            // Dcc Send
                                        }
                                        if (dataItem.ToUpper().Contains("DCC CHAT chat")) {
                                            // Dcc Chat
                                        }
                                        if (dataItem.Left(1) == ":") {
                                            currentDataItem = StringHelper.Right(dataItem, dataItem.Length + 1);
                                        }
                                        var msg3 = StringHelper.Right(dataItem, dataItem.Length - (splt[0].Length + splt[1].Length + splt[2].Length) + 3);
                                        //If Left(lData, 1) = ":" Then lData = Right(lData, Len(lData) - 1)
                                        break;
                                }
                                var msg = "";
                                // Ensure split count is more than two
                                if (splt.Count() > 2) {
                                    if (StringHelper.Left(splt[3], 1) != ":") {
                                        if (StringHelper.Left(splt[3], 1) != ":") {
                                            splt[3] = ":" + splt[3];
                                        }
                                        msg = "";
                                        var i = 0;
                                        foreach (var item in splt) {
                                            if (!string.IsNullOrEmpty(msg)) {
                                                msg = msg + " " + item;
                                            } else {
                                                msg = item;
                                            }
                                            i++;
                                        }
                                    } else {
                                        msg = dataItem;
                                    }
                                } else {
                                    msg = "";
                                }
                                var splt2 = msg.Split(':');
                                int.TryParse(splt[1], out numeric);
                                // Detect the IRC Numeric
                                var splt3 = splt2[2].Split(' ');
                                switch ((IrcNumerics)numeric) {
                                    case IrcNumerics.sRPL_WELCOME:
                                        //_cachedIrcMessages.l001 = "[ login " + _userSettings.IrcServerInfoModel.Network + " ] welcome message: " + splt2[2];
                                        _cachedIrcMessages.l001 = "[ login ] welcome message: " + splt2[2];
                                        Check001Through004(_cachedIrcMessages);
                                        break;
                                    case IrcNumerics.sRPL_YOURHOST:
                                        var host = (StringHelper.ParseData(splt2[2], "version ", StringHelper.Right(splt2[2], 2) + StringHelper.Right(splt2[2], 3))).Replace("host is", "");
                                        var version = (StringHelper.ParseData(splt2[2], "version ", StringHelper.Right(splt2[2], 2)) + StringHelper.Right(splt2[2], 3)).Replace("version", "");
                                        _cachedIrcMessages.l002 = "> host: " + host + Environment.NewLine + "> version: " + version;
                                        Check001Through004(_cachedIrcMessages);
                                        break;
                                    case IrcNumerics.sRPL_CREATED:
                                        var created = StringHelper.ParseData(splt2[2], "created", StringHelper.Right(splt2[2], 1));
                                        _cachedIrcMessages.l003 = "> Created: " + created;
                                        Check001Through004(_cachedIrcMessages);
                                        break;
                                    case IrcNumerics.sRPL_MYINFO:
                                        splt3 = splt2[1].Split(' ');
                                        _cachedIrcMessages.l004 = "> Servername: " + splt3[0] + Environment.NewLine + "> Version: " + splt3[1] + Environment.NewLine + "> Usermodes: " + splt3[2] + Environment.NewLine + "> Channel Modes: " + splt3[3];
                                        Check001Through004(_cachedIrcMessages);
                                        break;
                                    case IrcNumerics.sRPL_MAP:
                                        StatusText("[ map ] " + splt2[2]);
                                        break;
                                    case IrcNumerics.sRPL_MAPEND:
                                        StatusText("[ end of map ] " + splt2[2]);
                                        break;
                                    case IrcNumerics.sRPL_SNOMASK:
                                        StatusText("[ server notice mask ] " + splt2[2]);
                                        break;
                                    case IrcNumerics.sRPL_BOUNCE_2:
                                        StatusText("[ server recommends redirect ] " + splt2[2]);
                                        break;
                                    case IrcNumerics.sRPL_TRACEHANDSHAKE:
                                        StatusText("[ trace handshake ] " + Environment.NewLine + "> class: " + splt3[1] + Environment.NewLine + "> server: " + splt3[2]);
                                        break;
                                    case IrcNumerics.sRPL_TRACEUNKNOWN:
                                        StatusText("[ trace unknown ]  " + Environment.NewLine + "> address: " + splt3[1] + Environment.NewLine + "> address: " + splt3[4]);
                                        break;
                                    case IrcNumerics.sRPL_TRACEOPERATOR:
                                        StatusText("[ trace operator ] " + Environment.NewLine + "> class: " + splt3[1] + Environment.NewLine + "> nick: " + splt3[2]);
                                        break;
                                    case IrcNumerics.sRPL_TRACEUSER:
                                        StatusText("[ trace user ] " + Environment.NewLine + "> class: " + splt3[1] + Environment.NewLine + "> nick: " + splt3[2]);
                                        break;
                                    case IrcNumerics.sRPL_TRACESERVER:
                                        StatusText("[ trace server ] " + Environment.NewLine + "> class: " + splt3[1] + Environment.NewLine + "> server: " + splt3[4] + Environment.NewLine + "> nickandhost: " + splt3[5] + Environment.NewLine + "> protocol version: " + splt3[6]);
                                        break;
                                    case IrcNumerics.sRPL_TRACESERVICE:
                                        StatusText("[ trace service ] " + Environment.NewLine + "> class: " + splt3[1] + Environment.NewLine + "> name: " + splt3[2] + Environment.NewLine + "> type: " + splt3[3] + Environment.NewLine + "> active type: " + splt3[4]);
                                        break;
                                    case IrcNumerics.sRPL_TRACENEWTYPE:
                                        StatusText("[ trace new type ] " + Environment.NewLine + "> new type: " + splt3[0] + Environment.NewLine + "> client name: " + splt3[1]);
                                        break;
                                    case IrcNumerics.sRPL_TRACECLASS:
                                        StatusText("[ trace class ] " + Environment.NewLine + "> class: " + splt3[1] + Environment.NewLine + "> count: " + splt3[2]);
                                        break;
                                    case IrcNumerics.sRPL_STATSLINKINFO:
                                        StatusText("[ status link info ] " + Environment.NewLine + "> link name: " + splt3[0] + Environment.NewLine + "> sendq: " + splt3[1] + Environment.NewLine + "> sent messages: " + splt3[2] + Environment.NewLine + "> sent bytes: " + splt3[3] + Environment.NewLine + "> recv msgs: " + splt3[4] + Environment.NewLine + "> recv bytes: " + splt3[5] + Environment.NewLine + "> time open: " + splt3[6]);
                                        break;
                                    case IrcNumerics.sRPL_STATSCOMMANDS:
                                        StatusText("[ stats commands ] " + Environment.NewLine + "> command: " + splt3[0] + Environment.NewLine + "> count: " + splt3[1] + Environment.NewLine + "> byte count: " + splt3[2] + Environment.NewLine + "> remote count: " + splt3[3]);
                                        break;
                                    case IrcNumerics.sRPL_STATSCLINE:
                                        StatusText("[ stats cline ] " + Environment.NewLine + "> host: " + splt3[1] + Environment.NewLine + "> name: " + splt3[3] + Environment.NewLine + "> port: " + splt3[4] + Environment.NewLine + "> class: " + splt3[5]);
                                        break;
                                    case IrcNumerics.sRPL_STATSNLINE:
                                        StatusText("[ stats nline ] " + Environment.NewLine + "> host: " + splt3[1] + Environment.NewLine + "> name: " + splt3[3] + Environment.NewLine + "> port: " + splt3[4] + Environment.NewLine + "> class: " + splt3[5]);
                                        break;
                                    case IrcNumerics.sRPL_STATSILINE:
                                        StatusText("[ stats iline ] " + Environment.NewLine + "> host: " + splt3[1] + Environment.NewLine + "> name: " + splt3[3] + Environment.NewLine + "> port: " + splt3[4] + Environment.NewLine + "> class: " + splt3[5]);
                                        break;
                                    case IrcNumerics.sRPL_STATSKLINE:
                                        StatusText("[ stats kline ] " + Environment.NewLine + "> host: " + splt3[1] + Environment.NewLine + "> name: " + splt3[3] + Environment.NewLine + "> port: " + splt3[4] + Environment.NewLine + "> class: " + splt3[5]);
                                        break;
                                    case IrcNumerics.sRPL_STATSYLINE:
                                        StatusText("[ stats yline ] " + Environment.NewLine + "> class: " + splt3[1] + Environment.NewLine + "> ping: " + splt3[2] + Environment.NewLine + "> connect: " + splt3[3] + Environment.NewLine + "> sendq: " + splt3[4]);
                                        break;
                                    case IrcNumerics.sRPL_ENDOFSTATS:
                                        StatusText("[ end of stats ] " + Environment.NewLine + "> query: " + splt3[0] + Environment.NewLine + "> info: " + splt3[1].Replace(":", ""));
                                        break;
                                    case IrcNumerics.sRPL_UMODEIS:
                                        StatusText("[ umode is ] " + Environment.NewLine + "> usermodes: " + splt3[0] + Environment.NewLine + "> params: " + splt3[1]);
                                        break;
                                    case IrcNumerics.sRPL_SERVLIST:
                                        StatusText("[ serv list ] " + Environment.NewLine + "> server: " + splt3[0] + Environment.NewLine + "> mask: " + splt3[1] + Environment.NewLine + "> type: " + splt3[2] + Environment.NewLine + "> hopcount: " + splt3[3] + Environment.NewLine + "> info: " + splt3[4]);
                                        break;
                                    case IrcNumerics.sRPL_SERVLISTEND:
                                        StatusText("[ serv list end ] " + Environment.NewLine + "> mask: " + splt3[0] + Environment.NewLine + "> type: " + splt3[1] + splt3[2].Replace(":", ""));
                                        break;
                                    case IrcNumerics.sRPL_STATSLLINE:
                                        StatusText("[ stats lline ] " + Environment.NewLine + "> hostmask: " + splt3[1] + Environment.NewLine + "> server name: " + splt3[3] + Environment.NewLine + "> max depth: " + splt3[4]);
                                        break;
                                    case IrcNumerics.sRPL_STATSUPTIME:
                                        StatusText("[ stats uptime ] " + Environment.NewLine + "> " + splt2[2]);
                                        break;
                                    case IrcNumerics.sRPL_STATSOLINE:
                                        StatusText("[ stats oline ] " + Environment.NewLine + "> hostmask: " + splt3[1] + Environment.NewLine + "> nick: " + splt3[3] + Environment.NewLine + "> info: " + splt3[4]);
                                        break;
                                    case IrcNumerics.sRPL_STATSHLINE:
                                        StatusText("[ stats hline ] " + Environment.NewLine + "> hostmask: " + splt3[1] + Environment.NewLine + "> server name: " + splt3[3]);
                                        break;
                                    case IrcNumerics.sRPL_STATSCONN:
                                        StatusText("[ stats conn ] " + splt2[3]);
                                        break;
                                    default:
                                        if (splt2[2] != null) {
                                            if (!string.IsNullOrEmpty(splt2[2])) {
                                                StatusText(splt2[2]);
                                            }
                                        }
                                        break;
                                }
                            }
                            //return;
                            //} else {
                            //var blah = 0;
                            //}
                        }
                    }
                } catch (Exception ex) {
                    StatusText("Error: " + ex.Message + ", data which caused error: " + currentDataItem);
                    //throw ex;
                }
            }
        }
        private void StatusText(string data) {
            try {
                if (OnDoStatusText != null) {
                    OnDoStatusText(data);
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void Check001Through004(CachedIrcMessages _cachedIrcMessages) {
            try {
                if (!string.IsNullOrEmpty(_cachedIrcMessages.l001) && !string.IsNullOrEmpty(_cachedIrcMessages.l002) && !string.IsNullOrEmpty(_cachedIrcMessages.l003) && !string.IsNullOrEmpty(_cachedIrcMessages.l004)) {
                    StatusText("-" + Environment.NewLine + _cachedIrcMessages.l001 + Environment.NewLine + _cachedIrcMessages.l002 + Environment.NewLine + _cachedIrcMessages.l003 + Environment.NewLine + _cachedIrcMessages.l004 + Environment.NewLine + "-");
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void Status_Command(string data) {
            try {
                MessageBox.Show(data);
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void SendIdentity(UserSettingsModel settings) {
            try {
                if (!settings.IsValid()) {
                    MessageBox.Show("Error, Invalid Settings.");
                    return;
                }
                if (SendData != null) {
                    if (settings.Nickname == string.Empty) settings.Nickname = settings.Username;
                    SendData("NICK " + settings.Nickname);
                    SendData("USER " + settings.Username + " " + settings.Username + " " + settings.Username + " :" + settings.Username);
                    if (settings.Password != String.Empty) {
                        SendData("PASS " + settings.Password);
                    }
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void SendQuit(string quitMessage) {
            try {
                if (SendData != null) {
                    SendData("QUIT :" + quitMessage);
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}