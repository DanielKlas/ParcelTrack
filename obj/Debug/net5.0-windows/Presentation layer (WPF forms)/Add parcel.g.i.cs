﻿#pragma checksum "..\..\..\..\Presentation layer (WPF forms)\Add parcel.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FA753F658F1A472E0FEEEFA54A5350E1C74B07C9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ParcelTrack;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ParcelTrack {
    
    
    /// <summary>
    /// AddParcel
    /// </summary>
    public partial class AddParcel : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\..\Presentation layer (WPF forms)\Add parcel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtbox_street;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Presentation layer (WPF forms)\Add parcel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtbox_postcode;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Presentation layer (WPF forms)\Add parcel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtbox_receiverName;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Presentation layer (WPF forms)\Add parcel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtbox_senderName;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Presentation layer (WPF forms)\Add parcel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_add_parcel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.11.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ParcelTrack;component/presentation%20layer%20(wpf%20forms)/add%20parcel.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Presentation layer (WPF forms)\Add parcel.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.11.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtbox_street = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtbox_postcode = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtbox_receiverName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtbox_senderName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.btn_add_parcel = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\..\Presentation layer (WPF forms)\Add parcel.xaml"
            this.btn_add_parcel.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

