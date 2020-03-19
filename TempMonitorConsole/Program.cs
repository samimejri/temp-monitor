using System;
using TempMonitorCore;

namespace TempMonitorConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            TempMonitor tempMonitor = new TempMonitor();
            while (true)
            {
                Console.WriteLine("***********************");
                decimal cpuTemp = tempMonitor.getCPUTemp();
                Console.WriteLine($"CPU Temp: {cpuTemp}.");

                decimal gpuTemp = tempMonitor.getGPUTemp();
                Console.WriteLine($"GPU Temp: {gpuTemp}.");
                Console.ReadLine();
            }

        }
    }
}
