using System.Collections.Generic;
namespace nexIRC.Infrustructure.Models {
    public class IrcSettings {
        public string Nickname { get; set; }
        public string AltNickname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public IrcServerInfoModel IrcServerInfoModel { get; set; }
        public string QuitMessage { get; set; }
        public List<string> RawText { get; set; }
    }
}