﻿#pragma checksum "C:\dev\team-nexgen\nexIRC-Windows-Phone\source\nexIRC\frmMainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "918E499CA44407EAC6654FB344A116BD"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace nexIRC {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.LongListSelector lstNetwork;
        
        internal Microsoft.Phone.Controls.PanoramaItem piSettings;
        
        internal System.Windows.Controls.Border btnServersAndNetworks;
        
        internal System.Windows.Controls.TextBlock tblServersAndNetworks;
        
        internal System.Windows.Controls.Border btnUser;
        
        internal System.Windows.Controls.TextBlock tblUser;
        
        internal System.Windows.Controls.Border btnSettings;
        
        internal System.Windows.Controls.TextBlock tblSettings;
        
        internal System.Windows.Controls.Border btnText;
        
        internal System.Windows.Controls.TextBlock tblText;
        
        internal System.Windows.Controls.Border btnDcc;
        
        internal System.Windows.Controls.TextBlock tblDcc;
        
        internal System.Windows.Controls.Border btnNotify;
        
        internal System.Windows.Controls.TextBlock tblNotify;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/nexIRC;component/frmMainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.lstNetwork = ((Microsoft.Phone.Controls.LongListSelector)(this.FindName("lstNetwork")));
            this.piSettings = ((Microsoft.Phone.Controls.PanoramaItem)(this.FindName("piSettings")));
            this.btnServersAndNetworks = ((System.Windows.Controls.Border)(this.FindName("btnServersAndNetworks")));
            this.tblServersAndNetworks = ((System.Windows.Controls.TextBlock)(this.FindName("tblServersAndNetworks")));
            this.btnUser = ((System.Windows.Controls.Border)(this.FindName("btnUser")));
            this.tblUser = ((System.Windows.Controls.TextBlock)(this.FindName("tblUser")));
            this.btnSettings = ((System.Windows.Controls.Border)(this.FindName("btnSettings")));
            this.tblSettings = ((System.Windows.Controls.TextBlock)(this.FindName("tblSettings")));
            this.btnText = ((System.Windows.Controls.Border)(this.FindName("btnText")));
            this.tblText = ((System.Windows.Controls.TextBlock)(this.FindName("tblText")));
            this.btnDcc = ((System.Windows.Controls.Border)(this.FindName("btnDcc")));
            this.tblDcc = ((System.Windows.Controls.TextBlock)(this.FindName("tblDcc")));
            this.btnNotify = ((System.Windows.Controls.Border)(this.FindName("btnNotify")));
            this.tblNotify = ((System.Windows.Controls.TextBlock)(this.FindName("tblNotify")));
        }
    }
}
