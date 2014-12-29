using System;
using nexIRC.Infrustructure.Helpers;
using nexIRC.Infrustructure.Models;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
namespace nexIRC.Infrustructure.Controllers {
    public class StatusController {
        public delegate void SendDataEvent(string data);
        public event SendDataEvent SendData;
        public delegate void RawEvent(string data);
        public event RawEvent RawEvt;
        public delegate void DisconnectedEvent();
        public event DisconnectedEvent DisconnectedEvt;
        public void Status_DataArrival(string data) {
            try {
                if (string.IsNullOrEmpty(data)) {
                    return;
                }
                if (StringHelper.Left(data.ToLower(), 21) == "error :closing link: ") {
                    if (DisconnectedEvt != null) {
                        DisconnectedEvt();
                    }
                }
                if (Regex.IsMatch(data, "PING :[0-9]+\\r\\n")) {
                    ReplyPong(data);
                }
                RawEvt(data);
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
        private void ReplyPong(string message) {
            try {
                var pingCode = Regex.Match(message, "[0-9]+");
                if (SendData != null) {
                    SendData("PONG :" + pingCode);
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void SendIdentity(IrcSettings settings) {
            try {
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