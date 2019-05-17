using ImageClient.ListService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.ServiceModel;
using System.Threading;
using System.Windows.Forms;

namespace ImageClient
{
    public partial class Form1 : Form
    {
        //List<ImageInfo> imageList;

        string selectedFilePath;
        string selectedFileName;

        ImageService.ImageServiceClient client;
        ListServiceClient listClient;

        public Form1()
        {
            InitializeComponent();
            //imageList = new List<ImageInfo>();
            client = new ImageService.ImageServiceClient("BasicHttpBinding_IImageService");
            client.Open();
            ProgressHandler callbackHandler = new ProgressHandler(uploadProgress, imageListBox);
            InstanceContext instanceContext = new InstanceContext(callbackHandler);
            listClient = new ListServiceClient(instanceContext);

            uploadProgress.Minimum = 0;
            
        }

        /*
        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ProgressBar uploadProgress;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button selectFileButton;
         */

        private void selectFileButton_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "JPG Image | *.jpg;*.jpeg";
            openFileDialog.FilterIndex = 0;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    selectedFilePath = openFileDialog.FileName;
                    fileLabel.Text = $"File: {selectedFilePath}";
                    selectedFileName = selectedFilePath.Split('\\').Last();

                } catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                        $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void uploadFile(string filePath, string owner, string description)
        {
            string fileName = Path.GetFileName(filePath);

            using (FileStream myFile = System.IO.File.OpenRead(filePath))
            {
                try
                {
                    client.uploadImage(
                        description,
                        selectedFileName,
                        owner,
                        myFile
                        );
                    //client.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error uploading image {filePath}");
                    Console.WriteLine(ex.ToString());
                    throw ex;
                }
            }
        }

        private void uploadButton_Click_1(object sender, EventArgs e)
        {
            if(selectedFileName != null && selectedFilePath != "" && selectedFilePath != null && ownerText.Text != "")
            {
                uploadFile(selectedFilePath, ownerText.Text, "empty");
            } else
            {
                MessageBox.Show($"{selectedFileName}\n\n{selectedFilePath}\n\n" +
                        $"Details:\n\n{ownerText.Text}");
            }
        }

        private void fileLabel_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listClient.getFileList();
        }

        private void date_Click(object sender, EventArgs e)
        {

        }

        private void author_Click(object sender, EventArgs e)
        {

        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            if (imageListBox.SelectedItem != null)
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                string selected = (string)imageListBox.SelectedItem;
                selected = selected.Replace("\\", "");
                saveDialog.FileName = selected;
                saveDialog.Filter = "JPG Image | *.jpg;*.jpeg";
                string owner = "";
                long size = 0;

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    Stream image = null;

                    try
                    {
                        owner = client.getImageByFileName(ref selected, out size, out image);
                    } catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message.ToString());
                    }
                    
                    authorLabel.Text = $"Dodano przez: {owner}";

                    Thread.Sleep(150);
                    string filePath = saveDialog.FileName;
                    downloadFile(image, filePath, size);
                }

            }
        }

        private void downloadFile(System.IO.Stream instream, string filePath, long size)
        {
            const int bufferLength = 8192;
            uploadProgress.Maximum = (int) size;
            uploadProgress.Value = 0;
            int perBuffer = (int)size / bufferLength;
            int step = uploadProgress.Maximum / perBuffer;
            int counter = 0;
            byte[] buffer = new byte[bufferLength];
            int progressCounter = 0;

            using (instream)
            using (FileStream outstream = File.Open(filePath, FileMode.Create, FileAccess.Write))
            {
                while ((counter = instream.Read(buffer, 0, bufferLength)) > 0)
                {
                    outstream.Write(buffer, 0, counter);
                    progressCounter += counter;
                    if(progressCounter > step)
                    {
                        uploadProgress.Value += step;
                        progressCounter -= step;
                    }
                    
                }
            }
        }

        private void ownerText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
