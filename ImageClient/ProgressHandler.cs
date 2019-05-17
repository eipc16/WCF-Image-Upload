using ImageClient.ListService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageClient
{
    class ProgressHandler : IListServiceCallback
    {
        ProgressBar progress;
        ListBox listBox;

        public ProgressHandler(ProgressBar progress, ListBox listBox)
        {
            this.progress = progress;
            this.listBox = listBox;
        }

        public void returnGetFileList(Dictionary<string, string> data)
        {
            listBox.DataSource = null;
            listBox.Items.Clear();
            List<string> values = new List<string>();
            foreach (KeyValuePair<string, string> kvp in data)
            {
                values.Add($"{kvp.Value}/{kvp.Key}");
            }
            listBox.DataSource = values;
        }

        public void updateProgress(int progress)
        {
            //this.progress.Value = progress;
        }
    }
}
