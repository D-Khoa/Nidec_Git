﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public string Standard {
            get {
                return ((string)(this["Standard"]));
            }
            set {
                this["Standard"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public string Phantom {
            get {
                return ((string)(this["Phantom"]));
            }
            set {
                this["Phantom"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public string Count {
            get {
                return ((string)(this["Count"]));
            }
            set {
                this["Count"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public string Weight {
            get {
                return ((string)(this["Weight"]));
            }
            set {
                this["Weight"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool LINE_PER_PROCESSWORK_CONSTRAINT {
            get {
                return ((bool)(this["LINE_PER_PROCESSWORK_CONSTRAINT"]));
            }
            set {
                this["LINE_PER_PROCESSWORK_CONSTRAINT"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool MACHINE_PER_PROCESSWORK_CONSTRAINT {
            get {
                return ((bool)(this["MACHINE_PER_PROCESSWORK_CONSTRAINT"]));
            }
            set {
                this["MACHINE_PER_PROCESSWORK_CONSTRAINT"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("UserMaster")]
        public string EXCEL_SHEET_USER_MASTER {
            get {
                return ((string)(this["EXCEL_SHEET_USER_MASTER"]));
            }
            set {
                this["EXCEL_SHEET_USER_MASTER"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Excel_Master_Template.xls")]
        public string TEMPLATE_FILE_MASTER {
            get {
                return ((string)(this["TEMPLATE_FILE_MASTER"]));
            }
            set {
                this["TEMPLATE_FILE_MASTER"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("DefectiveReason")]
        public string EXCEL_SHEET_DEFECTIVE_REASON {
            get {
                return ((string)(this["EXCEL_SHEET_DEFECTIVE_REASON"]));
            }
            set {
                this["EXCEL_SHEET_DEFECTIVE_REASON"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("UserAuthority")]
        public string EXCEL_SHEET_USER_ROLE_AUTHORITY {
            get {
                return ((string)(this["EXCEL_SHEET_USER_ROLE_AUTHORITY"]));
            }
            set {
                this["EXCEL_SHEET_USER_ROLE_AUTHORITY"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Excel_Master_Export_Template.xls")]
        public string EXPORT_TEMPLATE_FILE {
            get {
                return ((string)(this["EXPORT_TEMPLATE_FILE"]));
            }
            set {
                this["EXPORT_TEMPLATE_FILE"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Mold")]
        public string EXCEL_SHEET_MOLD {
            get {
                return ((string)(this["EXCEL_SHEET_MOLD"]));
            }
            set {
                this["EXCEL_SHEET_MOLD"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("LineMaster")]
        public string EXCEL_SHEET_LINE_MASTER {
            get {
                return ((string)(this["EXCEL_SHEET_LINE_MASTER"]));
            }
            set {
                this["EXCEL_SHEET_LINE_MASTER"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("MachineMaster")]
        public string EXCEL_SHEET_MACHINE_MASTER {
            get {
                return ((string)(this["EXCEL_SHEET_MACHINE_MASTER"]));
            }
            set {
                this["EXCEL_SHEET_MACHINE_MASTER"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("SapUser")]
        public string EXCEL_SHEET_SAP_USER {
            get {
                return ((string)(this["EXCEL_SHEET_SAP_USER"]));
            }
            set {
                this["EXCEL_SHEET_SAP_USER"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Standard_Excel_File\\Defective_Standard_Excel_File.xls")]
        public string TEMPLATE_FILE_DEFECTIVE {
            get {
                return ((string)(this["TEMPLATE_FILE_DEFECTIVE"]));
            }
            set {
                this["TEMPLATE_FILE_DEFECTIVE"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Standard_Excel_File\\Line_Standard_Excel_File.xls")]
        public string TEMPLATE_FILE_LINE {
            get {
                return ((string)(this["TEMPLATE_FILE_LINE"]));
            }
            set {
                this["TEMPLATE_FILE_LINE"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Standard_Excel_File\\Machine_Standard_Excel_File.xls")]
        public string TEMPLATE_FILE_MACHINE {
            get {
                return ((string)(this["TEMPLATE_FILE_MACHINE"]));
            }
            set {
                this["TEMPLATE_FILE_MACHINE"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Cavity")]
        public string EXCEL_SHEET_CAVITY {
            get {
                return ((string)(this["EXCEL_SHEET_CAVITY"]));
            }
            set {
                this["EXCEL_SHEET_CAVITY"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Mold")]
        public string TEMPLATE_FILE_MOLD {
            get {
                return ((string)(this["TEMPLATE_FILE_MOLD"]));
            }
            set {
                this["TEMPLATE_FILE_MOLD"] = value;
            }
        }
    }
}
