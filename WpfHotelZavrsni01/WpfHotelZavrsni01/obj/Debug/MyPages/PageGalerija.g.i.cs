﻿#pragma checksum "..\..\..\MyPages\PageGalerija.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C76270A10C644AC90EC7CE2ECCB06888"
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
using System.Windows.Forms.Integration;
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
using WpfHotelZavrsni01;


namespace WpfHotelZavrsni01 {
    
    
    /// <summary>
    /// PageGalerija
    /// </summary>
    public partial class PageGalerija : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\MyPages\PageGalerija.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel wrap1;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\MyPages\PageGalerija.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border border1;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\MyPages\PageGalerija.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgBorder;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\MyPages\PageGalerija.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonDodajSliku;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\MyPages\PageGalerija.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonPromeniSliku;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\MyPages\PageGalerija.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonIzbrisiSliku;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\MyPages\PageGalerija.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboboxTipSobe;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfHotelZavrsni01;component/mypages/pagegalerija.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MyPages\PageGalerija.xaml"
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
            this.wrap1 = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 2:
            this.border1 = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.imgBorder = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.buttonDodajSliku = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\MyPages\PageGalerija.xaml"
            this.buttonDodajSliku.Click += new System.Windows.RoutedEventHandler(this.buttonDodajSliku_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.buttonPromeniSliku = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\MyPages\PageGalerija.xaml"
            this.buttonPromeniSliku.Click += new System.Windows.RoutedEventHandler(this.buttonPromeniSliku_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.buttonIzbrisiSliku = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\MyPages\PageGalerija.xaml"
            this.buttonIzbrisiSliku.Click += new System.Windows.RoutedEventHandler(this.buttonIzbrisiSliku_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.comboboxTipSobe = ((System.Windows.Controls.ComboBox)(target));
            
            #line 33 "..\..\..\MyPages\PageGalerija.xaml"
            this.comboboxTipSobe.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.comboboxTipSobe_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

