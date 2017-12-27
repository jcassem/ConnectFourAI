using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ConnectFourAI.Parameters
{
    /// <summary>
    /// Parameters for the evolutionary algorithm.
    /// </summary>
    public class EvolutionParameters
    {
        [JsonProperty("populationSize")]
        public long PopulationSize { get; set; }

        [JsonProperty("iterations")]
        public long Iterations { get; set; }
        
        [JsonConverter(typeof(StringEnumConverter))]
        public RoundEvaluation RoundEvaluation { get; set; }
        
        [JsonProperty("parentSelectionPercentage")]
        public long ParentSelectionPercentage { get; set; }

        [JsonProperty("childMutationPercentage")]
        public long ChildMutationPercentage { get; set; }

        [JsonProperty("elitismPercentage")]
        public long ElitismPercentage { get; set; }

        [JsonProperty("candidateScoreParameters")]
        public CandidateScoreParameter[] CandidateScoreParameters { get; set; }
    }
}
