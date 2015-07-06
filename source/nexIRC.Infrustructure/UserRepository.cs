using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
//using System.Web.Script.Serialization;
using nexIRC.Infrustructure.Models;
using Win8WinPhone.CodeShare.Extensions;
namespace nexIRC.Infrustructure {
    /// <summary>
    /// User Repository
    /// </summary>
    public class UserRepository {
        /// <summary>
        /// Get Data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private async Task<string> GetData(string url) {
            try {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = HttpMethod.Get;
                var response = (HttpWebResponse)await request.GetResponseAsync();
                using (var sr = new StreamReader(response.GetResponseStream())) {
                    return sr.ReadToEnd();
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Get By UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserModel Get(int userId, string emailAddress, string password) {
            try {
                var d = GetData("http://team-nexgen.org/Services/user.svc/Get?userId=" + userId.ToString() + "&emailaddress=" + emailAddress + "&password=" + password);
                using (var memStream = new MemoryStream(Encoding.UTF8.GetBytes(d.ToString()))) {
                    var serializer = new DataContractJsonSerializer(typeof(UserModel));
                    var userModel = (UserModel)serializer.ReadObject(memStream);
                    return userModel;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Get By UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool Authenticate(string emailAddress, string password) {
            try {
                var d = GetData("http://team-nexgen.org/Services/user.svc/Authenticate?emailaddress=" + emailAddress + "&password=" + password);
                using (var memStream = new MemoryStream(Encoding.UTF8.GetBytes(d.ToString()))) {
                    var serializer = new DataContractJsonSerializer(typeof(UserModel));
                    var result = (bool)serializer.ReadObject(memStream);
                    return result;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}