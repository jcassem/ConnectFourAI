﻿using ConnectFourAI.Builders;
using ConnectFourAI.Parameters;
using ConnectFourGame.Player;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            candidates = candidates.OrderBy(a => Guid.NewGuid()).ToList();

            Console.WriteLine("Creating matches");
            for (int i = 0; i < candidates.Count; i += 2)
            {
                var playerOne = (AiPlayer)candidates[i];
                playerOne.GamePiece = ConnectFourGame.ConnectFourGame.PlayerOneGamePiece;

                var playerTwo = (AiPlayer)candidates[i + 1];
                playerTwo.GamePiece = ConnectFourGame.ConnectFourGame.PlayerTwoGamePiece;

                var match = new ConnectFourGame.ConnectFourGame(playerOne, playerTwo);
                match.PlayGame();

                playerOne.LastGameScore = playerOne.GetBoardScore(match.Board);
                playerTwo.LastGameScore = playerTwo.GetBoardScore(match.Board);

                if (match.Winner == ConnectFourGame.ConnectFourGame.WinningPlayer.NoWinners)
                {
                    Console.WriteLine($"Player {i} and {i + 1} drew at the game with scores: {playerOne.LastGameScore} vs {playerTwo.LastGameScore}");
                }
                else
                {
                    var winningPlayer = match.Winner == ConnectFourGame.ConnectFourGame.WinningPlayer.PlayerOneWins ? "Player One" : "Player Two";
                    Console.WriteLine($"{winningPlayer} wins with scores: {playerOne.LastGameScore} vs {playerTwo.LastGameScore}");
                }
            }

            // todo add functionality and loop through these until end condition has been met
            // Console.WriteLine("Selecting elites");
            // Console.WriteLine("Selecting parents");
            // Console.WriteLine("Creating children");
            // Console.WriteLine("Creating next generation");

            // Finish
            Console.WriteLine("------------------------");
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
            ICandidateBuilder candidateBuilder = new CandidateBuilder();

            for (int i = 0; i < parameters.PopulationSize; i++)
            {
                candidates.Add(candidateBuilder.BuildAiPlayer(parameters, i));
            }

            return candidates;
        }
    }
}