using ConnectFourAI.Parameters;
using ConnectFourGame.Player;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectFourAI.Builders
{
    /// <summary>
    /// Creates a population of candidates, including new, elite selection and children.
    /// </summary>
    class PopulationBuilder : IPopulationBuilder
    {
        /// <summary>
        /// Creates a population of AI players (candidates).
        /// </summary>
        /// <param name="parameters">Evolutionary algorithm parameters.</param>
        /// <returns>List of </returns>
        public IList<IAiPlayer> CreateInitialPopulation(EvolutionParameters parameters)
        {
            IList<IAiPlayer> candidates = new List<IAiPlayer>();
            ICandidateBuilder candidateBuilder = new CandidateBuilder();

            for (int i = 0; i < parameters.PopulationSize; i++)
            {
                candidates.Add(candidateBuilder.BuildAiPlayer(parameters, i));
            }

            return candidates;
        }

        /// <summary>
        /// Select elite players (those with the highest scores) from a list. The selection will be randomise from
        /// a sub-set/pool of top players.
        /// </summary>
        /// <param name="players">Players for consideration.</param>
        /// <param name="selectionSize">Amount of elite player to select.</param>
        /// <param name="poolSize">Pool of elite candidates to select from.</param>
        /// <returns>List of elite players.</returns>
        public IList<IAiPlayer> SelectElitePlayers(IList<IAiPlayer> players, int selectionSize, int poolSize)
        {
            return players.OrderByDescending(x => x.GetLastGameScore()).ToList()
                .GetRange(0, poolSize - 1).OrderBy(a => Guid.NewGuid()).ToList()
                .GetRange(0, selectionSize - 1);
        }
    }
}
