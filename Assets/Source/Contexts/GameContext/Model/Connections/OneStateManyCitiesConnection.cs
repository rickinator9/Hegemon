using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Source.Contexts.GameContext.Model.Political;
using Assets.Source.Core.Connections;

namespace Assets.Source.Contexts.GameContext.Model.Connections
{
    public class OneStateManyCitiesConnection : BaseOneToMany<ICity, IState>
    {
        private static readonly Dictionary<IState, OneStateManyCitiesConnection> ConnectionByState = new Dictionary<IState, OneStateManyCitiesConnection>();

        public OneStateManyCitiesConnection(IState state)
        {
            _value = state;
            ConnectionByState[state] = this;
        }

        public static OneStateManyCitiesConnection GetByState(IState state)
        {
            return ConnectionByState[state];
        }
    }
}