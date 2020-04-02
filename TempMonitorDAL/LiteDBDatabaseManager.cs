namespace TempMonitorDAL
{
    using System;
    using LiteDB;

    // public class DBLiteDatabaseManager : IDatabaseManager, IDisposable
    // {
    //     public ILiteCollection<TempMeasure> CPUTempMeasures { get; set; }
    //     public ILiteCollection<TempMeasure> GPUTempMeasures { get; set; }

    //     public DBLiteDatabaseManager(string dbLocation)
    //     {
    //         this.DBLocation = dbLocation;

    //         if (!string.IsNullOrEmpty(DBLocation))
    //         {
    //             this.db = new LiteDatabase(DBLocation);

    //             CPUTempMeasures = this.db.GetCollection<TempMeasure>("cpu_temps");
    //             GPUTempMeasures = this.db.GetCollection<TempMeasure>("gpu_temps");
    //         }
    //     }

    //     public string DBLocation { get; set; }

    //     private LiteDatabase db = null;

    //     public void SaveCPUTempMeasure(TempMeasure measure)
    //     {
    //         this.CPUTempMeasures.Insert(measure);
    //     }

    //     public void SaveGPUTempMeasure(TempMeasure measure)
    //     {
    //         this.GPUTempMeasures.Insert(measure);
    //     }

    //     public void Dispose()
    //     {
    //         this.db.Dispose();
    //     }
    // }

    public class DBLiteDatabaseManager : IDatabaseManager, IDisposable
    {
        public ILiteCollection<TempMeasure> CPUTempMeasures { get; set; }
        public ILiteCollection<TempMeasure> GPUTempMeasures { get; set; }
        public DBLiteDatabaseManager(string dbLocation)
        {
            this.DBLocation = dbLocation;

            if (!string.IsNullOrEmpty(DBLocation))
            {
                this.db = new LiteDatabase(DBLocation);

                CPUTempMeasures = this.db.GetCollection<TempMeasure>("cpu_temps");
                GPUTempMeasures = this.db.GetCollection<TempMeasure>("gpu_temps");
            }
        }

        public string DBLocation { get; set; }

        private LiteDatabase db = null;

        public void SaveCPUTempMeasure(TempMeasure measure)
        {
            this.CPUTempMeasures.Insert(measure);
        }

        public void SaveGPUTempMeasure(TempMeasure measure)
        {
            this.GPUTempMeasures.Insert(measure);
        }

        private static DBLiteDatabaseManager _instance;
        private static readonly object _lock = new object();

        public static DBLiteDatabaseManager GetInstance(string dbLocation)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new DBLiteDatabaseManager(dbLocation);
                    }
                }
            }
            return _instance;
        }

        public void Dispose()
        {
            this.db.Dispose();
        }
    }
}