﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace testPersistenceWF.ServiceReference2 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="checkApp", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class checkApp : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string custNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string prototypeField;
        
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
        public string custName {
            get {
                return this.custNameField;
            }
            set {
                if ((object.ReferenceEquals(this.custNameField, value) != true)) {
                    this.custNameField = value;
                    this.RaisePropertyChanged("custName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string prototype {
            get {
                return this.prototypeField;
            }
            set {
                if ((object.ReferenceEquals(this.prototypeField, value) != true)) {
                    this.prototypeField = value;
                    this.RaisePropertyChanged("prototype");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference2.IGetApp")]
    public interface IGetApp {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetApp/getApp", ReplyAction="http://tempuri.org/IGetApp/getAppResponse")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="returnCustName")]
        string getApp(string custName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetApp/getApp", ReplyAction="http://tempuri.org/IGetApp/getAppResponse")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="returnCustName")]
        System.Threading.Tasks.Task<string> getAppAsync(string custName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGetAppChannel : testPersistenceWF.ServiceReference2.IGetApp, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetAppClient : System.ServiceModel.ClientBase<testPersistenceWF.ServiceReference2.IGetApp>, testPersistenceWF.ServiceReference2.IGetApp {
        
        public GetAppClient() {
        }
        
        public GetAppClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GetAppClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GetAppClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GetAppClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string getApp(string custName) {
            return base.Channel.getApp(custName);
        }
        
        public System.Threading.Tasks.Task<string> getAppAsync(string custName) {
            return base.Channel.getAppAsync(custName);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference2.ICheckApp")]
    public interface ICheckApp {
        
        // CODEGEN: Generating message contract since the operation checkApp is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICheckApp/checkApp", ReplyAction="http://tempuri.org/ICheckApp/checkAppResponse")]
        testPersistenceWF.ServiceReference2.checkAppResponse checkApp(testPersistenceWF.ServiceReference2.checkAppRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICheckApp/checkApp", ReplyAction="http://tempuri.org/ICheckApp/checkAppResponse")]
        System.Threading.Tasks.Task<testPersistenceWF.ServiceReference2.checkAppResponse> checkAppAsync(testPersistenceWF.ServiceReference2.checkAppRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class checkAppRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public testPersistenceWF.ServiceReference2.checkApp checkApp;
        
        public checkAppRequest() {
        }
        
        public checkAppRequest(testPersistenceWF.ServiceReference2.checkApp checkApp) {
            this.checkApp = checkApp;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class checkAppResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://schemas.microsoft.com/2003/10/Serialization/", Order=0)]
        public string @string;
        
        public checkAppResponse() {
        }
        
        public checkAppResponse(string @string) {
            this.@string = @string;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICheckAppChannel : testPersistenceWF.ServiceReference2.ICheckApp, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CheckAppClient : System.ServiceModel.ClientBase<testPersistenceWF.ServiceReference2.ICheckApp>, testPersistenceWF.ServiceReference2.ICheckApp {
        
        public CheckAppClient() {
        }
        
        public CheckAppClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CheckAppClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CheckAppClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CheckAppClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        testPersistenceWF.ServiceReference2.checkAppResponse testPersistenceWF.ServiceReference2.ICheckApp.checkApp(testPersistenceWF.ServiceReference2.checkAppRequest request) {
            return base.Channel.checkApp(request);
        }
        
        public string checkApp(testPersistenceWF.ServiceReference2.checkApp checkApp1) {
            testPersistenceWF.ServiceReference2.checkAppRequest inValue = new testPersistenceWF.ServiceReference2.checkAppRequest();
            inValue.checkApp = checkApp1;
            testPersistenceWF.ServiceReference2.checkAppResponse retVal = ((testPersistenceWF.ServiceReference2.ICheckApp)(this)).checkApp(inValue);
            return retVal.@string;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<testPersistenceWF.ServiceReference2.checkAppResponse> testPersistenceWF.ServiceReference2.ICheckApp.checkAppAsync(testPersistenceWF.ServiceReference2.checkAppRequest request) {
            return base.Channel.checkAppAsync(request);
        }
        
        public System.Threading.Tasks.Task<testPersistenceWF.ServiceReference2.checkAppResponse> checkAppAsync(testPersistenceWF.ServiceReference2.checkApp checkApp) {
            testPersistenceWF.ServiceReference2.checkAppRequest inValue = new testPersistenceWF.ServiceReference2.checkAppRequest();
            inValue.checkApp = checkApp;
            return ((testPersistenceWF.ServiceReference2.ICheckApp)(this)).checkAppAsync(inValue);
        }
    }
}
