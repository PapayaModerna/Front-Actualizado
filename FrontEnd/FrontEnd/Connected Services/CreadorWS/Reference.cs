﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FrontEnd.CreadorWS {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://bibliows.biblioteca.syntaxerror.com/", ConfigurationName="CreadorWS.CreadorWS")]
    public interface CreadorWS {
        
        // CODEGEN: El parámetro 'return' requiere información adicional de esquema que no se puede capturar con el modo de parámetros. El atributo específico es 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://bibliows.biblioteca.syntaxerror.com/CreadorWS/modificarCreadorRequest", ReplyAction="http://bibliows.biblioteca.syntaxerror.com/CreadorWS/modificarCreadorResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        FrontEnd.CreadorWS.modificarCreadorResponse modificarCreador(FrontEnd.CreadorWS.modificarCreadorRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bibliows.biblioteca.syntaxerror.com/CreadorWS/modificarCreadorRequest", ReplyAction="http://bibliows.biblioteca.syntaxerror.com/CreadorWS/modificarCreadorResponse")]
        System.Threading.Tasks.Task<FrontEnd.CreadorWS.modificarCreadorResponse> modificarCreadorAsync(FrontEnd.CreadorWS.modificarCreadorRequest request);
        
        // CODEGEN: El parámetro 'return' requiere información adicional de esquema que no se puede capturar con el modo de parámetros. El atributo específico es 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://bibliows.biblioteca.syntaxerror.com/CreadorWS/insertarCreadorRequest", ReplyAction="http://bibliows.biblioteca.syntaxerror.com/CreadorWS/insertarCreadorResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        FrontEnd.CreadorWS.insertarCreadorResponse insertarCreador(FrontEnd.CreadorWS.insertarCreadorRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bibliows.biblioteca.syntaxerror.com/CreadorWS/insertarCreadorRequest", ReplyAction="http://bibliows.biblioteca.syntaxerror.com/CreadorWS/insertarCreadorResponse")]
        System.Threading.Tasks.Task<FrontEnd.CreadorWS.insertarCreadorResponse> insertarCreadorAsync(FrontEnd.CreadorWS.insertarCreadorRequest request);
        
        // CODEGEN: El parámetro 'return' requiere información adicional de esquema que no se puede capturar con el modo de parámetros. El atributo específico es 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://bibliows.biblioteca.syntaxerror.com/CreadorWS/listarCreadoresRequest", ReplyAction="http://bibliows.biblioteca.syntaxerror.com/CreadorWS/listarCreadoresResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        FrontEnd.CreadorWS.listarCreadoresResponse listarCreadores(FrontEnd.CreadorWS.listarCreadoresRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bibliows.biblioteca.syntaxerror.com/CreadorWS/listarCreadoresRequest", ReplyAction="http://bibliows.biblioteca.syntaxerror.com/CreadorWS/listarCreadoresResponse")]
        System.Threading.Tasks.Task<FrontEnd.CreadorWS.listarCreadoresResponse> listarCreadoresAsync(FrontEnd.CreadorWS.listarCreadoresRequest request);
        
        // CODEGEN: El parámetro 'return' requiere información adicional de esquema que no se puede capturar con el modo de parámetros. El atributo específico es 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://bibliows.biblioteca.syntaxerror.com/CreadorWS/eliminarCreadorRequest", ReplyAction="http://bibliows.biblioteca.syntaxerror.com/CreadorWS/eliminarCreadorResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        FrontEnd.CreadorWS.eliminarCreadorResponse eliminarCreador(FrontEnd.CreadorWS.eliminarCreadorRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bibliows.biblioteca.syntaxerror.com/CreadorWS/eliminarCreadorRequest", ReplyAction="http://bibliows.biblioteca.syntaxerror.com/CreadorWS/eliminarCreadorResponse")]
        System.Threading.Tasks.Task<FrontEnd.CreadorWS.eliminarCreadorResponse> eliminarCreadorAsync(FrontEnd.CreadorWS.eliminarCreadorRequest request);
        
        // CODEGEN: El parámetro 'return' requiere información adicional de esquema que no se puede capturar con el modo de parámetros. El atributo específico es 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://bibliows.biblioteca.syntaxerror.com/CreadorWS/obtenerCreadorPorIdRequest", ReplyAction="http://bibliows.biblioteca.syntaxerror.com/CreadorWS/obtenerCreadorPorIdResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        FrontEnd.CreadorWS.obtenerCreadorPorIdResponse obtenerCreadorPorId(FrontEnd.CreadorWS.obtenerCreadorPorIdRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bibliows.biblioteca.syntaxerror.com/CreadorWS/obtenerCreadorPorIdRequest", ReplyAction="http://bibliows.biblioteca.syntaxerror.com/CreadorWS/obtenerCreadorPorIdResponse")]
        System.Threading.Tasks.Task<FrontEnd.CreadorWS.obtenerCreadorPorIdResponse> obtenerCreadorPorIdAsync(FrontEnd.CreadorWS.obtenerCreadorPorIdRequest request);
        
        // CODEGEN: El parámetro 'return' requiere información adicional de esquema que no se puede capturar con el modo de parámetros. El atributo específico es 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://bibliows.biblioteca.syntaxerror.com/CreadorWS/listarNombresAutoresRequest", ReplyAction="http://bibliows.biblioteca.syntaxerror.com/CreadorWS/listarNombresAutoresResponse" +
            "")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        FrontEnd.CreadorWS.listarNombresAutoresResponse listarNombresAutores(FrontEnd.CreadorWS.listarNombresAutoresRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bibliows.biblioteca.syntaxerror.com/CreadorWS/listarNombresAutoresRequest", ReplyAction="http://bibliows.biblioteca.syntaxerror.com/CreadorWS/listarNombresAutoresResponse" +
            "")]
        System.Threading.Tasks.Task<FrontEnd.CreadorWS.listarNombresAutoresResponse> listarNombresAutoresAsync(FrontEnd.CreadorWS.listarNombresAutoresRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9037.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bibliows.biblioteca.syntaxerror.com/")]
    public partial class creadoresDTO : object, System.ComponentModel.INotifyPropertyChanged {
        
        private bool activoField;
        
        private bool activoFieldSpecified;
        
        private int idCreadorField;
        
        private bool idCreadorFieldSpecified;
        
        private string maternoField;
        
        private string nacionalidadField;
        
        private string nombreField;
        
        private string paternoField;
        
        private string seudonimoField;
        
        private tipoCreador tipoField;
        
        private bool tipoFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public bool activo {
            get {
                return this.activoField;
            }
            set {
                this.activoField = value;
                this.RaisePropertyChanged("activo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool activoSpecified {
            get {
                return this.activoFieldSpecified;
            }
            set {
                this.activoFieldSpecified = value;
                this.RaisePropertyChanged("activoSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public int idCreador {
            get {
                return this.idCreadorField;
            }
            set {
                this.idCreadorField = value;
                this.RaisePropertyChanged("idCreador");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool idCreadorSpecified {
            get {
                return this.idCreadorFieldSpecified;
            }
            set {
                this.idCreadorFieldSpecified = value;
                this.RaisePropertyChanged("idCreadorSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string materno {
            get {
                return this.maternoField;
            }
            set {
                this.maternoField = value;
                this.RaisePropertyChanged("materno");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public string nacionalidad {
            get {
                return this.nacionalidadField;
            }
            set {
                this.nacionalidadField = value;
                this.RaisePropertyChanged("nacionalidad");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        public string nombre {
            get {
                return this.nombreField;
            }
            set {
                this.nombreField = value;
                this.RaisePropertyChanged("nombre");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=5)]
        public string paterno {
            get {
                return this.paternoField;
            }
            set {
                this.paternoField = value;
                this.RaisePropertyChanged("paterno");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=6)]
        public string seudonimo {
            get {
                return this.seudonimoField;
            }
            set {
                this.seudonimoField = value;
                this.RaisePropertyChanged("seudonimo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=7)]
        public tipoCreador tipo {
            get {
                return this.tipoField;
            }
            set {
                this.tipoField = value;
                this.RaisePropertyChanged("tipo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool tipoSpecified {
            get {
                return this.tipoFieldSpecified;
            }
            set {
                this.tipoFieldSpecified = value;
                this.RaisePropertyChanged("tipoSpecified");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9037.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bibliows.biblioteca.syntaxerror.com/")]
    public enum tipoCreador {
        
        /// <remarks/>
        AUTOR,
        
        /// <remarks/>
        TRADUCTOR,
        
        /// <remarks/>
        ILUSTRADOR,
        
        /// <remarks/>
        NARRADOR,
        
        /// <remarks/>
        EDITOR,
        
        /// <remarks/>
        GUIONISTA,
        
        /// <remarks/>
        DISENADOR_EDITORIAL,
        
        /// <remarks/>
        OTRO,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="modificarCreador", WrapperNamespace="http://bibliows.biblioteca.syntaxerror.com/", IsWrapped=true)]
    public partial class modificarCreadorRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://bibliows.biblioteca.syntaxerror.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public FrontEnd.CreadorWS.creadoresDTO creador;
        
        public modificarCreadorRequest() {
        }
        
        public modificarCreadorRequest(FrontEnd.CreadorWS.creadoresDTO creador) {
            this.creador = creador;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="modificarCreadorResponse", WrapperNamespace="http://bibliows.biblioteca.syntaxerror.com/", IsWrapped=true)]
    public partial class modificarCreadorResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://bibliows.biblioteca.syntaxerror.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int @return;
        
        public modificarCreadorResponse() {
        }
        
        public modificarCreadorResponse(int @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="insertarCreador", WrapperNamespace="http://bibliows.biblioteca.syntaxerror.com/", IsWrapped=true)]
    public partial class insertarCreadorRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://bibliows.biblioteca.syntaxerror.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public FrontEnd.CreadorWS.creadoresDTO creador;
        
        public insertarCreadorRequest() {
        }
        
        public insertarCreadorRequest(FrontEnd.CreadorWS.creadoresDTO creador) {
            this.creador = creador;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="insertarCreadorResponse", WrapperNamespace="http://bibliows.biblioteca.syntaxerror.com/", IsWrapped=true)]
    public partial class insertarCreadorResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://bibliows.biblioteca.syntaxerror.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int @return;
        
        public insertarCreadorResponse() {
        }
        
        public insertarCreadorResponse(int @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="listarCreadores", WrapperNamespace="http://bibliows.biblioteca.syntaxerror.com/", IsWrapped=true)]
    public partial class listarCreadoresRequest {
        
        public listarCreadoresRequest() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="listarCreadoresResponse", WrapperNamespace="http://bibliows.biblioteca.syntaxerror.com/", IsWrapped=true)]
    public partial class listarCreadoresResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://bibliows.biblioteca.syntaxerror.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public FrontEnd.CreadorWS.creadoresDTO[] @return;
        
        public listarCreadoresResponse() {
        }
        
        public listarCreadoresResponse(FrontEnd.CreadorWS.creadoresDTO[] @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="eliminarCreador", WrapperNamespace="http://bibliows.biblioteca.syntaxerror.com/", IsWrapped=true)]
    public partial class eliminarCreadorRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://bibliows.biblioteca.syntaxerror.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int idCreador;
        
        public eliminarCreadorRequest() {
        }
        
        public eliminarCreadorRequest(int idCreador) {
            this.idCreador = idCreador;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="eliminarCreadorResponse", WrapperNamespace="http://bibliows.biblioteca.syntaxerror.com/", IsWrapped=true)]
    public partial class eliminarCreadorResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://bibliows.biblioteca.syntaxerror.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int @return;
        
        public eliminarCreadorResponse() {
        }
        
        public eliminarCreadorResponse(int @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="obtenerCreadorPorId", WrapperNamespace="http://bibliows.biblioteca.syntaxerror.com/", IsWrapped=true)]
    public partial class obtenerCreadorPorIdRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://bibliows.biblioteca.syntaxerror.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int idCreador;
        
        public obtenerCreadorPorIdRequest() {
        }
        
        public obtenerCreadorPorIdRequest(int idCreador) {
            this.idCreador = idCreador;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="obtenerCreadorPorIdResponse", WrapperNamespace="http://bibliows.biblioteca.syntaxerror.com/", IsWrapped=true)]
    public partial class obtenerCreadorPorIdResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://bibliows.biblioteca.syntaxerror.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public FrontEnd.CreadorWS.creadoresDTO @return;
        
        public obtenerCreadorPorIdResponse() {
        }
        
        public obtenerCreadorPorIdResponse(FrontEnd.CreadorWS.creadoresDTO @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="listarNombresAutores", WrapperNamespace="http://bibliows.biblioteca.syntaxerror.com/", IsWrapped=true)]
    public partial class listarNombresAutoresRequest {
        
        public listarNombresAutoresRequest() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="listarNombresAutoresResponse", WrapperNamespace="http://bibliows.biblioteca.syntaxerror.com/", IsWrapped=true)]
    public partial class listarNombresAutoresResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://bibliows.biblioteca.syntaxerror.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public FrontEnd.CreadorWS.creadoresDTO[] @return;
        
        public listarNombresAutoresResponse() {
        }
        
        public listarNombresAutoresResponse(FrontEnd.CreadorWS.creadoresDTO[] @return) {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface CreadorWSChannel : FrontEnd.CreadorWS.CreadorWS, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CreadorWSClient : System.ServiceModel.ClientBase<FrontEnd.CreadorWS.CreadorWS>, FrontEnd.CreadorWS.CreadorWS {
        
        public CreadorWSClient() {
        }
        
        public CreadorWSClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CreadorWSClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CreadorWSClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CreadorWSClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        FrontEnd.CreadorWS.modificarCreadorResponse FrontEnd.CreadorWS.CreadorWS.modificarCreador(FrontEnd.CreadorWS.modificarCreadorRequest request) {
            return base.Channel.modificarCreador(request);
        }
        
        public int modificarCreador(FrontEnd.CreadorWS.creadoresDTO creador) {
            FrontEnd.CreadorWS.modificarCreadorRequest inValue = new FrontEnd.CreadorWS.modificarCreadorRequest();
            inValue.creador = creador;
            FrontEnd.CreadorWS.modificarCreadorResponse retVal = ((FrontEnd.CreadorWS.CreadorWS)(this)).modificarCreador(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<FrontEnd.CreadorWS.modificarCreadorResponse> FrontEnd.CreadorWS.CreadorWS.modificarCreadorAsync(FrontEnd.CreadorWS.modificarCreadorRequest request) {
            return base.Channel.modificarCreadorAsync(request);
        }
        
        public System.Threading.Tasks.Task<FrontEnd.CreadorWS.modificarCreadorResponse> modificarCreadorAsync(FrontEnd.CreadorWS.creadoresDTO creador) {
            FrontEnd.CreadorWS.modificarCreadorRequest inValue = new FrontEnd.CreadorWS.modificarCreadorRequest();
            inValue.creador = creador;
            return ((FrontEnd.CreadorWS.CreadorWS)(this)).modificarCreadorAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        FrontEnd.CreadorWS.insertarCreadorResponse FrontEnd.CreadorWS.CreadorWS.insertarCreador(FrontEnd.CreadorWS.insertarCreadorRequest request) {
            return base.Channel.insertarCreador(request);
        }
        
        public int insertarCreador(FrontEnd.CreadorWS.creadoresDTO creador) {
            FrontEnd.CreadorWS.insertarCreadorRequest inValue = new FrontEnd.CreadorWS.insertarCreadorRequest();
            inValue.creador = creador;
            FrontEnd.CreadorWS.insertarCreadorResponse retVal = ((FrontEnd.CreadorWS.CreadorWS)(this)).insertarCreador(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<FrontEnd.CreadorWS.insertarCreadorResponse> FrontEnd.CreadorWS.CreadorWS.insertarCreadorAsync(FrontEnd.CreadorWS.insertarCreadorRequest request) {
            return base.Channel.insertarCreadorAsync(request);
        }
        
        public System.Threading.Tasks.Task<FrontEnd.CreadorWS.insertarCreadorResponse> insertarCreadorAsync(FrontEnd.CreadorWS.creadoresDTO creador) {
            FrontEnd.CreadorWS.insertarCreadorRequest inValue = new FrontEnd.CreadorWS.insertarCreadorRequest();
            inValue.creador = creador;
            return ((FrontEnd.CreadorWS.CreadorWS)(this)).insertarCreadorAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        FrontEnd.CreadorWS.listarCreadoresResponse FrontEnd.CreadorWS.CreadorWS.listarCreadores(FrontEnd.CreadorWS.listarCreadoresRequest request) {
            return base.Channel.listarCreadores(request);
        }
        
        public FrontEnd.CreadorWS.creadoresDTO[] listarCreadores() {
            FrontEnd.CreadorWS.listarCreadoresRequest inValue = new FrontEnd.CreadorWS.listarCreadoresRequest();
            FrontEnd.CreadorWS.listarCreadoresResponse retVal = ((FrontEnd.CreadorWS.CreadorWS)(this)).listarCreadores(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<FrontEnd.CreadorWS.listarCreadoresResponse> FrontEnd.CreadorWS.CreadorWS.listarCreadoresAsync(FrontEnd.CreadorWS.listarCreadoresRequest request) {
            return base.Channel.listarCreadoresAsync(request);
        }
        
        public System.Threading.Tasks.Task<FrontEnd.CreadorWS.listarCreadoresResponse> listarCreadoresAsync() {
            FrontEnd.CreadorWS.listarCreadoresRequest inValue = new FrontEnd.CreadorWS.listarCreadoresRequest();
            return ((FrontEnd.CreadorWS.CreadorWS)(this)).listarCreadoresAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        FrontEnd.CreadorWS.eliminarCreadorResponse FrontEnd.CreadorWS.CreadorWS.eliminarCreador(FrontEnd.CreadorWS.eliminarCreadorRequest request) {
            return base.Channel.eliminarCreador(request);
        }
        
        public int eliminarCreador(int idCreador) {
            FrontEnd.CreadorWS.eliminarCreadorRequest inValue = new FrontEnd.CreadorWS.eliminarCreadorRequest();
            inValue.idCreador = idCreador;
            FrontEnd.CreadorWS.eliminarCreadorResponse retVal = ((FrontEnd.CreadorWS.CreadorWS)(this)).eliminarCreador(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<FrontEnd.CreadorWS.eliminarCreadorResponse> FrontEnd.CreadorWS.CreadorWS.eliminarCreadorAsync(FrontEnd.CreadorWS.eliminarCreadorRequest request) {
            return base.Channel.eliminarCreadorAsync(request);
        }
        
        public System.Threading.Tasks.Task<FrontEnd.CreadorWS.eliminarCreadorResponse> eliminarCreadorAsync(int idCreador) {
            FrontEnd.CreadorWS.eliminarCreadorRequest inValue = new FrontEnd.CreadorWS.eliminarCreadorRequest();
            inValue.idCreador = idCreador;
            return ((FrontEnd.CreadorWS.CreadorWS)(this)).eliminarCreadorAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        FrontEnd.CreadorWS.obtenerCreadorPorIdResponse FrontEnd.CreadorWS.CreadorWS.obtenerCreadorPorId(FrontEnd.CreadorWS.obtenerCreadorPorIdRequest request) {
            return base.Channel.obtenerCreadorPorId(request);
        }
        
        public FrontEnd.CreadorWS.creadoresDTO obtenerCreadorPorId(int idCreador) {
            FrontEnd.CreadorWS.obtenerCreadorPorIdRequest inValue = new FrontEnd.CreadorWS.obtenerCreadorPorIdRequest();
            inValue.idCreador = idCreador;
            FrontEnd.CreadorWS.obtenerCreadorPorIdResponse retVal = ((FrontEnd.CreadorWS.CreadorWS)(this)).obtenerCreadorPorId(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<FrontEnd.CreadorWS.obtenerCreadorPorIdResponse> FrontEnd.CreadorWS.CreadorWS.obtenerCreadorPorIdAsync(FrontEnd.CreadorWS.obtenerCreadorPorIdRequest request) {
            return base.Channel.obtenerCreadorPorIdAsync(request);
        }
        
        public System.Threading.Tasks.Task<FrontEnd.CreadorWS.obtenerCreadorPorIdResponse> obtenerCreadorPorIdAsync(int idCreador) {
            FrontEnd.CreadorWS.obtenerCreadorPorIdRequest inValue = new FrontEnd.CreadorWS.obtenerCreadorPorIdRequest();
            inValue.idCreador = idCreador;
            return ((FrontEnd.CreadorWS.CreadorWS)(this)).obtenerCreadorPorIdAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        FrontEnd.CreadorWS.listarNombresAutoresResponse FrontEnd.CreadorWS.CreadorWS.listarNombresAutores(FrontEnd.CreadorWS.listarNombresAutoresRequest request) {
            return base.Channel.listarNombresAutores(request);
        }
        
        public FrontEnd.CreadorWS.creadoresDTO[] listarNombresAutores() {
            FrontEnd.CreadorWS.listarNombresAutoresRequest inValue = new FrontEnd.CreadorWS.listarNombresAutoresRequest();
            FrontEnd.CreadorWS.listarNombresAutoresResponse retVal = ((FrontEnd.CreadorWS.CreadorWS)(this)).listarNombresAutores(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<FrontEnd.CreadorWS.listarNombresAutoresResponse> FrontEnd.CreadorWS.CreadorWS.listarNombresAutoresAsync(FrontEnd.CreadorWS.listarNombresAutoresRequest request) {
            return base.Channel.listarNombresAutoresAsync(request);
        }
        
        public System.Threading.Tasks.Task<FrontEnd.CreadorWS.listarNombresAutoresResponse> listarNombresAutoresAsync() {
            FrontEnd.CreadorWS.listarNombresAutoresRequest inValue = new FrontEnd.CreadorWS.listarNombresAutoresRequest();
            return ((FrontEnd.CreadorWS.CreadorWS)(this)).listarNombresAutoresAsync(inValue);
        }
    }
}
