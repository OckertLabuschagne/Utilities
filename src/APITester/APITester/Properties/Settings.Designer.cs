﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APITester.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.10.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string Environemt {
            get {
                return ((string)(this["Environemt"]));
            }
            set {
                this["Environemt"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string Path {
            get {
                return ((string)(this["Path"]));
            }
            set {
                this["Path"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string API {
            get {
                return ((string)(this["API"]));
            }
            set {
                this["API"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string Action {
            get {
                return ((string)(this["Action"]));
            }
            set {
                this["Action"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string URLParameter {
            get {
                return ((string)(this["URLParameter"]));
            }
            set {
                this["URLParameter"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string DownloadDirectory {
            get {
                return ((string)(this["DownloadDirectory"]));
            }
            set {
                this["DownloadDirectory"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("FIAS|apiuser|20181120|DFA68ED137A4A3FE3719106D270A2008")]
        public string UserID {
            get {
                return ((string)(this["UserID"]));
            }
            set {
                this["UserID"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0C3300F0F2C33C868E69509DB551CA0E771CD6CC8122929EE6F52974122603AE")]
        public string UserSecret {
            get {
                return ((string)(this["UserSecret"]));
            }
            set {
                this["UserSecret"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("FIAS")]
        public string SelectedTPA {
            get {
                return ((string)(this["SelectedTPA"]));
            }
            set {
                this["SelectedTPA"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("FIAS,FIAS|apiuser|20181120|DFA68ED137A4A3FE3719106D270A2008,0C3300F0F2C33C868E695" +
            "09DB551CA0E771CD6CC8122929EE6F52974122603AE;AGW,AGW|apiuser|20181210|CEDBC8C1849" +
            "4D24C8F01B116B086F8D3,55EF94F6E71C03F661E28C4D91B7272D67DA76A15D3246D30A7D395688" +
            "7AF78F")]
        public string Users {
            get {
                return ((string)(this["Users"]));
            }
            set {
                this["Users"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("D:\\APITestOutput\\")]
        public string OutputFolder {
            get {
                return ((string)(this["OutputFolder"]));
            }
            set {
                this["OutputFolder"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public int NumberOfTestRuns {
            get {
                return ((int)(this["NumberOfTestRuns"]));
            }
            set {
                this["NumberOfTestRuns"] = value;
            }
        }
    }
}
