using System;
using System.Collections.Generic;
namespace nexIRC.Infrustructure.Models {
    /// <summary>
    /// User Settings
    /// </summary>
    public class UserSettingsModel {
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
                try {
                    if (!string.IsNullOrEmpty(_nickname)) {
                        return _nickname;
                    } else {
                        return "";
                    }
                } catch (Exception ex) {
                    throw ex;
                }
            }
            set {
                try {
                    _nickname = value;
                } catch (Exception ex) {
                    throw ex;
                }
            }
        }
        /// <summary>
        /// AltNickname
        /// </summary>
        public string AltNickname { 
            get {
                try {
                    if (!string.IsNullOrEmpty(_altNickname)) {
                        return _altNickname;
                    } else {
                        return "";
                    }
                } catch (Exception ex) {
                    throw ex;
                }
            }
            set {
                try {
                    _altNickname = value;
                } catch (Exception ex) {
                    throw ex;
                }
            }
        }
        /// <summary>
        /// Username
        /// </summary>
        public string Username {
            get {
                try {
                    if (!string.IsNullOrEmpty(_username)) {
                        return _username;
                    } else {
                        return "";
                    }
                } catch (Exception ex) {
                    throw ex;
                }
            }
            set {
                try {
                    _username = value;
                } catch (Exception ex) {
                    throw ex;
                }
            }
        }
        /// <summary>
        /// Password
        /// </summary>
        public string Password { 
            get {
                try {
                    if (!string.IsNullOrEmpty(_password)) {
                        return _password;
                    } else {
                        return "";
                    }
                } catch (Exception ex) {
                    throw ex;
                }
            }
            set {
                try {
                    _password = value;
                } catch (Exception ex) {
                    throw ex;
                }
            }
        }
        /// <summary>
        /// Quit Message
        /// </summary>
        public string QuitMessage {
            get {
                try {
                    if (!string.IsNullOrEmpty(_quitMessage)) {
                        return _quitMessage;
                    } else {
                        return "";
                    }
                } catch (Exception ex) {
                    throw ex;
                }
            }
            set {
                try {
                    _quitMessage = value;
                } catch (Exception ex) {
                    throw ex;
                }
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