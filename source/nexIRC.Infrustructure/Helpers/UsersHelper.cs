using nexIRC.Infrustructure.Models;
using System;
namespace nexIRC.Infrustructure.Helpers {
    public static class UsersHelper {
        public static bool Authenticate(string emailAddress, string password) {
            try {
                var repo = new UserRepository();
                return repo.Authenticate(emailAddress, password);
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="emailAddress"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static UserModel Get(int userId, string emailAddress, string password) {
            try {
                var repo = new UserRepository();
                return repo.Get(userId, emailAddress, password);
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}