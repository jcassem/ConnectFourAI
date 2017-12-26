using Newtonsoft.Json;

namespace ConnectFourGame.Player.AiAttributes
{
    public class Scores
    {
        [JsonProperty("highestGameScore")]
        public long HighestGameScore { get; set; }

        [JsonProperty("numberOfWins")]
        public long NumberOfWins { get; set; }

        [JsonProperty("numberOfLoses")]
        public long NumberOfLoses { get; set; }
    }
}
