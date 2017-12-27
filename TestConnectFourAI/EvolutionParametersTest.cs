using ConnectFourAI.Parameters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace TestConnectFourAI
{
    /// <summary>
    /// Test loading evolution algorithm paraters.
    /// </summary>
    [TestClass]
    public class EvolutionParametersTest
    {
        public const int PopulationSize = 40;

        public const int Iterations = 50;

        public const string RoundEvaluation = "SingleMatch";
        public const RoundEvaluation RoundEval = ConnectFourAI.Parameters.RoundEvaluation.SingleMatch;

        public const int ParentSelectionPercentage = 10;

        public const int ChildMutationPercentage = 10;

        public const int ElitismPercentage = 5;

        public const int ScoreConnectTwoMin = 2;
        public const int ScoreConnectTwoMax = 20;

        public const int ScoreConnectThreeMin = 3;
        public const int ScoreConnectThreeMax = 30;

        public const int ScoreConnectFourMin = 4;
        public const int ScoreConnectFourMax = 40;

        public const int GiveScoreConnectTwoMin = -2;
        public const int GiveScoreConnectTwoMax = -20;

        public const int GiveScoreConnectThreeMin = -3;
        public const int GiveScoreConnectThreeMax = -30;

        public const int GiveScoreConnectFourMin = -4;
        public const int GiveScoreConnectFourMax = -40;

        public string EvolutionParamterJson = $"{{   \"populationSize\": {PopulationSize},   \"iterations\": {Iterations},   \"roundEvaluation\": \"{RoundEvaluation}\",   \"parentSelectionPercentage\": {ParentSelectionPercentage},   \"childMutationPercentage\": {ChildMutationPercentage},   \"elitismPercentage\": {ElitismPercentage},   \"candidateScoreParameters\": [     {{       \"scoreType\": \"ScoreConnectTwo\",       \"min\": {ScoreConnectTwoMin},       \"max\": {ScoreConnectTwoMax}     }},     {{       \"scoreType\": \"ScoreConnectThree\",       \"min\": {ScoreConnectThreeMin},       \"max\": {ScoreConnectThreeMax}     }},     {{       \"scoreType\": \"ScoreConnectFour\",       \"min\": {ScoreConnectFourMin},       \"max\": {ScoreConnectFourMax}     }},     {{       \"scoreType\": \"GiveConnectTwo\",       \"min\": {GiveScoreConnectTwoMin},       \"max\": {GiveScoreConnectTwoMax}     }},     {{       \"scoreType\": \"GiveConnectThree\",       \"min\": {GiveScoreConnectThreeMin},       \"max\": {GiveScoreConnectThreeMax}     }},     {{       \"scoreType\": \"GiveConnectFour\",       \"min\": {GiveScoreConnectFourMin},       \"max\": {GiveScoreConnectFourMax}     }}   ] }}";

        /// <summary>
        /// Test loading evolution parameters from json to object.
        /// </summary>
        [TestMethod]
        public void LoadEvolutionParametersFromJsonTest()
        {
            EvolutionParameters parameters = JsonConvert.DeserializeObject<EvolutionParameters>(EvolutionParamterJson);

            Assert.AreEqual(PopulationSize, parameters.PopulationSize);
            Assert.AreEqual(Iterations, parameters.Iterations);
            Assert.AreEqual(RoundEval, parameters.RoundEvaluation);
            Assert.AreEqual(ParentSelectionPercentage, parameters.ParentSelectionPercentage);
            Assert.AreEqual(ChildMutationPercentage, parameters.ChildMutationPercentage);
            Assert.AreEqual(ElitismPercentage, parameters.ElitismPercentage);

            Assert.AreEqual(ScoreConnectTwoMin, parameters.GetCandidateScoreParameterMin(CandidateScoreTypes.ScoreConnectTwo));
            Assert.AreEqual(ScoreConnectTwoMax, parameters.GetCandidateScoreParameterMax(CandidateScoreTypes.ScoreConnectTwo));

            Assert.AreEqual(ScoreConnectThreeMin, parameters.GetCandidateScoreParameterMin(CandidateScoreTypes.ScoreConnectThree));
            Assert.AreEqual(ScoreConnectThreeMax, parameters.GetCandidateScoreParameterMax(CandidateScoreTypes.ScoreConnectThree));

            Assert.AreEqual(ScoreConnectFourMin, parameters.GetCandidateScoreParameterMin(CandidateScoreTypes.ScoreConnectFour));
            Assert.AreEqual(ScoreConnectFourMax, parameters.GetCandidateScoreParameterMax(CandidateScoreTypes.ScoreConnectFour));

            Assert.AreEqual(GiveScoreConnectTwoMin, parameters.GetCandidateScoreParameterMin(CandidateScoreTypes.GiveConnectTwo));
            Assert.AreEqual(GiveScoreConnectTwoMax, parameters.GetCandidateScoreParameterMax(CandidateScoreTypes.GiveConnectTwo));

            Assert.AreEqual(GiveScoreConnectThreeMin, parameters.GetCandidateScoreParameterMin(CandidateScoreTypes.GiveConnectThree));
            Assert.AreEqual(GiveScoreConnectThreeMax, parameters.GetCandidateScoreParameterMax(CandidateScoreTypes.GiveConnectThree));

            Assert.AreEqual(GiveScoreConnectFourMin, parameters.GetCandidateScoreParameterMin(CandidateScoreTypes.GiveConnectFour));
            Assert.AreEqual(GiveScoreConnectFourMax, parameters.GetCandidateScoreParameterMax(CandidateScoreTypes.GiveConnectFour));
        }
    }
}
