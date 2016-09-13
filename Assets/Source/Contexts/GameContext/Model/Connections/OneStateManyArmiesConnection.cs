using System.Collections.Generic;
using Assets.Source.Contexts.GameContext.Model.Military;
using Assets.Source.Contexts.GameContext.Model.Political;
using Assets.Source.Core.Connections;

namespace Assets.Source.Contexts.GameContext.Model.Connections
{
    public class OneStateManyArmiesConnection : BaseOneToMany<IState, IArmy>
    {
        private static IDictionary<IState, OneStateManyArmiesConnection> ConnectionByState = new Dictionary<IState, OneStateManyArmiesConnection>();  

        public OneStateManyArmiesConnection(IState state)
        {
            ConnectionByState[state] = this;
        }

        public static OneStateManyArmiesConnection GetByState(IState state)
        {
            return ConnectionByState.ContainsKey(state) ? ConnectionByState[state] : null;
        }
    }
}