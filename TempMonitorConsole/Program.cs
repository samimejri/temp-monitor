using System;
using System.Collections.Generic;
using System.IO;
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
                DBLiteDatabaseManager dbManager = DBLiteDatabaseManager.GetInstance($"{Path.GetTempPath()}\\TempMonitor\\TempMonitor.db");
                TempMonitor tempMonitor = new TempMonitor();

                int newSession = dbManager.CPUTempMeasures.Count() > 0 ? dbManager.CPUTempMeasures.Max(m => m.SessionId) : 0;
                newSession++;

                List<TempMeasure> temps = dbManager.CPUTempMeasures.FindAll().ToList();

                decimal cpuTemp = tempMonitor.getCPUTemp();
                dbManager.SaveCPUTempMeasure(new TempMeasure() { SessionId = newSession, Temp = cpuTemp, MeasureTime = DateTime.Now });

                decimal gpuTemp = tempMonitor.getGPUTemp();
                dbManager.SaveGPUTempMeasure(new TempMeasure() { SessionId = newSession, Temp = gpuTemp, MeasureTime = DateTime.Now });
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
