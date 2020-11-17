﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace P29.Course.SOA.UnitTestProject.MyWebServiceTest {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MyWebServiceTest.MyWebServiceSoap")]
    public interface MyWebServiceSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        System.Threading.Tasks.Task<string> HelloWorldAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorldWithAuth", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorldWithAuth(string name_password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorldWithAuth", ReplyAction="*")]
        System.Threading.Tasks.Task<string> HelloWorldWithAuthAsync(string name_password);
        
        // CODEGEN: Generating message contract since message GetNameByIdRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetNameById", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetNameByIdResponse GetNameById(P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetNameByIdRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetNameById", ReplyAction="*")]
        System.Threading.Tasks.Task<P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetNameByIdResponse> GetNameByIdAsync(P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetNameByIdRequest request);
        
        // CODEGEN: Generating message contract since message GetUserObjByIdRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetUserObjById", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetUserObjByIdResponse GetUserObjById(P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetUserObjByIdRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetUserObjById", ReplyAction="*")]
        System.Threading.Tasks.Task<P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetUserObjByIdResponse> GetUserObjByIdAsync(P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetUserObjByIdRequest request);
        
        // CODEGEN: Generating message contract since message GetuserListRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetuserList", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetuserListResponse GetuserList(P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetuserListRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetuserList", ReplyAction="*")]
        System.Threading.Tasks.Task<P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetuserListResponse> GetuserListAsync(P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetuserListRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Plus", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int Plus(int x, int y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Plus", ReplyAction="*")]
        System.Threading.Tasks.Task<int> PlusAsync(int x, int y);
        
        // CODEGEN: Generating message contract since message GetJsonInfoRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetJsonInfo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetJsonInfoResponse GetJsonInfo(P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetJsonInfoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetJsonInfo", ReplyAction="*")]
        System.Threading.Tasks.Task<P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetJsonInfoResponse> GetJsonInfoAsync(P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetJsonInfoRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class CustomSoapHeader : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string userNameField;
        
        private string passWordField;
        
        private System.Xml.XmlAttribute[] anyAttrField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string UserName {
            get {
                return this.userNameField;
            }
            set {
                this.userNameField = value;
                this.RaisePropertyChanged("UserName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string PassWord {
            get {
                return this.passWordField;
            }
            set {
                this.passWordField = value;
                this.RaisePropertyChanged("PassWord");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr {
            get {
                return this.anyAttrField;
            }
            set {
                this.anyAttrField = value;
                this.RaisePropertyChanged("AnyAttr");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class UserInfo : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int idField;
        
        private string nameField;
        
        private int ageField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
                this.RaisePropertyChanged("Id");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
                this.RaisePropertyChanged("Name");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int Age {
            get {
                return this.ageField;
            }
            set {
                this.ageField = value;
                this.RaisePropertyChanged("Age");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetNameById", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetNameByIdRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public P29.Course.SOA.UnitTestProject.MyWebServiceTest.CustomSoapHeader CustomSoapHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public int id;
        
        public GetNameByIdRequest() {
        }
        
        public GetNameByIdRequest(P29.Course.SOA.UnitTestProject.MyWebServiceTest.CustomSoapHeader CustomSoapHeader, int id) {
            this.CustomSoapHeader = CustomSoapHeader;
            this.id = id;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetNameByIdResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetNameByIdResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string GetNameByIdResult;
        
        public GetNameByIdResponse() {
        }
        
        public GetNameByIdResponse(string GetNameByIdResult) {
            this.GetNameByIdResult = GetNameByIdResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetUserObjById", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetUserObjByIdRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public P29.Course.SOA.UnitTestProject.MyWebServiceTest.CustomSoapHeader CustomSoapHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public int id;
        
        public GetUserObjByIdRequest() {
        }
        
        public GetUserObjByIdRequest(P29.Course.SOA.UnitTestProject.MyWebServiceTest.CustomSoapHeader CustomSoapHeader, int id) {
            this.CustomSoapHeader = CustomSoapHeader;
            this.id = id;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetUserObjByIdResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetUserObjByIdResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public P29.Course.SOA.UnitTestProject.MyWebServiceTest.UserInfo GetUserObjByIdResult;
        
        public GetUserObjByIdResponse() {
        }
        
        public GetUserObjByIdResponse(P29.Course.SOA.UnitTestProject.MyWebServiceTest.UserInfo GetUserObjByIdResult) {
            this.GetUserObjByIdResult = GetUserObjByIdResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetuserList", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetuserListRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public P29.Course.SOA.UnitTestProject.MyWebServiceTest.CustomSoapHeader CustomSoapHeader;
        
        public GetuserListRequest() {
        }
        
        public GetuserListRequest(P29.Course.SOA.UnitTestProject.MyWebServiceTest.CustomSoapHeader CustomSoapHeader) {
            this.CustomSoapHeader = CustomSoapHeader;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetuserListResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetuserListResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public P29.Course.SOA.UnitTestProject.MyWebServiceTest.UserInfo[] GetuserListResult;
        
        public GetuserListResponse() {
        }
        
        public GetuserListResponse(P29.Course.SOA.UnitTestProject.MyWebServiceTest.UserInfo[] GetuserListResult) {
            this.GetuserListResult = GetuserListResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetJsonInfo", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetJsonInfoRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public P29.Course.SOA.UnitTestProject.MyWebServiceTest.CustomSoapHeader CustomSoapHeader;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public int id;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string name;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public int age;
        
        public GetJsonInfoRequest() {
        }
        
        public GetJsonInfoRequest(P29.Course.SOA.UnitTestProject.MyWebServiceTest.CustomSoapHeader CustomSoapHeader, int id, string name, int age) {
            this.CustomSoapHeader = CustomSoapHeader;
            this.id = id;
            this.name = name;
            this.age = age;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetJsonInfoResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetJsonInfoResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string GetJsonInfoResult;
        
        public GetJsonInfoResponse() {
        }
        
        public GetJsonInfoResponse(string GetJsonInfoResult) {
            this.GetJsonInfoResult = GetJsonInfoResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface MyWebServiceSoapChannel : P29.Course.SOA.UnitTestProject.MyWebServiceTest.MyWebServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MyWebServiceSoapClient : System.ServiceModel.ClientBase<P29.Course.SOA.UnitTestProject.MyWebServiceTest.MyWebServiceSoap>, P29.Course.SOA.UnitTestProject.MyWebServiceTest.MyWebServiceSoap {
        
        public MyWebServiceSoapClient() {
        }
        
        public MyWebServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MyWebServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MyWebServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MyWebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public System.Threading.Tasks.Task<string> HelloWorldAsync() {
            return base.Channel.HelloWorldAsync();
        }
        
        public string HelloWorldWithAuth(string name_password) {
            return base.Channel.HelloWorldWithAuth(name_password);
        }
        
        public System.Threading.Tasks.Task<string> HelloWorldWithAuthAsync(string name_password) {
            return base.Channel.HelloWorldWithAuthAsync(name_password);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetNameByIdResponse P29.Course.SOA.UnitTestProject.MyWebServiceTest.MyWebServiceSoap.GetNameById(P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetNameByIdRequest request) {
            return base.Channel.GetNameById(request);
        }
        
        public string GetNameById(P29.Course.SOA.UnitTestProject.MyWebServiceTest.CustomSoapHeader CustomSoapHeader, int id) {
            P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetNameByIdRequest inValue = new P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetNameByIdRequest();
            inValue.CustomSoapHeader = CustomSoapHeader;
            inValue.id = id;
            P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetNameByIdResponse retVal = ((P29.Course.SOA.UnitTestProject.MyWebServiceTest.MyWebServiceSoap)(this)).GetNameById(inValue);
            return retVal.GetNameByIdResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetNameByIdResponse> P29.Course.SOA.UnitTestProject.MyWebServiceTest.MyWebServiceSoap.GetNameByIdAsync(P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetNameByIdRequest request) {
            return base.Channel.GetNameByIdAsync(request);
        }
        
        public System.Threading.Tasks.Task<P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetNameByIdResponse> GetNameByIdAsync(P29.Course.SOA.UnitTestProject.MyWebServiceTest.CustomSoapHeader CustomSoapHeader, int id) {
            P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetNameByIdRequest inValue = new P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetNameByIdRequest();
            inValue.CustomSoapHeader = CustomSoapHeader;
            inValue.id = id;
            return ((P29.Course.SOA.UnitTestProject.MyWebServiceTest.MyWebServiceSoap)(this)).GetNameByIdAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetUserObjByIdResponse P29.Course.SOA.UnitTestProject.MyWebServiceTest.MyWebServiceSoap.GetUserObjById(P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetUserObjByIdRequest request) {
            return base.Channel.GetUserObjById(request);
        }
        
        public P29.Course.SOA.UnitTestProject.MyWebServiceTest.UserInfo GetUserObjById(P29.Course.SOA.UnitTestProject.MyWebServiceTest.CustomSoapHeader CustomSoapHeader, int id) {
            P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetUserObjByIdRequest inValue = new P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetUserObjByIdRequest();
            inValue.CustomSoapHeader = CustomSoapHeader;
            inValue.id = id;
            P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetUserObjByIdResponse retVal = ((P29.Course.SOA.UnitTestProject.MyWebServiceTest.MyWebServiceSoap)(this)).GetUserObjById(inValue);
            return retVal.GetUserObjByIdResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetUserObjByIdResponse> P29.Course.SOA.UnitTestProject.MyWebServiceTest.MyWebServiceSoap.GetUserObjByIdAsync(P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetUserObjByIdRequest request) {
            return base.Channel.GetUserObjByIdAsync(request);
        }
        
        public System.Threading.Tasks.Task<P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetUserObjByIdResponse> GetUserObjByIdAsync(P29.Course.SOA.UnitTestProject.MyWebServiceTest.CustomSoapHeader CustomSoapHeader, int id) {
            P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetUserObjByIdRequest inValue = new P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetUserObjByIdRequest();
            inValue.CustomSoapHeader = CustomSoapHeader;
            inValue.id = id;
            return ((P29.Course.SOA.UnitTestProject.MyWebServiceTest.MyWebServiceSoap)(this)).GetUserObjByIdAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetuserListResponse P29.Course.SOA.UnitTestProject.MyWebServiceTest.MyWebServiceSoap.GetuserList(P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetuserListRequest request) {
            return base.Channel.GetuserList(request);
        }
        
        public P29.Course.SOA.UnitTestProject.MyWebServiceTest.UserInfo[] GetuserList(P29.Course.SOA.UnitTestProject.MyWebServiceTest.CustomSoapHeader CustomSoapHeader) {
            P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetuserListRequest inValue = new P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetuserListRequest();
            inValue.CustomSoapHeader = CustomSoapHeader;
            P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetuserListResponse retVal = ((P29.Course.SOA.UnitTestProject.MyWebServiceTest.MyWebServiceSoap)(this)).GetuserList(inValue);
            return retVal.GetuserListResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetuserListResponse> P29.Course.SOA.UnitTestProject.MyWebServiceTest.MyWebServiceSoap.GetuserListAsync(P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetuserListRequest request) {
            return base.Channel.GetuserListAsync(request);
        }
        
        public System.Threading.Tasks.Task<P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetuserListResponse> GetuserListAsync(P29.Course.SOA.UnitTestProject.MyWebServiceTest.CustomSoapHeader CustomSoapHeader) {
            P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetuserListRequest inValue = new P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetuserListRequest();
            inValue.CustomSoapHeader = CustomSoapHeader;
            return ((P29.Course.SOA.UnitTestProject.MyWebServiceTest.MyWebServiceSoap)(this)).GetuserListAsync(inValue);
        }
        
        public int Plus(int x, int y) {
            return base.Channel.Plus(x, y);
        }
        
        public System.Threading.Tasks.Task<int> PlusAsync(int x, int y) {
            return base.Channel.PlusAsync(x, y);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetJsonInfoResponse P29.Course.SOA.UnitTestProject.MyWebServiceTest.MyWebServiceSoap.GetJsonInfo(P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetJsonInfoRequest request) {
            return base.Channel.GetJsonInfo(request);
        }
        
        public string GetJsonInfo(P29.Course.SOA.UnitTestProject.MyWebServiceTest.CustomSoapHeader CustomSoapHeader, int id, string name, int age) {
            P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetJsonInfoRequest inValue = new P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetJsonInfoRequest();
            inValue.CustomSoapHeader = CustomSoapHeader;
            inValue.id = id;
            inValue.name = name;
            inValue.age = age;
            P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetJsonInfoResponse retVal = ((P29.Course.SOA.UnitTestProject.MyWebServiceTest.MyWebServiceSoap)(this)).GetJsonInfo(inValue);
            return retVal.GetJsonInfoResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetJsonInfoResponse> P29.Course.SOA.UnitTestProject.MyWebServiceTest.MyWebServiceSoap.GetJsonInfoAsync(P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetJsonInfoRequest request) {
            return base.Channel.GetJsonInfoAsync(request);
        }
        
        public System.Threading.Tasks.Task<P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetJsonInfoResponse> GetJsonInfoAsync(P29.Course.SOA.UnitTestProject.MyWebServiceTest.CustomSoapHeader CustomSoapHeader, int id, string name, int age) {
            P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetJsonInfoRequest inValue = new P29.Course.SOA.UnitTestProject.MyWebServiceTest.GetJsonInfoRequest();
            inValue.CustomSoapHeader = CustomSoapHeader;
            inValue.id = id;
            inValue.name = name;
            inValue.age = age;
            return ((P29.Course.SOA.UnitTestProject.MyWebServiceTest.MyWebServiceSoap)(this)).GetJsonInfoAsync(inValue);
        }
    }
}
