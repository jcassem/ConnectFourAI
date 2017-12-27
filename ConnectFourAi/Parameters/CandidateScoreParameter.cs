using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ConnectFourAI.Parameters
{
    /// <summary>
    /// Score paremeter with its set min and max values.
    /// </summary>
    public class CandidateScoreParameter
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public CandidateScoreTypes ScoreType { get; set; }

        [JsonProperty("min")]
        public int Min { get; set; }

        [JsonProperty("max")]
        public int Max { get; set; }
    }
}
