using ConnectFourGame.Player;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using ConnectFourAI.Parameters;

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
            EvolutionParameters parameters = ConnectFourAi.LoadEvolutionParameters();

            Console.WriteLine("Creating population");
            IList<IAiPlayer> candidates = ConnectFourAi.CreatePopulation(parameters);

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
        public static IList<IAiPlayer> CreatePopulation(EvolutionParameters parameters)
        {
            IList<IAiPlayer> candidates = new List<IAiPlayer>();

            return candidates;
        }
    }
}