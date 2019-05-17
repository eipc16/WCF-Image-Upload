using ImageUploadContract;
using ListCallback;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ImageHost
{
    class Program
    {
        private static string BASE_NAME = "upload";
        private static int PORT = 9001;

        static void Main(string[] args)
        {
            Uri baseAddress = new Uri($"http://localhost:{PORT}/files/");
            Uri listAddress = new Uri($"http://localhost:9002/list/");

            ServiceHost host = new ServiceHost(typeof(ImageService), baseAddress);
            ServiceHost listHost = new ServiceHost(typeof(ListService), listAddress);
            //BasicHttpBinding binding = new BasicHttpBinding();
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.TransferMode = TransferMode.Streamed;
            binding.MaxReceivedMessageSize = 1000000000;
            binding.MaxBufferSize = 8192;

            WSDualHttpBinding binding2 = new WSDualHttpBinding();

            try
            {
                ServiceEndpoint endpoint = host.AddServiceEndpoint(typeof(IImageService), binding, BASE_NAME);
                ServiceEndpoint calcEndpoint = listHost.AddServiceEndpoint(typeof(IListService), binding2, "endpoint_list");

                ServiceMetadataBehavior smb = new ServiceMetadataBehavior
                {
                    HttpGetEnabled = true
                };
                host.Description.Behaviors.Add(smb);

                ServiceMetadataBehavior smb2 = new ServiceMetadataBehavior();
                smb2.HttpGetEnabled = true;
                listHost.Description.Behaviors.Add(smb2);

                try
                {
                    host.Open();
                    listHost.Open();
                } catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine($"Service {BASE_NAME} has connected successfully and started working");
                Console.WriteLine("Service List has connected successfully and started working!");
                Console.WriteLine("Press <ENTER> to finish!");
                Console.ReadLine();

                host.Close();
                listHost.Close();
                Console.WriteLine($"Service {BASE_NAME} has finished working!");


            }
            catch (CommunicationException exception)
            {
                Console.WriteLine($"Exception encountered: {exception}");
                host.Abort();
                listHost.Abort();
            }
        }
    }
}
