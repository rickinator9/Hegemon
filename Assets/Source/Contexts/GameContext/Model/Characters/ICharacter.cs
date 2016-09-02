using System.Collections.Generic;
using System.Linq;
using Assets.Source.Contexts.GameContext.Model.Connections;
using Assets.Source.Contexts.GameContext.Model.Dates;
using Assets.Source.Core.Connections;
using Assets.Source.Core.Model.Identifiable;

namespace Assets.Source.Contexts.GameContext.Model.Characters
{
    public interface ICharacter : IIdentifiable
    {
        Gender Gender { get; }

        string FirstName { get; set; }
        IDynasty Dynasty { get; set; }

        ICharacter Father { get; set; }
        ICharacter Mother { get; set; }
        ICharacter[] Children { get; }
        ICharacter[] Siblings { get; }

        IDate BirthDate { get; set; }
        IDeath Death { get; set; }
        bool IsAlive { get; }
    }

    public abstract class BaseCharacter : ICharacter
    {
        public string Identifier { get; set; }
        public abstract Gender Gender { get; }
        public string FirstName { get; set; }
        public IDynasty Dynasty { get; set; }

        private IOne<ICharacter, ICharacter> _father;
        public ICharacter Father
        {
            get { return _father == null ? null : _father.Value; }
            set
            {
                if (_father != null)
                    _father.Unregister(this);

                _father = OneCharacterManyCharacters.GetByParent(value);
                _father.Register(this);
            }
        }

        private IOne<ICharacter, ICharacter> _mother;
        public ICharacter Mother
        {
            get { return _mother == null ? null : _mother.Value; }
            set
            {
                if (_mother != null)
                    _mother.Unregister(this);

                _mother = OneCharacterManyCharacters.GetByParent(value);
                _mother.Register(this);
            }
        }

        private IMany<ICharacter, ICharacter> _children;
        public ICharacter[] Children
        {
            get { return _children.Values; }
        }

        public ICharacter[] Siblings
        {
            get
            {
                var hashSet = new HashSet<ICharacter>();
                if (Father != null)
                {
                    foreach (var child in Father.Children)
                    {
                        hashSet.Add(child);
                    }
                }
                if (Mother != null)
                {
                    foreach (var child in Mother.Children)
                    {
                        hashSet.Add(child);
                    }
                }
                hashSet.Remove(this);

                return hashSet.ToArray();
            }
        }

        public IDate BirthDate { get; set; }
        public IDeath Death { get; set; }

        public bool IsAlive
        {
            get { return Death == null; }
        }
    }
}