﻿#pragma checksum "..\..\frmEditor.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1E7F1DD3FCA629B1D7F63CA36905982C02AD39A7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
using e_Tagebuch_2._0;


namespace e_Tagebuch_2._0 {
    
    
    /// <summary>
    /// frmEditor
    /// </summary>
    public partial class frmEditor : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\frmEditor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtName;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\frmEditor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bntChoosePic;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\frmEditor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblPicPath;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\frmEditor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtMain;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\frmEditor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bntClose;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\frmEditor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bntSave;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\frmEditor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bntChoose;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\frmEditor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblDatum;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\frmEditor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpDatepicker;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/e_Tagebuch_2.0;component/frmeditor.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\frmEditor.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.bntChoosePic = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\frmEditor.xaml"
            this.bntChoosePic.Click += new System.Windows.RoutedEventHandler(this.BntChoosePic_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.lblPicPath = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.txtMain = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.bntClose = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\frmEditor.xaml"
            this.bntClose.Click += new System.Windows.RoutedEventHandler(this.BntClose_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.bntSave = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\frmEditor.xaml"
            this.bntSave.Click += new System.Windows.RoutedEventHandler(this.BntSave_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.bntChoose = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\frmEditor.xaml"
            this.bntChoose.Click += new System.Windows.RoutedEventHandler(this.BntChoose_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.lblDatum = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.dpDatepicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

