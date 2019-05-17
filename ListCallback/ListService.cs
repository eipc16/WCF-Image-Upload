using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace ListCallback
{
    [ServiceBehavior(InstanceContextMode =InstanceContextMode.PerSession)]
    public class ListService : IListService
    {

        ListCallbackHandler callback = null;
        string dbPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\", "db.txt"));

        public ListService()
        {
            callback = OperationContext.Current.GetCallbackChannel<ListCallbackHandler>();
        }

        public void getFileList()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            String textline;
            String[] data;
            using (System.IO.StreamReader db =
                        new System.IO.StreamReader(dbPath))
            {
                do
                {
                
                    textline = db.ReadLine();

                    data = textline.Split(';');
                    result.Add(data[0], data[3]);

                } while (db.Peek() != -1);
            }

            using (StreamWriter wr = File.AppendText(Path.Combine(System.Environment.CurrentDirectory, "log_call.txt")))
            {
                wr.WriteLine("--------------");
                wr.WriteLine(result.ToString());
            }

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);
                callback.updateProgress(i + 1);
            }

            callback.returnGetFileList(result);
        }
    }
}
