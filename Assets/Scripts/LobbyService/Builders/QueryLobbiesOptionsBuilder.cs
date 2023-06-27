using System.Collections.Generic;
using Unity.Services.Lobbies.Models;

namespace Unity.Services.Lobbies.Builders
{
    public class QueryLobbiesOptionsBuilder
    {
        private QueryLobbiesOptions _queryLobbiesOptions;

        public QueryLobbiesOptionsBuilder()
        {
            _queryLobbiesOptions = new QueryLobbiesOptions();
        }

        public QueryLobbiesOptionsBuilder SetCount(int count)
        {
            _queryLobbiesOptions.Count = count;
            return this;
        }

        public QueryLobbiesOptionsBuilder SetSkipValue(int skip)
        {
            _queryLobbiesOptions.Skip = skip;
            return this;
        }

        public QueryLobbiesOptionsBuilder SetSampleResults(bool sampleResults)
        {
            _queryLobbiesOptions.SampleResults = sampleResults;
            return this;
        }

        public QueryLobbiesOptionsBuilder SetFilters(List<QueryFilter> filters)
        {
            _queryLobbiesOptions.Filters = filters;
            return this;
        }

        public QueryLobbiesOptionsBuilder SetOrder(List<QueryOrder> order)
        {
            _queryLobbiesOptions.Order = order;
            return this;
        }

        public QueryLobbiesOptionsBuilder SetContinuationToken(string continuationToken)
        {
            _queryLobbiesOptions.ContinuationToken = continuationToken;
            return this;
        }
        
        public QueryLobbiesOptionsBuilder Reset()
        {
            _queryLobbiesOptions = new QueryLobbiesOptions();
            return this;
        }

        public QueryLobbiesOptions Build()
        {
            return _queryLobbiesOptions;
        }
    }
}