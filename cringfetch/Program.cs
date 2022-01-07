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
using System.Diagnostics;

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
            string user = System.Environment.UserName;
            var color = ConsoleColor.Cyan;                                                  // Here you can set your custom color theme
            bool arch = System.Environment.Is64BitOperatingSystem;
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = color; Console.Write("                           000000000    " + user);
            Console.ResetColor();
            Console.Write("@");
            Console.ForegroundColor = color; Console.Write(machine + "\n");
            Console.ResetColor();
            Console.ForegroundColor = color; Console.Write("               000 00000000000000000");
            Console.ResetColor();
            Console.WriteLine("    -------------");
            Console.ForegroundColor = color;
            Console.WriteLine("     0000000000000 00000000000000000");
            Console.WriteLine("     0000000000000 00000000000000000");
            Console.WriteLine("     0000000000000 00000000000000000");
            switch (ossub)
            {
                default:
                    Console.ForegroundColor = color; Console.Write("     0000000000000 00000000000000000    O");        
                    Console.ForegroundColor = color; Console.Write("S");
                    Console.ResetColor();
                    Console.Write(": Windows NT " + ossub + "\n");
                    break;
            }
            switch (arch)
            {
                case(true):
                    Console.ForegroundColor = color; Console.Write("     0000000000000 00000000000000000    A");        // There was no other simple way, sorry (will be soon)
                    Console.ForegroundColor = color; Console.Write("r");
                    Console.ForegroundColor = color; Console.Write("c");
                    Console.ForegroundColor = color; Console.Write("h");
                    Console.ForegroundColor = color; Console.Write("i");
                    Console.ForegroundColor = color; Console.Write("t");
                    Console.ForegroundColor = color; Console.Write("e");
                    Console.ForegroundColor = color; Console.Write("c");
                    Console.ForegroundColor = color; Console.Write("t");
                    Console.ForegroundColor = color; Console.Write("u");
                    Console.ForegroundColor = color; Console.Write("r");
                    Console.ForegroundColor = color; Console.Write("e");
                    Console.ResetColor();
                    Console.WriteLine(": 64-bit");
                    break;
                case(false):
                    Console.ForegroundColor = color; Console.Write("     0000000000000 00000000000000000    A");        
                    Console.ForegroundColor = color; Console.Write("r");
                    Console.ForegroundColor = color; Console.Write("c");
                    Console.ForegroundColor = color; Console.Write("h");
                    Console.ForegroundColor = color; Console.Write("i");
                    Console.ForegroundColor = color; Console.Write("t");
                    Console.ForegroundColor = color; Console.Write("e");
                    Console.ForegroundColor = color; Console.Write("c");
                    Console.ForegroundColor = color; Console.Write("t");
                    Console.ForegroundColor = color; Console.Write("u");
                    Console.ForegroundColor = color; Console.Write("r");
                    Console.ForegroundColor = color; Console.Write("e");
                    Console.ResetColor();
                    Console.WriteLine(": 32-bit");
                    break;
            }
            foreach (ManagementObject mo in osDetailsCollection)
            {
                Console.ForegroundColor = color; Console.Write("                                        C");
                Console.ForegroundColor = color; Console.Write("P");
                Console.ForegroundColor = color; Console.Write("U");
                Console.ResetColor();
                Console.WriteLine(string.Format(": {0}", (string)mo["Name"]));
            }
            Console.ForegroundColor = color; Console.Write("     0000000000000 00000000000000000    C");    
            Console.ForegroundColor = color; Console.Write("P");
            Console.ForegroundColor = color; Console.Write("U");
            Console.Write(" ");
            Console.ForegroundColor = color; Console.Write("c");
            Console.ForegroundColor = color; Console.Write("o");
            Console.ForegroundColor = color; Console.Write("r");
            Console.ForegroundColor = color; Console.Write("e");    
            Console.ForegroundColor = color; Console.Write("s");
            Console.ResetColor();
            Console.WriteLine(": " + cores);
            Console.ForegroundColor = color; Console.Write("     0000000000000 00000000000000000    R");
            Console.ForegroundColor = color; Console.Write("A");
            Console.ForegroundColor = color; Console.Write("M");
            Console.ResetColor();
            Console.WriteLine(": " + totalGBRam + " GB");
            Console.ForegroundColor = color; Console.Write("     0000000000000 00000000000000000    L");
            Console.ForegroundColor = color; Console.Write("A");
            Console.ForegroundColor = color; Console.Write("N");
            Console.Write(" ");
            Console.ForegroundColor = color; Console.Write("I");
            Console.ForegroundColor = color; Console.Write("P");
            Console.ForegroundColor = color; Console.Write("v");
            Console.ForegroundColor = color; Console.Write("4");
            Console.ResetColor();
            Console.WriteLine(": " + GetLocalIPAddress());
            Console.ForegroundColor = color; Console.Write("     0000000000000 00000000000000000    Theme");
            Console.ResetColor();
            Console.WriteLine(": " + GetTheme());
            Process p = Process.GetCurrentProcess();
            PerformanceCounter parent = new PerformanceCounter("Process", "Creating Process ID", p.ProcessName);
            int ppid = (int)parent.NextValue();

            if (Process.GetProcessById(ppid).ProcessName == "powershell")
            {
                Console.ForegroundColor = color; Console.Write("               000 00000000000000000    Shell");
                Console.ResetColor();
                Console.WriteLine(": PowerShell");
            }
            else
            {
                Console.ForegroundColor = color; Console.Write("               000 00000000000000000    Shell");
                Console.ResetColor();
                Console.WriteLine(": cmd");
            }
            Console.ForegroundColor = color; Console.Write("                           000000000    cringfetch");
            Console.ResetColor();
            Console.WriteLine(": version 1.2.1 (dev build)");
            Console.WriteLine();
            Console.WriteLine();
            Console.Read(); //REMOVE AFTER FINISHING WORK GODDAMIT
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
        public static string GetTheme()
        {
            string RegistryKey = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes";
            string theme;
            theme = (string)Registry.GetValue(RegistryKey, "CurrentTheme", string.Empty);
            theme = theme.Split('\\').Last().Split('.').First().ToString();
            return theme;
        }
    }
}