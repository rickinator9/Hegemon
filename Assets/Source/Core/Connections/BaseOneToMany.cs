using System.Collections.Generic;
using System.Linq;
using Assets.Source.Contexts.GameContext.Model;

namespace Assets.Source.Core.Connections
{
    public class BaseOneToMany<TOne, TMany> : IOneSubmissive<TMany, TOne>, IManyDominant<TMany, TOne>
    {
        private readonly IList<TOne> _values;
        protected TMany _value;

        protected BaseOneToMany() 
        {
            _values = new List<TOne>();
        }

        public void Register(TOne submissive)
        {
            throw new System.NotImplementedException();
        }

        public void Unregister(TOne submissive)
        {
            throw new System.NotImplementedException();
        }

        public TMany GetDominantForSubmissive(TOne submissive)
        {
            return _value;
        }

        public TMany Value
        {
            get { return _value; }
        }

        public TOne[] GetSubmissivesForDominant(TMany dominant)
        {
            throw new System.NotImplementedException();
        }
    }
}