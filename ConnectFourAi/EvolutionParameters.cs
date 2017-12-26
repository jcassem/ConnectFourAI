using Newtonsoft.Json;

namespace ConnectFourAI
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

        [JsonProperty("roundEvaluation")]
        public string RoundEvaluation { get; set; }

        [JsonProperty("parentSelectionPercentage")]
        public long ParentSelectionPercentage { get; set; }

        [JsonProperty("childMutationPercentage")]
        public long ChildMutationPercentage { get; set; }

        [JsonProperty("elitismPercentage")]
        public long ElitismPercentage { get; set; }
    }
}
