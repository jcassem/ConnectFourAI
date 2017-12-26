using Newtonsoft.Json;

namespace ConnectFourGame.Player.AiAttributes
{
    public class Characteristics
    {
        [JsonProperty("scoreForTwoInARow")]
        public long ScoreForTwoInARow { get; set; }

        [JsonProperty("scoreForThreeInARow")]
        public long ScoreForThreeInARow { get; set; }

        [JsonProperty("scoreForFourInARow")]
        public long ScoreForFourInARow { get; set; }

        [JsonProperty("scoreForGivingOpponentTwoInARow")]
        public long ScoreForGivingOpponentTwoInARow { get; set; }

        [JsonProperty("scoreForGivingOpponentThreeInARow")]
        public long ScoreForGivingOpponentThreeInARow { get; set; }

        [JsonProperty("scoreForGivingOpponentFourInARow")]
        public long ScoreForGivingOpponentFourInARow { get; set; }
    }
}
