using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Linq;

namespace ConnectFourAI.Parameters
{
    /// <summary>
    /// Parameters for the evolutionary algorithm.
    /// </summary>
    public class EvolutionParameters
    {
        [JsonProperty("populationSize")]
        public int PopulationSize { get; set; }

        [JsonProperty("iterations")]
        public int Iterations { get; set; }
        
        [JsonConverter(typeof(StringEnumConverter))]
        public RoundEvaluation RoundEvaluation { get; set; }
        
        [JsonProperty("parentSelectionPercentage")]
        public long ParentSelectionPercentage { get; set; }

        [JsonProperty("childMutationPercentage")]
        public int ChildMutationPercentage { get; set; }

        [JsonProperty("elitismPercentage")]
        public int ElitismPercentage { get; set; }

        [JsonProperty("candidateScoreParameters")]
        public CandidateScoreParameter[] CandidateScoreParameters { get; set; }

        /// <summary>
        /// Find and return the minimum value set for a candidate scoring type.
        /// </summary>
        /// <param name="scoreType">Score type parameter.</param>
        /// <returns>Minimum value allowed for this parameter.</returns>
        public int GetCandidateScoreParameterMin(CandidateScoreTypes scoreType)
        {
            return CandidateScoreParameters.Where(x => x.ScoreType == scoreType).Min().Min;
        }

        /// <summary>
        /// Find and return the maximum value set for a candidate scoring type.
        /// </summary>
        /// <param name="scoreType">Score type parameter.</param>
        /// <returns>Maximum value allowed for this parameter.</returns>
        public int GetCandidateScoreParameterMax(CandidateScoreTypes scoreType)
        {
            return CandidateScoreParameters.Where(x => x.ScoreType == scoreType).Max().Max;
        }
    }
}
