using System.Collections.Generic;
using System.Linq;
using Assets.Source.Contexts.GameContext.Model.Connections;
using Assets.Source.Contexts.GameContext.Model.Dates;
using Assets.Source.Contexts.GameContext.Model.Political;
using Assets.Source.Core.Connections;
using Assets.Source.Core.Model.Identifiable;
using JetBrains.Annotations;

namespace Assets.Source.Contexts.GameContext.Model.Characters
{
    public interface ICharacter : IIdentifiable
    {
        Gender Gender { get; }

        string FirstName { get; set; }
        IDynasty Dynasty { get; set; }

        #region Character relations
        ICharacter Father { get; set; }
        ICharacter Mother { get; set; }
        ICharacter[] Children { get; }
        ICharacter[] Siblings { get; }

        IList<IMarriage> Marriages { get; }
        ICharacter[] Spouses { get; }
        bool IsMarried { get; }
        #endregion

        #region Character age
        IDate BirthDate { get; set; }
        IDeath Death { get; set; }
        bool IsAlive { get; }
        int Age { get; }
        #endregion

        IState State { get; set; }
    }

    public abstract class BaseCharacter : ICharacter
    {
        public string Identifier { get; set; }
        public abstract Gender Gender { get; }
        public string FirstName { get; set; }
        public IDynasty Dynasty { get; set; }

        #region Character relations
        private IOneSubmissive<ICharacter, ICharacter> _father;
        public ICharacter Father
        {
            get { return _father == null ? null : _father.GetDominantForSubmissive(this); }
            set
            {
                if (_father != null)
                    _father.Unregister(this);

                _father = OneCharacterManyCharacters.GetByParent(value);
                _father.Register(this);
            }
        }

        private IOneSubmissive<ICharacter, ICharacter> _mother;
        public ICharacter Mother
        {
            get { return _mother == null ? null : _mother.GetDominantForSubmissive(this); }
            set
            {
                if (_mother != null)
                    _mother.Unregister(this);

                _mother = OneCharacterManyCharacters.GetByParent(value);
                _mother.Register(this);
            }
        }

        private IManySubmissive<ICharacter, ICharacter> _children;
        public ICharacter[] Children
        {
            get { return _children.GetDominantsForSubmissive(this); }
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

        private IList<IMarriage> _marriages; 
        public IList<IMarriage> Marriages
        {
            get { return _marriages ?? (_marriages = new List<IMarriage>()); }
        }

        public ICharacter[] Spouses
        {
            get
            {
                var hashSet = new HashSet<ICharacter>();
                foreach (var marriage in Marriages)
                {
                    if (marriage.IsActive)
                        hashSet.Add(marriage.GetSpouseOf(this));
                }

                return hashSet.ToArray();
            }
        }

        public bool IsMarried
        {
            get { return Spouses.Length > 0; }
        }

        #endregion

        public IDate BirthDate { get; set; }
        public IDeath Death { get; set; }

        public bool IsAlive
        {
            get { return Death == null; }
        }

        public int Age { get; private set; }
        public IState State { get; set; }
    }
}