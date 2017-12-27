using Newtonsoft.Json;

namespace ConnectFourGame.Player.AiAttributes
{
    public class Characteristics
    {
        [JsonProperty("scoreConnectTwo")]
        public int ScoreConnectTwo { get; set; }

        [JsonProperty("scoreConnectThree")]
        public int ScoreConnectThree { get; set; }

        [JsonProperty("scoreConnectFour")]
        public int ScoreConnectFour { get; set; }

        [JsonProperty("scoreGivingConnectTwo")]
        public int ScoreGivingConnectTwo { get; set; }

        [JsonProperty("scoreGivingConnectThree")]
        public int ScoreGivingConnectThree { get; set; }

        [JsonProperty("scoreGivingConnectFour")]
        public int ScoreGivingConnectFour { get; set; }
    }
}
