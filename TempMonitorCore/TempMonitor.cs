namespace TempMonitorCore
{
    using System;
    using System.Linq;
    using OpenHardwareMonitor.Hardware;

    public class TempMonitor
    {
        public int getCPUTemp()
        {

            Computer computer = new Computer() { CPUEnabled = true, GPUEnabled = true };
            try
            {
                computer.Open();
                var CPU = computer.Hardware.Where(h => h.HardwareType == HardwareType.CPU).FirstOrDefault();
                var cpuTemp = CPU.Sensors.Where(s => s.SensorType == SensorType.Temperature && s.Name.Contains("Package")).FirstOrDefault().Value;
                computer.Close();
                return Convert.ToInt32(cpuTemp);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

            return 0;
        }

        public int getGPUTemp()
        {
            try
            {
                Computer computer = new Computer() { CPUEnabled = true, GPUEnabled = true };
                computer.Open();
                var GPU = computer.Hardware.Where(h => h.HardwareType == HardwareType.GpuNvidia).FirstOrDefault();
                var gpuTemp = GPU.Sensors.Where(s => s.SensorType == SensorType.Temperature).FirstOrDefault().Value;
                computer.Close();
                return Convert.ToInt32(gpuTemp);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

            return 0;
        }

    }
}
