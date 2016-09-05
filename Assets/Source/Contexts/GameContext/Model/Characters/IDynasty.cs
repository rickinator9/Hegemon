using System.Collections.Generic;
using System.Linq;
using Assets.Source.Core.Exceptions;

namespace Assets.Source.Contexts.GameContext.Model.Characters
{
    public interface IDynasty
    {
        ICharacter Progenitor { get; set; }

        ICharacter[] AllMembers { get; }

        ICharacter[] AliveMembers { get; }
    }

    public class Dynasty : IDynasty
    {
        private ICharacter _progenitor;

        public ICharacter Progenitor
        {
            get { return _progenitor; }
            set
            {
                if (_progenitor != null)
                    throw new OnlySettableOnceException();

                _progenitor = value;
            }
        }

        public ICharacter[] AllMembers
        {
            get
            {
                var hashSet = new HashSet<ICharacter>();
                AddCharacterAndDynasticChildrenToHashSet(Progenitor, hashSet, false);
                return hashSet.ToArray();
            }
        }

        private void AddCharacterAndDynasticChildrenToHashSet(ICharacter character, HashSet<ICharacter> hashSet, bool onlyAlive)
        {
            if (hashSet.Contains(character)) return;

            if ((onlyAlive && character.IsAlive) || !onlyAlive)
                hashSet.Add(character);

            foreach (var child in character.Children.Where(child => child.Dynasty == this))
            {
                AddCharacterAndDynasticChildrenToHashSet(child, hashSet, onlyAlive);
            }
        }

        public ICharacter[] AliveMembers
        {
            get
            {
                var hashSet = new HashSet<ICharacter>();
                AddCharacterAndDynasticChildrenToHashSet(Progenitor, hashSet, true);
                return hashSet.ToArray();
            }
        }
    }
}