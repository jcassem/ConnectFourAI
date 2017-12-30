using ConnectFourAI.Parameters;
using ConnectFourGame.Player;

namespace ConnectFourAI.Builders
{
    /// <summary>
    /// AI Connect Four Candidate builder.
    /// </summary>
    interface ICandidateBuilder
    {
        /// <summary>
        /// Creat an AI Player based off the evolutionary parameters provded.
        /// </summary>
        /// <param name="parameters">Evolutionary parameters defining the boundaries of this candidates characteristics.</param>
        /// <param name="id">AI Player id.</param>
        /// <param name="generation">The generation this AI player will belong to.</param>
        /// <returns>AI Player built.</returns>
        IAiPlayer BuildAiPlayer(EvolutionParameters parameters, int id, int generation = 1);
    }
}
