using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.ServiceModel;
using System.Threading;

namespace ImageUploadContract
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class ImageService : IImageService
    {
        //UploadImageCallbackHandler callback = null;
        string dbPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\", "db.txt"));

        public ImageService()
        {
            //callback = OperationContext.Current.GetCallbackChannel<UploadImageCallbackHandler>();
        }

        public DownloadImageResponse getImageByFileName(DownloadImageRequest request)
        {
            string fileName = null, owner = null, description = null, date = null;
            string filePath = Path.Combine(System.Environment.CurrentDirectory, "files", $"{owner}{request.fileName}");
            String textline;
            String[] data;
            using (System.IO.StreamReader db =
                        new System.IO.StreamReader(dbPath))
            {
                do
                {
                    textline = db.ReadLine();
                    data = textline.Split(';');

                    string filestr = data[3] + data[0];
                    request.fileName = request.fileName.Replace("/", "");

                    if (filestr == request.fileName)
                    {
                        fileName = request.fileName;
                        
                        date = data[2];
                        owner = data[3];

                        break;
                    }
                } while (db.Peek() != -1);
            }

            DownloadImageResponse file = new DownloadImageResponse();
            if (fileName != null)
            {
                FileStream image = getImageFromDisk(fileName);

                file.fileName = fileName;
                file.size = image.Length;
                file.image = image;

                //callback.returnGetImage(file);
            }
            return file;
        }

        public void uploadImage(UploadImageRequest request)
        {

            DateTime dateTime = DateTime.UtcNow.Date;
            using (System.IO.StreamWriter file =
                        new System.IO.StreamWriter(dbPath, true))
            {
                request.description = request.description.Replace(" ", "%20");
                file.WriteLine($"{request.name};{request.description};{dateTime.ToString("dd/MM/yyyy")};{request.owner}");
            }

            saveImage(request.name, request.owner, request.image);
            Thread.Sleep(3000);
            //callback.returnUploadResult("SUCCESS");
        }

        private void saveImage(string name, string owner, Stream file)
        {
            string filePath = Path.Combine(System.Environment.CurrentDirectory, "files", $"{owner}{name}");
            const int bufferLength = 8192;
            int counter = 0;
            byte[] buffer = new byte[bufferLength];

            Console.WriteLine($"Uploading file: {name}");
            try
            {

                using (FileStream outstream = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.Write))
                {

                    while ((counter = file.Read(buffer, 0, bufferLength)) > 0)
                    {
                        outstream.Write(buffer, 0, counter);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }

            file.Close();
            Console.WriteLine($"Uploaded file: {name}");
        }

        private FileStream getImageFromDisk(string fileName)
        {
            FileStream file;

            string filePath = Path.Combine(System.Environment.CurrentDirectory, "files", fileName);

            try
            {
                file = System.IO.File.OpenRead(filePath);

            }
            catch (IOException e)
            {
                Console.WriteLine(string.Format($"Could not load file: {filePath}: "));
                Console.WriteLine(e.ToString());
                throw e;
            }
            return file;
        }
    }
}
