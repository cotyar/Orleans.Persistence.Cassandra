﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Orleans.Persistence.Cassandra.Options
{
    public class CassandraStorageOptions
    {
        public const int DefaultInitStage = ServiceLifecycleStage.ApplicationServices;

        /// <summary>
        /// Stage of silo lifecycle where storage should be initialized.  Storage must be initialzed prior to use.
        /// </summary>
        public int InitStage { get; set; } = DefaultInitStage;

        /// <summary>
        /// Indicates if grain data should be deleted or reset to defaults when a grain clears it's state.
        /// </summary>
        public bool DeleteStateOnClear { get; set; } = false;

        public string ContactPoints { get; set; }
        public string Keyspace { get; set; } = "orleans";
        public string TableName { get; set; } = "grain_state";
        public int ReplicationFactor { get; set; } = 3;

        public JsonSerializationOptions JsonSerialization { get; set; } = new JsonSerializationOptions();

        public DiagnosticsOptions Diagnostics { get; set; } = new DiagnosticsOptions();

        public class JsonSerializationOptions
        {
            public IContractResolver ContractResolver { get; set; }
            public bool UseFullAssemblyNames { get; set; }
            public bool IndentJson { get; set; }
            public TypeNameHandling TypeNameHandling { get; set; } = TypeNameHandling.All;
            public MetadataPropertyHandling MetadataPropertyHandling { get; set; } = MetadataPropertyHandling.ReadAhead;
        }

        public class DiagnosticsOptions
        {
            public bool PerformanceCountersEnabled { get; set; }
            public bool StackTraceIncluded { get; set; }
        }
    }
}