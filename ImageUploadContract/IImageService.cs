using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ImageUploadContract
{
    [ServiceContract]
    public interface IImageService
    {
        [OperationContract(IsOneWay = true)]
        void uploadImage(UploadImageRequest request);

        [OperationContract]
        DownloadImageResponse getImageByFileName(DownloadImageRequest request);
    }

    [MessageContract]
    public class UploadImageRequest
    {
        [MessageHeader]
        public string name;

        [MessageHeader]
        public string owner;

        [MessageHeader]
        public string description;

        [MessageBodyMember]
        public Stream image;
    }

    [MessageContract]
    public class DownloadImageResponse
    {
        [MessageHeader]
        public string fileName;

        [MessageHeader]
        public string owner;

        [MessageHeader]
        public long size;

        [MessageBodyMember]
        public Stream image;
    }

    [MessageContract]
    public class DownloadImageRequest
    {
        [MessageBodyMember]
        public string fileName;
    }
}
