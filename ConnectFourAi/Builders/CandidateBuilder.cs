using ConnectFourAI.Parameters;
using ConnectFourGame.Player;
using ConnectFourGame.Player.AiAttributes;
using System;

namespace ConnectFourAI.Builders
{
    /// <summary>
    /// AI Connect Four Candidate builder.
    /// </summary>
    class CandidateBuilder : ICandidateBuilder
    {
        private readonly Random _rand;

        private static bool _scoreParametersSet;

        private static int _scoreConnectTwoMin;
        private static int _scoreConnectTwoMax;

        private static int _scoreConnectThreeMin;
        private static int _scoreConnectThreeMax;

        private static int _scoreConnectFourMin;
        private static int _scoreConnectFourMax;

        private static int _scoreGivingConnectTwoMin;
        private static int _scoreGivingConnectTwoMax;

        private static int _scoreGivingConnectThreeMin;
        private static int _scoreGivingConnectThreeMax;

        private static int _scoreGivingConnectFourMin;
        private static int _scoreGivingConnectFourMax;

        public CandidateBuilder()
        {
            _rand = new Random();
        }

        /// <summary>
        /// Localises evolutionary parameters related to score boundaries for candidates.
        /// </summary>
        /// <param name="parameters">Evolution parameters.</param>
        private void SetupScoreParameters(EvolutionParameters parameters)
        {
            _scoreConnectTwoMin = parameters.GetCandidateScoreParameterMin(CandidateScoreTypes.ScoreConnectTwo);
            _scoreConnectTwoMax = parameters.GetCandidateScoreParameterMax(CandidateScoreTypes.ScoreConnectTwo);

            _scoreConnectThreeMin = parameters.GetCandidateScoreParameterMin(CandidateScoreTypes.ScoreConnectThree);
            _scoreConnectThreeMax = parameters.GetCandidateScoreParameterMax(CandidateScoreTypes.ScoreConnectThree);

            _scoreConnectFourMin = parameters.GetCandidateScoreParameterMin(CandidateScoreTypes.ScoreConnectFour);
            _scoreConnectFourMax = parameters.GetCandidateScoreParameterMax(CandidateScoreTypes.ScoreConnectFour);

            _scoreGivingConnectTwoMin = parameters.GetCandidateScoreParameterMin(CandidateScoreTypes.GiveConnectTwo);
            _scoreGivingConnectTwoMax = parameters.GetCandidateScoreParameterMax(CandidateScoreTypes.GiveConnectTwo);

            _scoreGivingConnectThreeMin = parameters.GetCandidateScoreParameterMin(CandidateScoreTypes.GiveConnectThree);
            _scoreGivingConnectThreeMax = parameters.GetCandidateScoreParameterMax(CandidateScoreTypes.GiveConnectThree);

            _scoreGivingConnectFourMin = parameters.GetCandidateScoreParameterMin(CandidateScoreTypes.GiveConnectFour);
            _scoreGivingConnectFourMax = parameters.GetCandidateScoreParameterMax(CandidateScoreTypes.GiveConnectThree);
        }

        /// <summary>
        /// Creat an AI Player based off the evolutionary parameters provded.
        /// </summary>
        /// <param name="parameters">Evolutionary parameters defining the boundaries of this candidates characteristics.</param>
        /// <param name="id">AI Player id.</param>
        /// <param name="generation">The generation this AI player will belong to.</param>
        /// <returns>AI Player built.</returns>
        public IAiPlayer BuildAiPlayer(EvolutionParameters parameters, int id, int generation = 1)
        {
            // Set score boundaries
            if (!_scoreParametersSet)
            {
                SetupScoreParameters(parameters);
                _scoreParametersSet = true;
            }

            var characteristics = new Characteristics
            {
                ScoreConnectTwo = _rand.Next(_scoreConnectTwoMin, _scoreConnectTwoMax),
                ScoreConnectThree = _rand.Next(_scoreConnectThreeMin, _scoreConnectThreeMax),
                ScoreConnectFour = _rand.Next(_scoreConnectFourMin, _scoreConnectFourMax),
                ScoreGivingConnectTwo = _rand.Next(_scoreGivingConnectTwoMin, _scoreGivingConnectTwoMax),
                ScoreGivingConnectThree = _rand.Next(_scoreGivingConnectThreeMin, _scoreGivingConnectThreeMax),
                ScoreGivingConnectFour = _rand.Next(_scoreGivingConnectFourMin, _scoreGivingConnectFourMax)
            };

            var aiPlayer = new AiPlayer(characteristics)
            {
                Id = id,
                Generation = 1
            };

            return aiPlayer;
        }
    }
}
