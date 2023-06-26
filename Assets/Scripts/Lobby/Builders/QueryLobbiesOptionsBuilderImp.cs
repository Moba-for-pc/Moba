using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Builders;
using UnityEngine;

public class QueryLobbiesOptionsBuilderImp : MonoBehaviour
{
    public QueryLobbiesOptions BuildLobbyQueryOptions()
    {
        QueryLobbiesOptions lobbyOptions = new QueryLobbiesOptionsBuilder()
            .Reset()
            .SetCount(20)
            //.SetSkip(None)
            //.SetSampleResults(None)
            //.SetFilters(None)
            //.SetOrder(None)
            //.SetContinuationToken(None)
            .Build();

        return lobbyOptions;
    }
}
