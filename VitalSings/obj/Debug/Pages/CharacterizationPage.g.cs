﻿#pragma checksum "..\..\..\Pages\CharacterizationPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EB5E553071ECDAAED752DFDD8518CECCA802B45A432D25937C052EECA69887D6"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using VitalSings.Pages;


namespace VitalSings.Pages {
    
    
    /// <summary>
    /// CharacterizationPage
    /// </summary>
    public partial class CharacterizationPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 50 "..\..\..\Pages\CharacterizationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox HeightTB;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\Pages\CharacterizationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MassMinusBT;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\Pages\CharacterizationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MassTB;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\Pages\CharacterizationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MassPlusBT;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\Pages\CharacterizationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AgeMinusBT;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\Pages\CharacterizationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AgeTB;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\Pages\CharacterizationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AgePlusBT;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\Pages\CharacterizationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox PurposeCB;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\..\Pages\CharacterizationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NextBT;
        
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
            System.Uri resourceLocater = new System.Uri("/VitalSings;component/pages/characterizationpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\CharacterizationPage.xaml"
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
            
            #line 43 "..\..\..\Pages\CharacterizationPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.HeightMinusBT_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.HeightTB = ((System.Windows.Controls.TextBox)(target));
            
            #line 48 "..\..\..\Pages\CharacterizationPage.xaml"
            this.HeightTB.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.CountTB_TextChanged);
            
            #line default
            #line hidden
            
            #line 49 "..\..\..\Pages\CharacterizationPage.xaml"
            this.HeightTB.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.CountTB_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 55 "..\..\..\Pages\CharacterizationPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.HeightPlusBT_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.MassMinusBT = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\..\Pages\CharacterizationPage.xaml"
            this.MassMinusBT.Click += new System.Windows.RoutedEventHandler(this.MassMinusBT_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.MassTB = ((System.Windows.Controls.TextBox)(target));
            
            #line 70 "..\..\..\Pages\CharacterizationPage.xaml"
            this.MassTB.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.CountTB_TextChanged);
            
            #line default
            #line hidden
            
            #line 72 "..\..\..\Pages\CharacterizationPage.xaml"
            this.MassTB.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.CountTB_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 6:
            this.MassPlusBT = ((System.Windows.Controls.Button)(target));
            
            #line 79 "..\..\..\Pages\CharacterizationPage.xaml"
            this.MassPlusBT.Click += new System.Windows.RoutedEventHandler(this.MassPlusBT_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.AgeMinusBT = ((System.Windows.Controls.Button)(target));
            
            #line 90 "..\..\..\Pages\CharacterizationPage.xaml"
            this.AgeMinusBT.Click += new System.Windows.RoutedEventHandler(this.AgeMinusBT_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.AgeTB = ((System.Windows.Controls.TextBox)(target));
            
            #line 93 "..\..\..\Pages\CharacterizationPage.xaml"
            this.AgeTB.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.CountTB_TextChanged);
            
            #line default
            #line hidden
            
            #line 95 "..\..\..\Pages\CharacterizationPage.xaml"
            this.AgeTB.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.CountTB_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 9:
            this.AgePlusBT = ((System.Windows.Controls.Button)(target));
            
            #line 102 "..\..\..\Pages\CharacterizationPage.xaml"
            this.AgePlusBT.Click += new System.Windows.RoutedEventHandler(this.AgePlusBT_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.PurposeCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            this.NextBT = ((System.Windows.Controls.Button)(target));
            
            #line 111 "..\..\..\Pages\CharacterizationPage.xaml"
            this.NextBT.Click += new System.Windows.RoutedEventHandler(this.NextBT_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

