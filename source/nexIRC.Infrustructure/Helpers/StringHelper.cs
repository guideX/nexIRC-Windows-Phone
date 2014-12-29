using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace nexIRC.Infrustructure.Helpers {
    public static class StringHelper {
        /// <summary>
        /// Parse Data
        /// </summary>
        /// <param name="whole"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static string ParseData(string whole, string start, string end) {
            try {
                if (whole.Length != 0) {
                    var i = whole.IndexOf(start);
                    var n = whole.IndexOf(end);
                    var msg = Right(whole, whole.Length - i);
                    var msg2 = Right(whole, whole.Length - n);
                    if (msg2.Length < msg.Length) {
                        return Left(msg, msg.Length - msg2.Length - 1);
                    } else {
                        return "";
                    }
                } else {
                    return "";
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
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