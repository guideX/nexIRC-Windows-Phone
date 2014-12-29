using nexIRC.Infrustructure.Models;
using System;
namespace nexIRC.Infrustructure.Helpers {

    public class IrcStringHelper {
        public delegate void DoStatusText(string data);
        public event DoStatusText OnDoStatusText;

    }
}