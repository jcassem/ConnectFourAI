﻿using System;
using System.Collections.Generic;
using System.IO;
using ConnectFourAI.Parameters;
using ConnectFourGame.Player;
using ConnectFourGame.Player.AiAttributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConnectFourAI
{
    /// <summary>
    /// Runs the Connect four Ai simulation.
    /// </summary>
    class ConnectFourAi
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Reading EA parameters");
            EvolutionParameters parameters = LoadEvolutionParameters();
            
            // Ensure population size is divisable by two
            if (parameters.PopulationSize % 2 != 0)
            {
                parameters.PopulationSize++;
            }

            Console.WriteLine("Creating population");
            IList<IAiPlayer> candidates = CreateInitialPopulation(parameters);

            // todo add functionality and loop through these until end condition has been met
            Console.WriteLine("Creating matches");
            Console.WriteLine("Selecting elites");
            Console.WriteLine("Selecting parents");
            Console.WriteLine("Creating children");
            Console.WriteLine("Creating next generation");

            // Finish
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        /// <summary>
        /// Loads the evolutionary algorithm parameters from JSON file.
        /// </summary>
        /// <returns>Evolutionary algorithm parameters.</returns>
        public static EvolutionParameters LoadEvolutionParameters()
        {
            EvolutionParameters parameters;
            var exampleCandidateJsonFilePath = @"Examples\evolutionParameters.json";

            using (StreamReader file = File.OpenText(exampleCandidateJsonFilePath))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                var json = JToken.ReadFrom(reader).ToString();
                parameters = JsonConvert.DeserializeObject<EvolutionParameters>(json);
            }

            return parameters;
        }

        /// <summary>
        /// Creates a population of AI players (candidates).
        /// </summary>
        /// <param name="parameters">Evolutionary algorithm parameters.</param>
        /// <returns>List of </returns>
        public static IList<IAiPlayer> CreateInitialPopulation(EvolutionParameters parameters)
        {
            IList<IAiPlayer> candidates = new List<IAiPlayer>();
            Random rand = new Random();

            var scoreConnectTwoMin = parameters.GetCandidateScoreParameterMin(CandidateScoreTypes.ScoreConnectTwo);
            var scoreConnectTwoMax = parameters.GetCandidateScoreParameterMax(CandidateScoreTypes.ScoreConnectTwo);

            var scoreConnectThreeMin = parameters.GetCandidateScoreParameterMin(CandidateScoreTypes.ScoreConnectThree);
            var scoreConnectThreeMax = parameters.GetCandidateScoreParameterMax(CandidateScoreTypes.ScoreConnectThree);

            var scoreConnectFourMin = parameters.GetCandidateScoreParameterMin(CandidateScoreTypes.ScoreConnectFour);
            var scoreConnectFourMax = parameters.GetCandidateScoreParameterMax(CandidateScoreTypes.ScoreConnectFour);

            var scoreGivingConnectTwoMin = parameters.GetCandidateScoreParameterMin(CandidateScoreTypes.GiveConnectTwo);
            var scoreGivingConnectTwoMax = parameters.GetCandidateScoreParameterMax(CandidateScoreTypes.GiveConnectTwo);

            var scoreGivingConnectThreeMin = parameters.GetCandidateScoreParameterMin(CandidateScoreTypes.GiveConnectThree);
            var scoreGivingConenctThreeMax = parameters.GetCandidateScoreParameterMax(CandidateScoreTypes.GiveConnectThree);

            var scoreGivingConnectFourMin = parameters.GetCandidateScoreParameterMin(CandidateScoreTypes.GiveConnectFour);
            var scoreGivingConnectFourMax = parameters.GetCandidateScoreParameterMax(CandidateScoreTypes.GiveConnectThree);

            for (int i = 0; i < parameters.PopulationSize; i++)
            {
                var characteristics = new Characteristics
                {
                    ScoreConnectTwo = rand.Next(scoreConnectTwoMin, scoreConnectTwoMax),
                    ScoreConnectThree = rand.Next(scoreConnectThreeMin, scoreConnectThreeMax),
                    ScoreConnectFour = rand.Next(scoreConnectFourMin, scoreConnectFourMax),
                    ScoreGivingConnectTwo = rand.Next(scoreGivingConnectTwoMin, scoreGivingConnectTwoMax),
                    ScoreGivingConnectThree = rand.Next(scoreGivingConnectThreeMin, scoreGivingConenctThreeMax),
                    ScoreGivingConnectFour = rand.Next(scoreGivingConnectFourMin, scoreGivingConnectFourMax)
                };

                var aiPlayer = new AiPlayer(characteristics)
                {
                    Id = i,
                    Generation = 1
                };

                candidates.Add(aiPlayer);
            }

            return candidates;
        }
    }
}