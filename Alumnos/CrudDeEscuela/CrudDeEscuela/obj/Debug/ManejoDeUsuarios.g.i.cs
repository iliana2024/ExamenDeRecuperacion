﻿#pragma checksum "..\..\ManejoDeUsuarios.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "866735CA8CEE82C03614A160FEDE3718918326F167598C3A50D3E543D78AA969"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using CrudDeEscuela;
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


namespace CrudDeEscuela {
    
    
    /// <summary>
    /// ManejoDeUsuarios
    /// </summary>
    public partial class ManejoDeUsuarios : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\ManejoDeUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListaDeUsuarios;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\ManejoDeUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnInsertarUsuario;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\ManejoDeUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnBorrarUsuario;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\ManejoDeUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtInsertarUsuario;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\ManejoDeUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnActualizarUsuario;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\ManejoDeUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnRegresarAInicio;
        
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
            System.Uri resourceLocater = new System.Uri("/CrudDeEscuela;component/manejodeusuarios.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ManejoDeUsuarios.xaml"
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
            this.ListaDeUsuarios = ((System.Windows.Controls.ListBox)(target));
            return;
            case 2:
            this.BtnInsertarUsuario = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\ManejoDeUsuarios.xaml"
            this.BtnInsertarUsuario.Click += new System.Windows.RoutedEventHandler(this.BtnInsertarUsuario_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BtnBorrarUsuario = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\ManejoDeUsuarios.xaml"
            this.BtnBorrarUsuario.Click += new System.Windows.RoutedEventHandler(this.BtnBorrarUsuario_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TxtInsertarUsuario = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.BtnActualizarUsuario = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\ManejoDeUsuarios.xaml"
            this.BtnActualizarUsuario.Click += new System.Windows.RoutedEventHandler(this.BtnActualizarUsuario_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BtnRegresarAInicio = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\ManejoDeUsuarios.xaml"
            this.BtnRegresarAInicio.Click += new System.Windows.RoutedEventHandler(this.BtnRegresarAInicio_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

