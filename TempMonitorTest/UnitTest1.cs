using Xunit;
using TempMonitorCore;

namespace TempMonitorTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            TempMonitor tempMonitor = new TempMonitor();
            decimal gpuTemp = tempMonitor.getGPUTemp();

            Assert.Equal(0, gpuTemp);
        }
    }
}
