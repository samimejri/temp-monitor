using System;
using LiteDB;

namespace TempMonitorDAL
{
    interface IDatabaseManager
    {
        string DBLocation { get; }

        void SaveCPUTempMeasure(TempMeasure measure);

        void SaveGPUTempMeasure(TempMeasure measure);
    }
}