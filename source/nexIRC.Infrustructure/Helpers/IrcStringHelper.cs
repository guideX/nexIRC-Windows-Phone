using nexIRC.Infrustructure.Models;
using System;
namespace nexIRC.Infrustructure.Helpers {
    public class CachedIrcMessages {
        public string l001 { get; set; }
        public string l002 { get; set; }
        public string l003 { get; set; }
        public string l004 { get; set; }
        public string l005 { get; set; }
    }
    public class IrcStringHelper {
        public delegate void DoStatusText(string data);
        public event DoStatusText OnDoStatusText;
        private CachedIrcMessages _cachedIrcMessages = new CachedIrcMessages();
        public void ProcessIrcNumeric(string data, IrcSettings settings) {
            string[] splt = data.Split(' ');
            string[] splt2 = data.Split(':');
            int numeric = 0;
            int.TryParse(splt[1], out numeric);
            switch (numeric) {
                case 0: // NOTHING/NOT NUMERIC
                case 1: // RPL_WELCOME
                    _cachedIrcMessages.l001 = "[ login " + settings.IrcServerInfoModel.Network + " ] > welcome message: " + splt2[2];
                    Check001Through004();
                    break;
                case 2: // RPL_YOURHOST
                    var host = (StringHelper.ParseData(splt2[2], "version ", StringHelper.Right(splt2[2], 2) + StringHelper.Right(splt2[2], 3))).Replace("host is", "");
                    var version = (StringHelper.ParseData(splt2[2], "version ", StringHelper.Right(splt2[2], 2)) + StringHelper.Right(splt2[2], 3)).Replace("version", "");
                    _cachedIrcMessages.l002 = "> host: " + host + Environment.NewLine + "> version: " + version;
                    Check001Through004();
                    break;
                case 3: //RPL_CREATED
                    var created = StringHelper.ParseData(splt2[2], "created", StringHelper.Right(splt2[2], 1));
                    _cachedIrcMessages.l003 = "> Created: " + created;
                    Check001Through004();
                    break;
                case 4: // RPL_MYINFO
                    var splt3 = splt2[2].Split(' ');
                    _cachedIrcMessages.l004 = "> Servername: " + splt3[0] + Environment.NewLine + "> Version: " + splt3[1] + Environment.NewLine + "> Usermodes: " + splt3[2] + Environment.NewLine + "> Channel Modes: " + splt3[3];
                    Check001Through004();
                    break;
            }
        }
        private void Check001Through004() {
            try {
                if (!string.IsNullOrEmpty(_cachedIrcMessages.l001) && !string.IsNullOrEmpty(_cachedIrcMessages.l002) && !string.IsNullOrEmpty(_cachedIrcMessages.l003) && !string.IsNullOrEmpty(_cachedIrcMessages.l004)) {
                    if(OnDoStatusText != null) {
                        OnDoStatusText("-" + Environment.NewLine + _cachedIrcMessages.l001 + Environment.NewLine + _cachedIrcMessages.l002 + Environment.NewLine + _cachedIrcMessages.l003 + Environment.NewLine + _cachedIrcMessages.l004 + Environment.NewLine + "-");
                    }
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}