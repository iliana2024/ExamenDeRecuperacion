﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CrudDeEscuela.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.10.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=DESKTOP-7KCM5EI\\SQLEXPRESS;Initial Catalog=Sistema_De_Escuela;Integra" +
            "ted Security=True;Encrypt=True;TrustServerCertificate=True")]
        public string Sistema_De_EscuelaConnectionString {
            get {
                return ((string)(this["Sistema_De_EscuelaConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=DESKTOP-7KCM5EI\\SQLEXPRESS;Initial Catalog=BDAlumnos;Integrated Secur" +
            "ity=True;Encrypt=True;TrustServerCertificate=True")]
        public string BDAlumnosConnectionString {
            get {
                return ((string)(this["BDAlumnosConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=ILIANA\\MSSQLSERVER01;Initial Catalog=BasedeDatosAlumnos;Integrated Se" +
            "curity=True;Encrypt=True;TrustServerCertificate=True")]
        public string BasedeDatosAlumnosConnectionString {
            get {
                return ((string)(this["BasedeDatosAlumnosConnectionString"]));
            }
        }
    }
}
