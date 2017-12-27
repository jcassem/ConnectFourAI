using ConnectFourGame.Player;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace TestConnectFourAI
{
    /// <summary>
    /// Tests related to AI players/candidates.
    /// </summary>
    [TestClass]
    public class CandidateTest
    {
        public const int Id = 40;
        public const int Generation = 40;

        public const int ScoreConnectTwo = 20;
        public const int ScoreConnectThree = 30;
        public const int ScoreConnectFour = 40;

        public const int ScoreGivingConnectTwo = -20;
        public const int ScoreGivingConnectThree = -30;
        public const int ScoreGivingConnectFour = -40;

        public const int HighestGameScore = 100;
        public const int NumberOfWins = 8;
        public const int NumberOfLoses = 2;

        public string CandidatePlayerJson =
            $"{{   \"id\": {Id},   \"generation\": {Generation},   \"characteristics\": {{     \"scoreConnectTwo\": {ScoreConnectTwo},     \"scoreConnectThree\": {ScoreConnectThree},     \"scoreConnectFour\": {ScoreConnectFour},     \"scoreGivingConnectTwo\": {ScoreGivingConnectTwo},     \"scoreGivingConnectThree\": {ScoreGivingConnectThree},     \"scoreGivingConnectFour\": {ScoreGivingConnectFour}   }},   \"scores\":{{     \"highestGameScore\": {HighestGameScore},     \"numberOfWins\": {NumberOfWins},     \"numberOfLoses\": {NumberOfLoses}   }} }}";

        /// <summary>
        /// Test loading ai player from json to object.
        /// </summary>
        [TestMethod]
        public void LoadAiPlayerFromJsonTest()
        {
            AiPlayer player = JsonConvert.DeserializeObject<AiPlayer>(CandidatePlayerJson);

            Assert.AreEqual(Id, player.Id);
            Assert.AreEqual(Generation, player.Generation);

            Assert.AreEqual(ScoreConnectTwo, player.Characteristics.ScoreConnectTwo);
            Assert.AreEqual(ScoreConnectThree, player.Characteristics.ScoreConnectThree);
            Assert.AreEqual(ScoreConnectFour, player.Characteristics.ScoreConnectFour);

            Assert.AreEqual(ScoreGivingConnectTwo, player.Characteristics.ScoreGivingConnectTwo);
            Assert.AreEqual(ScoreGivingConnectThree, player.Characteristics.ScoreGivingConnectThree);
            Assert.AreEqual(ScoreGivingConnectFour, player.Characteristics.ScoreGivingConnectFour);
        }
    }
}
