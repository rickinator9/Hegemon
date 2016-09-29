using System.Collections.Generic;
using Assets.Source.Contexts.GameContext.Model.Characters;
using Assets.Source.Core.Connections;

namespace Assets.Source.Contexts.GameContext.Model.Connections
{
    public class OneCharacterManyCharacters : BaseOneToMany<ICharacter, ICharacter>
    {
        private static readonly Dictionary<ICharacter, OneCharacterManyCharacters> ConnectionByParent = new Dictionary<ICharacter, OneCharacterManyCharacters>(); 

        public OneCharacterManyCharacters(ICharacter parent)
        {
            _value = parent;
            ConnectionByParent[parent] = this;
        }

        public static OneCharacterManyCharacters GetByParent(ICharacter parent)
        {
            return ConnectionByParent[parent];
        }
    }
}