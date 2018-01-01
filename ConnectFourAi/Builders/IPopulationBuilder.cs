using System.Collections.Generic;
using ConnectFourAI.Parameters;
using ConnectFourGame.Player;

namespace ConnectFourAI.Builders
{
    /// <summary>
    /// Creates a population of candidates, including new, elite selection and children.
    /// </summary>
    public interface IPopulationBuilder
    {
        /// <summary>
        /// Creates a population of AI players (candidates).
        /// </summary>
        /// <param name="parameters">Evolutionary algorithm parameters.</param>
        /// <returns>List of </returns>
        IList<IAiPlayer> CreateInitialPopulation(EvolutionParameters parameters);
        
        /// <summary>
        /// Select elite players (those with the highest scores) from a list. The selection will be randomise from
        /// a sub-set/pool of top players.
        /// </summary>
        /// <param name="players">Players for consideration.</param>
        /// <param name="selectionSize">Amount of elite player to select.</param>
        /// <param name="poolSize">Pool of elite candidates to select from.</param>
        /// <returns>List of elite players.</returns>
        IList<IAiPlayer> SelectElitePlayers(IList<IAiPlayer> players, int selectionSize, int poolSize);
    }
}
