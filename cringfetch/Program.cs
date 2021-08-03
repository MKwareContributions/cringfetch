using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using Microsoft.VisualBasic.Devices;
using System.Net;
using System.Net.Sockets;
using Microsoft.Win32;

namespace cringfetch
{
    class Program
    {
        static void Main(string[] args)
        {
            SelectQuery Sq = new SelectQuery("Win32_Processor");
            ManagementObjectSearcher objOSDetails = new ManagementObjectSearcher(Sq);
            ManagementObjectCollection osDetailsCollection = objOSDetails.Get();
            StringBuilder sb = new StringBuilder();
            var totalGBRam = Convert.ToInt32((new ComputerInfo().TotalPhysicalMemory / (Math.Pow(1024, 3))) + 0.5);
            var os = Convert.ToString(new ComputerInfo().OSVersion);
            var ossub = os.Substring(0,3);
            var machine = System.Environment.MachineName;
            var cores = System.Environment.ProcessorCount;                   
            var user = System.Environment.UserName;
            Random rand = new Random();
            int randd = rand.Next(1, 5);
            bool arch = System.Environment.Is64BitOperatingSystem;
            Console.WriteLine();
            Console.WriteLine(user + "@" + machine);
            Console.WriteLine("-------------");
            Console.WriteLine();
            switch (ossub)
            {
                case("6.1"):
                    Console.WriteLine("Windows 7");
                    break;
                case("6.2"):
                    Console.WriteLine("Windows 8");
                    break;
                case("6.3"):
                    Console.WriteLine("Windows 8.1");
                    break;
                case("10."):
                    Console.WriteLine("Windows 10");
                    break;
                default:
                    Console.WriteLine("Windows NT " + ossub);
                    break;
            }
            switch (arch)
            {
                case(true):
                    Console.WriteLine("Architecture: 64-bit");
                    break;
                case(false):
                    Console.WriteLine("Architecture: 32-bit");
                    break;
            }
            foreach (ManagementObject mo in osDetailsCollection)
            {
                Console.WriteLine(string.Format("CPU: {0}", (string)mo["Name"]));
            }
            Console.WriteLine("CPU cores: " + cores);
            Console.WriteLine("RAM: " + totalGBRam + " GB");
            Console.WriteLine("LAN IPv4: " + GetLocalIPAddress());
            Console.WriteLine();
            if (randd == 3)
            {
                Console.WriteLine("ASCII Art will be added in the next update.");
            }
        }
        
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No IPv4!");
        }
        static void BlueText(string value)
        {
            Console.BackgroundColor = ConsoleColor.Black;       
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(value.PadRight(Console.WindowWidth - 1));                             // For future update
            Console.ResetColor();
        }
    }
}
