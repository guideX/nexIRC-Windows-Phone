﻿#pragma checksum "C:\dev\team-nexgen\nexIRC-Windows-Phone\source\nexIRC\StatusWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DC7985586A2D11EB852D7A8B1CA73CF7"
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
    
    
    public partial class StatusWindow : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.Pivot pvtStatus;
        
        internal Microsoft.Phone.Controls.PivotItem Status;
        
        internal System.Windows.Controls.TextBox txtIncoming;
        
        internal System.Windows.Controls.TextBox txtOutgoing;
        
        internal Microsoft.Phone.Controls.PivotItem Raw;
        
        internal System.Windows.Controls.TextBox txtRawIncoming;
        
        internal System.Windows.Controls.TextBox txtRawOutgoing;
        
        internal Microsoft.Phone.Controls.PivotItem Channel1;
        
        internal System.Windows.Controls.TextBox txtChannel1Incoming;
        
        internal System.Windows.Controls.TextBox txtChannel1Outgoing;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/nexIRC;component/StatusWindow.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.pvtStatus = ((Microsoft.Phone.Controls.Pivot)(this.FindName("pvtStatus")));
            this.Status = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("Status")));
            this.txtIncoming = ((System.Windows.Controls.TextBox)(this.FindName("txtIncoming")));
            this.txtOutgoing = ((System.Windows.Controls.TextBox)(this.FindName("txtOutgoing")));
            this.Raw = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("Raw")));
            this.txtRawIncoming = ((System.Windows.Controls.TextBox)(this.FindName("txtRawIncoming")));
            this.txtRawOutgoing = ((System.Windows.Controls.TextBox)(this.FindName("txtRawOutgoing")));
            this.Channel1 = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("Channel1")));
            this.txtChannel1Incoming = ((System.Windows.Controls.TextBox)(this.FindName("txtChannel1Incoming")));
            this.txtChannel1Outgoing = ((System.Windows.Controls.TextBox)(this.FindName("txtChannel1Outgoing")));
        }
    }
}

