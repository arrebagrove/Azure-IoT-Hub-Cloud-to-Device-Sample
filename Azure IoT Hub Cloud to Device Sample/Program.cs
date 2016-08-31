using Microsoft.Azure.Devices;
using System;
using System.Text;
using System.Threading.Tasks;


namespace Azure_IoT_Hub_Cloud_to_Device_Sample
{
    class Program
    {

        static ServiceClient serviceClient;
        static string connectionString = "HostName=IoTCampAU.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=UAIZnY/9pwe6CofW6H38EFKv1qvv31UqtjjmVxLGoqk=";
        static string command = "red";

        static void Main(string[] args)
        {
            Console.WriteLine("Send Cloud-to-Device message\n");
            serviceClient = ServiceClient.CreateFromConnectionString(connectionString);

            while (command != "END")
            {
                Console.WriteLine("Enter command (red, green, blue, yellow, end)");
                command = Console.ReadLine().ToUpper();
                SendCloudToDeviceMessageAsync(command).Wait();
            }
        }

        private async static Task SendCloudToDeviceMessageAsync(string cmd)
        {
            var commandMessage = new Message(Encoding.ASCII.GetBytes(cmd));
            await serviceClient.SendAsync("pisense", commandMessage);
        }
    }
}


