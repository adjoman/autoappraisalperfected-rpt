
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AutoAppraisalsPerfected.Models
{
    // To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
    //
    //    var vin = Vin.FromJson(jsonString);

        public partial class Vin
        {
            [JsonProperty("Count", NullValueHandling = NullValueHandling.Ignore)]
            public long? Count { get; set; }

            [JsonProperty("Message", NullValueHandling = NullValueHandling.Ignore)]
            public string Message { get; set; }

            [JsonProperty("SearchCriteria", NullValueHandling = NullValueHandling.Ignore)]
            public string SearchCriteria { get; set; }

            [JsonProperty("Results", NullValueHandling = NullValueHandling.Ignore)]
            public List<Result> Results { get; set; }
        }

        public partial class Result
        {
            [JsonProperty("Value")]
            public string Value { get; set; }

            [JsonProperty("ValueId")]
            public string ValueId { get; set; }

            [JsonProperty("Variable", NullValueHandling = NullValueHandling.Ignore)]
            public string Variable { get; set; }

            [JsonProperty("VariableId", NullValueHandling = NullValueHandling.Ignore)]
            public long? VariableId { get; set; }
        }

        public partial class Vin
        {
            public static Vin FromJson(string json) => JsonConvert.DeserializeObject<Vin>(json, AutoAppraisalsPerfected.Models.Converter.Settings);
        }

        public static class Serialize
        {
           public static string ToJson(this Vin self) => JsonConvert.SerializeObject(self, AutoAppraisalsPerfected.Models.Converter.Settings);
        }

        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters = {
                    new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
                },
            };
        }
}
