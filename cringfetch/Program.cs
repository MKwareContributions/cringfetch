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
            bool arch = System.Environment.Is64BitOperatingSystem;
            Console.WriteLine();
            string a = user + "@" + machine;
            var o = a.IndexOf('@');
            Console.Write(a.Substring(0, o));
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(a[o]);
            Console.ResetColor();
            Console.WriteLine(a.Substring(o + 1));
            BlueText("-------------");
            Console.WriteLine();
            Console.WriteLine();
            switch (ossub)
            {
                case("6.1"):
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("O");        // I DO know that this is not the best solution, but if you know a better solution - use Issues or Pull Requests.
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("S");
                    Console.ResetColor();
                    Console.Write(": Windows 7\n");
                    break;
                case("6.2"):
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("O");        
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("S");
                    Console.ResetColor();
                    Console.Write(": Windows 8\n");
                    break;
                case("6.3"):
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("O");        
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("S");
                    Console.ResetColor();
                    Console.Write(": Windows 8.1\n");
                    break;
                case("10."):
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("O");        
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("S");
                    Console.ResetColor();
                    Console.Write(": Windows 10\n");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("O");        
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("S");
                    Console.ResetColor();
                    Console.Write(": Windows NT " + ossub);
                    break;
            }
            switch (arch)
            {
                case(true):
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("A");        // Ok, this is the worst part
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("r");
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("c");
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("h");
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("i");
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("t");
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("e");
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("c");
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("t");
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("u");
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("r");
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("e");
                    Console.ResetColor();
                    Console.WriteLine(": 64-bit");
                    break;
                case(false):
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("A");        
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("r");
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("c");
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("h");
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("i");
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("t");
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("e");
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("c");
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("t");
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("u");
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("r");
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("e");
                    Console.ResetColor();
                    Console.WriteLine(": 32-bit");
                    break;
            }
            foreach (ManagementObject mo in osDetailsCollection)
            {
                Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("C");
                Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("P");
                Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("U");
                Console.ResetColor();
                Console.WriteLine(string.Format(": {0}", (string)mo["Name"]));
            }
            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("C");    // dear God
            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("P");
            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("U");
            Console.Write(" ");
            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("c");
            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("o");
            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("r");
            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("e");    // In the next update I should make color as var, so you can change it easily (if it's possible)
            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("s");
            Console.ResetColor();
            Console.WriteLine(": " + cores);
            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("R");
            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("A");
            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("M");
            Console.ResetColor();
            Console.WriteLine(": " + totalGBRam + " GB");
            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("L");
            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("A");
            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("N");
            Console.Write(" ");
            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("I");
            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("P");
            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("v");
            Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("4");
            Console.ResetColor();
            Console.WriteLine(": " + GetLocalIPAddress());
            Console.WriteLine();
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
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(value.PadRight(Console.WindowWidth - 1));                            
            Console.ResetColor();
        }
    }
}
