﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebSafe.WSMedicos {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WSMedicos.IWSMedicos")]
    public interface IWSMedicos {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWSMedicos/ObtenerMedico", ReplyAction="http://tempuri.org/IWSMedicos/ObtenerMedicoResponse")]
        string ObtenerMedico(int ID_MEDICO);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWSMedicos/ObtenerMedico", ReplyAction="http://tempuri.org/IWSMedicos/ObtenerMedicoResponse")]
        System.Threading.Tasks.Task<string> ObtenerMedicoAsync(int ID_MEDICO);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWSMedicosChannel : WebSafe.WSMedicos.IWSMedicos, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WSMedicosClient : System.ServiceModel.ClientBase<WebSafe.WSMedicos.IWSMedicos>, WebSafe.WSMedicos.IWSMedicos {
        
        public WSMedicosClient() {
        }
        
        public WSMedicosClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WSMedicosClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WSMedicosClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WSMedicosClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string ObtenerMedico(int ID_MEDICO) {
            return base.Channel.ObtenerMedico(ID_MEDICO);
        }
        
        public System.Threading.Tasks.Task<string> ObtenerMedicoAsync(int ID_MEDICO) {
            return base.Channel.ObtenerMedicoAsync(ID_MEDICO);
        }
    }
}