using System;
using nexIRC.Infrustructure.Helpers;
using nexIRC.Infrustructure.Models;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using nexIRC.Infrustructure.Structures;
namespace nexIRC.Infrustructure.Controllers {
    public class CachedIrcMessages {
        public string l001 { get; set; }
        public string l002 { get; set; }
        public string l003 { get; set; }
        public string l004 { get; set; }
    }
    public class StatusController {
        public delegate void DoStatusText(string data);
        public event DoStatusText OnDoStatusText;
        public delegate void SendDataEvent(string data);
        public event SendDataEvent SendData;
        public delegate void RawEvent(string data);
        public event RawEvent RawEvt;
        public delegate void DisconnectedEvent();
        public event DisconnectedEvent DisconnectedEvt;
        private IrcSettings _settings;
        private CachedIrcMessages _cachedIrcMessages = new CachedIrcMessages();
        public StatusController(IrcSettings settings) {
            _settings = settings;
        }
        void _ircStringHelper_OnDoStatusText(string data) {
            if (OnDoStatusText != null) {
                OnDoStatusText(data);
            }
        }
        public void Status_DataArrival(string data) {
            try {
                string[] splt = data.Split(' ');
                string[] splt2 = data.Split(':');
                int numeric = 0;
                if (string.IsNullOrEmpty(data)) {
                    return;
                }
                RawEvt(data);
                if (StringHelper.Left(data.ToLower(), 21) == "error :closing link: ") {
                    if (DisconnectedEvt != null) {
                        DisconnectedEvt();
                    }
                }
                if (Regex.IsMatch(data, "PING :[0-9]+\\r\\n")) {
                    var pingCode = Regex.Match(data, "[0-9]+");
                    if (SendData != null) {
                        SendData("PONG :" + pingCode);
                    }
                }
                //if (StringHelper.Left(data.ToLower(), 7) == "version") {
                //}
                int.TryParse(splt[1], out numeric);
                switch ((IrcNumerics)numeric) {
                    case IrcNumerics.sNOTHING:
                        // DO NOTHING
                        break;
                    case IrcNumerics.sRPL_WELCOME:
                        _cachedIrcMessages.l001 = "[ login " + _settings.IrcServerInfoModel.Network + " ] welcome message: " + splt2[2];
                        Check001Through004();
                        break;
                    case IrcNumerics.sRPL_YOURHOST:
                        var host = (StringHelper.ParseData(splt2[2], "version ", StringHelper.Right(splt2[2], 2) + StringHelper.Right(splt2[2], 3))).Replace("host is", "");
                        var version = (StringHelper.ParseData(splt2[2], "version ", StringHelper.Right(splt2[2], 2)) + StringHelper.Right(splt2[2], 3)).Replace("version", "");
                        _cachedIrcMessages.l002 = "> host: " + host + Environment.NewLine + "> version: " + version;
                        Check001Through004();
                        break;
                    case IrcNumerics.sRPL_CREATED:
                        var created = StringHelper.ParseData(splt2[2], "created", StringHelper.Right(splt2[2], 1));
                        _cachedIrcMessages.l003 = "> Created: " + created;
                        Check001Through004();
                        break;
                    case IrcNumerics.sRPL_MYINFO:
                        var splt3 = splt2[2].Split(' ');
                        _cachedIrcMessages.l004 = "> Servername: " + splt3[0] + Environment.NewLine + "> Version: " + splt3[1] + Environment.NewLine + "> Usermodes: " + splt3[2] + Environment.NewLine + "> Channel Modes: " + splt3[3];
                        Check001Through004();
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
                        splt3 = splt2[2].Split(' ');
                        StatusText("[ trace handshake ] class: " + splt3[1] + ", server: " + splt3[2]);
                        break;
                    case IrcNumerics.sRPL_TRACEUNKNOWN:
                        splt3 = splt2[2].Split(' ');
                        StatusText("[ trace unknown ] address: " + splt3[1] + ", " + splt3[4]);
                        break;
                    case IrcNumerics.sRPL_TRACEOPERATOR:
                        splt3 = splt2[2].Split(' ');
                        StatusText("[ trace operator ] class: " + splt3[1] + ", nick: " + splt3[2]);
                        break;
                    default:
                        if (splt2[2] != null) {
                            if (!string.IsNullOrEmpty(splt2[2])) {
                                StatusText(splt2[2]);
                            }
                        }
                        break;
                }
            } catch (Exception ex) {
                throw ex;
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
        private void Check001Through004() {
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
        public void SendIdentity(IrcSettings settings) {
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
        private void SendQuit() {
            try {
                if (SendData != null) {
                    SendData("QUIT :");
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}