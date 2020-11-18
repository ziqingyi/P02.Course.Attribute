﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace P29.Course.SOA.UnitTestProject.MyWCFTest {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserInfo", Namespace="http://schemas.datacontract.org/2004/07/P29.Course.SOA.Web.Remote")]
    [System.SerializableAttribute()]
    public partial class UserInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AgeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Age {
            get {
                return this.AgeField;
            }
            set {
                if ((this.AgeField.Equals(value) != true)) {
                    this.AgeField = value;
                    this.RaisePropertyChanged("Age");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MyWCFTest.ICustomService")]
    public interface ICustomService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomService/DoWork", ReplyAction="http://tempuri.org/ICustomService/DoWorkResponse")]
        void DoWork();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomService/DoWork", ReplyAction="http://tempuri.org/ICustomService/DoWorkResponse")]
        System.Threading.Tasks.Task DoWorkAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomService/Get", ReplyAction="http://tempuri.org/ICustomService/GetResponse")]
        int Get();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomService/Get", ReplyAction="http://tempuri.org/ICustomService/GetResponse")]
        System.Threading.Tasks.Task<int> GetAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomService/GetUser", ReplyAction="http://tempuri.org/ICustomService/GetUserResponse")]
        P29.Course.SOA.UnitTestProject.MyWCFTest.UserInfo GetUser();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomService/GetUser", ReplyAction="http://tempuri.org/ICustomService/GetUserResponse")]
        System.Threading.Tasks.Task<P29.Course.SOA.UnitTestProject.MyWCFTest.UserInfo> GetUserAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICustomServiceChannel : P29.Course.SOA.UnitTestProject.MyWCFTest.ICustomService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CustomServiceClient : System.ServiceModel.ClientBase<P29.Course.SOA.UnitTestProject.MyWCFTest.ICustomService>, P29.Course.SOA.UnitTestProject.MyWCFTest.ICustomService {
        
        public CustomServiceClient() {
        }
        
        public CustomServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CustomServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CustomServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CustomServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void DoWork() {
            base.Channel.DoWork();
        }
        
        public System.Threading.Tasks.Task DoWorkAsync() {
            return base.Channel.DoWorkAsync();
        }
        
        public int Get() {
            return base.Channel.Get();
        }
        
        public System.Threading.Tasks.Task<int> GetAsync() {
            return base.Channel.GetAsync();
        }
        
        public P29.Course.SOA.UnitTestProject.MyWCFTest.UserInfo GetUser() {
            return base.Channel.GetUser();
        }
        
        public System.Threading.Tasks.Task<P29.Course.SOA.UnitTestProject.MyWCFTest.UserInfo> GetUserAsync() {
            return base.Channel.GetUserAsync();
        }
    }
}