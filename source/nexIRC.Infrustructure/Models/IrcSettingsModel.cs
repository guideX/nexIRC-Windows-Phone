using System;
using System.Collections.Generic;
namespace nexIRC.Infrustructure.Models {
    public class IrcSettings {
        private string _nickname = "";
        private string _altNickname = "";
        private string _username = "";
        private string _password = "";
        private string _quitMessage = "";
        public IrcSettings() {
            try {
                RawText = new List<string>();
            } catch (Exception ex) {
                throw ex;
            }
        }
        public string Nickname {
            get {
                if (!string.IsNullOrEmpty(_nickname)) {
                    return _nickname;
                } else {
                    return "";
                }
            }
            set {
                _nickname = value;
            }
        }
        public string AltNickname { 
            get {
                if (!string.IsNullOrEmpty(_altNickname)) {
                    return _altNickname;
                } else {
                    return "";
                }
            }
            set {
                _altNickname = value;
            }
        }
        public string Username {
            get {
                if (!string.IsNullOrEmpty(_username)) {
                    return _username;
                } else {
                    return "";
                }
            }
            set {
                _username = value;
            }
        }
        public string Password { 
            get {
                if (!string.IsNullOrEmpty(_password)) {
                    return _password;
                } else {
                    return "";
                }
            }
            set {
                _password = value;
            }
        }
        public string QuitMessage {
            get {
                if (!string.IsNullOrEmpty(_quitMessage)) {
                    return _quitMessage;
                } else {
                    return "";
                }
            }
            set {
                _quitMessage = value;
            }
        }
        public bool IsValid() {
            try {
                if (string.IsNullOrEmpty(_nickname)) {
                    return false;
                }
                if (string.IsNullOrEmpty(_username)) {
                    return false;
                }
                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public IrcServerInfoModel IrcServerInfoModel { get; set; }
        public List<string> RawText { get; set; }
    }
}