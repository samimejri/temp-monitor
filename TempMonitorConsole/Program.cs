using System;
using System.Collections.Generic;
using System.Linq;
using TempMonitorCore;
using TempMonitorDAL;

namespace TempMonitorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DBLiteDatabaseManager dbManager = new DBLiteDatabaseManager("C:\\Users\\SMejr\\AppData\\Local\\Temp\\TempMonitor\\TempMonitor.db");
                TempMonitor tempMonitor = new TempMonitor();
                string input = string.Empty;

                int newSession = dbManager.CPUTempMeasures.Count() > 0 ? dbManager.CPUTempMeasures.Max(m => m.SessionId) : 0;
                newSession++;

                List<TempMeasure> temps = dbManager.CPUTempMeasures.FindAll().ToList();

                while (input != "x")
                {
                    decimal cpuTemp = tempMonitor.getCPUTemp();
                    dbManager.SaveCPUTempMeasure(new TempMeasure() { SessionId = newSession, Temp = cpuTemp, MeasureTime = DateTime.Now });

                    decimal gpuTemp = tempMonitor.getGPUTemp();
                    dbManager.SaveCPUTempMeasure(new TempMeasure() { SessionId = newSession, Temp = gpuTemp, MeasureTime = DateTime.Now });

                    System.Threading.Thread.Sleep(1000);
                    input = Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException);
                Console.WriteLine(e.StackTrace);
                Console.ReadLine();
            }
        }
    }
}
