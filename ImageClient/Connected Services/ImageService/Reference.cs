﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ImageClient.ImageService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ImageService.IImageService")]
    public interface IImageService {
        
        // CODEGEN: Generating message contract since the wrapper name (UploadImageRequest) of message UploadImageRequest does not match the default value (uploadImage)
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IImageService/uploadImage")]
        void uploadImage(ImageClient.ImageService.UploadImageRequest request);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IImageService/uploadImage")]
        System.Threading.Tasks.Task uploadImageAsync(ImageClient.ImageService.UploadImageRequest request);
        
        // CODEGEN: Generating message contract since the wrapper name (DownloadImageRequest) of message DownloadImageRequest does not match the default value (getImageByFileName)
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IImageService/getImageByFileName", ReplyAction="http://tempuri.org/IImageService/getImageByFileNameResponse")]
        ImageClient.ImageService.DownloadImageResponse getImageByFileName(ImageClient.ImageService.DownloadImageRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IImageService/getImageByFileName", ReplyAction="http://tempuri.org/IImageService/getImageByFileNameResponse")]
        System.Threading.Tasks.Task<ImageClient.ImageService.DownloadImageResponse> getImageByFileNameAsync(ImageClient.ImageService.DownloadImageRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="UploadImageRequest", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class UploadImageRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public string description;
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public string name;
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public string owner;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public System.IO.Stream image;
        
        public UploadImageRequest() {
        }
        
        public UploadImageRequest(string description, string name, string owner, System.IO.Stream image) {
            this.description = description;
            this.name = name;
            this.owner = owner;
            this.image = image;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="DownloadImageRequest", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class DownloadImageRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string fileName;
        
        public DownloadImageRequest() {
        }
        
        public DownloadImageRequest(string fileName) {
            this.fileName = fileName;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="DownloadImageResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class DownloadImageResponse {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public string fileName;
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public string owner;
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public long size;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public System.IO.Stream image;
        
        public DownloadImageResponse() {
        }
        
        public DownloadImageResponse(string fileName, string owner, long size, System.IO.Stream image) {
            this.fileName = fileName;
            this.owner = owner;
            this.size = size;
            this.image = image;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IImageServiceChannel : ImageClient.ImageService.IImageService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ImageServiceClient : System.ServiceModel.ClientBase<ImageClient.ImageService.IImageService>, ImageClient.ImageService.IImageService {
        
        public ImageServiceClient() {
        }
        
        public ImageServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ImageServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ImageServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ImageServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        void ImageClient.ImageService.IImageService.uploadImage(ImageClient.ImageService.UploadImageRequest request) {
            base.Channel.uploadImage(request);
        }
        
        public void uploadImage(string description, string name, string owner, System.IO.Stream image) {
            ImageClient.ImageService.UploadImageRequest inValue = new ImageClient.ImageService.UploadImageRequest();
            inValue.description = description;
            inValue.name = name;
            inValue.owner = owner;
            inValue.image = image;
            ((ImageClient.ImageService.IImageService)(this)).uploadImage(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task ImageClient.ImageService.IImageService.uploadImageAsync(ImageClient.ImageService.UploadImageRequest request) {
            return base.Channel.uploadImageAsync(request);
        }
        
        public System.Threading.Tasks.Task uploadImageAsync(string description, string name, string owner, System.IO.Stream image) {
            ImageClient.ImageService.UploadImageRequest inValue = new ImageClient.ImageService.UploadImageRequest();
            inValue.description = description;
            inValue.name = name;
            inValue.owner = owner;
            inValue.image = image;
            return ((ImageClient.ImageService.IImageService)(this)).uploadImageAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ImageClient.ImageService.DownloadImageResponse ImageClient.ImageService.IImageService.getImageByFileName(ImageClient.ImageService.DownloadImageRequest request) {
            return base.Channel.getImageByFileName(request);
        }
        
        public string getImageByFileName(ref string fileName, out long size, out System.IO.Stream image) {
            ImageClient.ImageService.DownloadImageRequest inValue = new ImageClient.ImageService.DownloadImageRequest();
            inValue.fileName = fileName;
            ImageClient.ImageService.DownloadImageResponse retVal = ((ImageClient.ImageService.IImageService)(this)).getImageByFileName(inValue);
            fileName = retVal.fileName;
            size = retVal.size;
            image = retVal.image;
            return retVal.owner;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ImageClient.ImageService.DownloadImageResponse> ImageClient.ImageService.IImageService.getImageByFileNameAsync(ImageClient.ImageService.DownloadImageRequest request) {
            return base.Channel.getImageByFileNameAsync(request);
        }
        
        public System.Threading.Tasks.Task<ImageClient.ImageService.DownloadImageResponse> getImageByFileNameAsync(string fileName) {
            ImageClient.ImageService.DownloadImageRequest inValue = new ImageClient.ImageService.DownloadImageRequest();
            inValue.fileName = fileName;
            return ((ImageClient.ImageService.IImageService)(this)).getImageByFileNameAsync(inValue);
        }
    }
}
