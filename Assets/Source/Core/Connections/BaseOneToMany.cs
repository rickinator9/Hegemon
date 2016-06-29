using System.Collections.Generic;
using System.Linq;
using Assets.Source.Contexts.GameContext.Model;

namespace Assets.Source.Core.Connections
{
    public class BaseOneToMany<TOne, TMany> : IOne<TOne, TMany>, IMany<TMany, TOne>
    {
        private readonly IList<TMany> _values;
        public TMany[] Values { get { return _values.ToArray(); } }

        public void Register(TMany value)
        {
            _values.Add(value);
        }

        public TOne Unregister(TMany value)
        {
            _values.Remove(value);
            return Value;
        }

        private TOne _value;
        public TOne Value
        {
            get { return _value; }
            set
            {
                if (_value == null)
                    _value = value;
            }
        }

        protected BaseOneToMany() 
        {
            _values = new List<TMany>();
        }
    }
}