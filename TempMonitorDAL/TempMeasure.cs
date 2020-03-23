namespace TempMonitorDAL
{
    using System;

    public class TempMeasure
    {
        public int Id { get; set; }
        public decimal Temp { get; set; }
        public int SessionId { get; set; }
        public DateTime? MeasureTime { get; set; }
    }
}