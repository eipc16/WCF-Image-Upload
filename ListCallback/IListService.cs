using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ListCallback
{
    [ServiceContract(SessionMode = SessionMode.Required,
        CallbackContract = typeof(ListCallbackHandler))]
    public interface IListService
    {
        [OperationContract(IsOneWay = true)]
        void getFileList();
    }

    public interface ListCallbackHandler
    {
        [OperationContract(IsOneWay = true)]
        void returnGetFileList(Dictionary<string, string> data);

        [OperationContract(IsOneWay = true)]
        void updateProgress(int progress);
    }
}
