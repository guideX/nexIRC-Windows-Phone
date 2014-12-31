using System;
using System.Linq;
using System.Windows;
namespace nexIRC.Infrustructure.Controllers {
    public class CommandController {
        public CommandController() {
            try {
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void StatusCommand(string data) {
            try {
                var splt = data.Split(' ');
                if (splt.Count() != 0) {
                    var command = splt.First().ToLower().Trim();
                    switch (command) {
                        case "test":
                            //MessageBox.Show("BLAH!");
                            break;
                    }
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}