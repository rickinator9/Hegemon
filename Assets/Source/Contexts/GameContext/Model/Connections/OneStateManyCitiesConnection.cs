using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Source.Contexts.GameContext.Model.Political;
using Assets.Source.Core.Connections;

namespace Assets.Source.Contexts.GameContext.Model.Connections
{
    public class OneStateManyCitiesConnection : BaseOneToMany<IState, ICity>
    {
        private static Dictionary<IState, OneStateManyCitiesConnection> connectionByState = new Dictionary<IState, OneStateManyCitiesConnection>();

        public OneStateManyCitiesConnection(IState state)
        {
            Value = state;
            connectionByState[state] = this;
        }

        public static OneStateManyCitiesConnection GetByState(IState state)
        {
            return connectionByState[state];
        }
    }
}