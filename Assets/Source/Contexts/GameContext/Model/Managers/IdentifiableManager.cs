using System.Collections.Generic;
using System.Linq;
using Assets.Source.Core.Model;

namespace Assets.Source.Contexts.GameContext.Model.Managers
{
    public abstract class IdentifiableManager<T> : BaseIdentifiableManager<T> where T : IIdentifiable
    {
        private Dictionary<string, T> typeByString { get; set; } 

        public override T[] ToArray
        {
            get { return typeByString.Values.ToArray(); }
        }

        public override int Count
        {
            get { return typeByString.Count; }
        }

        public override void Set(T element)
        {
            typeByString[element.Identifier] = element;
        }

        public override T Get(string identifier)
        {
            return typeByString[identifier];
        }

        protected IdentifiableManager()
        {
            typeByString = new Dictionary<string, T>();
        } 
    }
}