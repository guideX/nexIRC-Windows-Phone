using System;
using System.Collections.Generic;
namespace nexIRC.Infrustructure.Models {
    /// <summary>
    /// Irc Settings
    /// </summary>
    public class UserSettingsModel {
        /// <summary>
        /// Irc Server Info Model
        /// </summary>
        //public IrcServerInfoModel IrcServerInfoModel { get; set; }
        /// <summary>
        /// Raw Text
        /// </summary>
        public List<string> RawText { get; set; }        
        private string _nickname = "";
        private string _altNickname = "";
        private string _username = "";
        private string _password = "";
        private string _quitMessage = "";
        /// <summary>
        /// Entry Point
        /// </summary>
        public UserSettingsModel() {
            try {
                RawText = new List<string>();
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Nickname
        /// </summary>
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
        /// <summary>
        /// AltNickname
        /// </summary>
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
        /// <summary>
        /// Username
        /// </summary>
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
        /// <summary>
        /// Password
        /// </summary>
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
        /// <summary>
        /// Quit Message
        /// </summary>
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
        /// <summary>
        /// Is Valid
        /// </summary>
        /// <returns></returns>
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
    }
}