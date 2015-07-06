using System;
namespace nexIRC.Infrustructure.Models {
    public class UserModel {
        /// <summary>
        /// User Id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Email Address
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Irc User
        /// </summary>
        public string IrcUser { get; set; }
        /// <summary>
        /// Irc Real name
        /// </summary>
        public string IrcRealName { get; set; }
        /// <summary>
        /// Irc Host name
        /// </summary>
        public string IrcHostName { get; set; }
        /// <summary>
        /// Irc Server Name
        /// </summary>
        public string IrcServerName { get; set; }
        /// <summary>
        /// Nickname
        /// </summary>
        public string Nickname { get; set; }
    }
}