using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace nexIRC.Infrustructure.Helpers {
    public static class StringHelper {
        /// <summary>
        /// VB Left Equiv
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Left(this string str, int length) {
            try {
                str = (str ?? string.Empty);
                return str.Substring(0, Math.Min(length, str.Length));
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// VB Right Equiv
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Right(this string str, int length) {
            try {
                str = (str ?? string.Empty);
                return (str.Length >= length)
                    ? str.Substring(str.Length - length, length)
                    : str;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}